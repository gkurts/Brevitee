using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Brevitee.Data
{
    public class SqlStringBuilder: IHasFilters
    {
        StringBuilder _stringBuilder;
        protected List<IParameterInfo> parameters;
        public static implicit operator string(SqlStringBuilder sqlStringBuilder)
        {
            return sqlStringBuilder._stringBuilder.ToString();
        }

        public SqlStringBuilder()
        {
            Reset();
			TableNameFormatter = t => string.Format("[{0}]", t);
			ColumnNameFormatter = c => string.Format("[{0}]", c);
            this.Executed += (s, d) =>
            {
                s.Reset();
            };
        }

		public SqlStringBuilder(string command)
			: this()
		{
			this._stringBuilder = new StringBuilder(command);
		}
		
        public virtual void Reset()
        {
            _stringBuilder = new StringBuilder();
            this.GoText = ";\r\n";
            this.parameters = new List<IParameterInfo>();
            NextNumber = 1;
        }

		public Func<string, string> TableNameFormatter
		{
			get;
			set;
		}

		public Func<string, string> ColumnNameFormatter
		{
			get;
			set;
		}

        public event SqlExecuteDelegate Executed;


        public DataTable GetDataTable(Database db)
        {
            if (!string.IsNullOrEmpty(this))
            {
                DataTable val = db.GetDataTableFromSql(this, CommandType.Text, db.ServiceProvider.Get<IParameterBuilder>().GetParameters(this));
                OnExecuted(db);
                return val;
            }
            else
            {
                return null;
            }
        }

        public bool TryExecute(Database db)
        {
            Exception ignore;
            return TryExecute(db, out ignore);
        }

        /// <summary>
        /// Tries to execute the script by wrapping a call to Execute
        /// in a try catch; will return true if no exception occurred.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public bool TryExecute(Database db, out Exception ex)
        {
            ex = null;
            try
            {
                Execute(db);
            }
            catch (Exception e)
            {
                ex = e;
            }

            return ex == null;
        }

        public void Execute(Database db)
        {
            if (!string.IsNullOrEmpty(this))
            {
                db.ExecuteSql(this, CommandType.Text, db.ServiceProvider.Get<IParameterBuilder>().GetParameters(this));
                OnExecuted(db);
            }
        }
		public virtual DataSet GetDataSet(Database db, bool releaseConnection = true, DbConnection conn = null, DbTransaction tx = null)
		{
			return GetDataSet<object>(db, releaseConnection, conn, tx);
		}

        public virtual DataSet GetDataSet<T>(Database db, bool releaseConnection = true, DbConnection conn = null, DbTransaction tx = null)
        {
            if (conn == null)
            {
                conn = db.GetDbConnection();
            }
			IParameterBuilder parameterBuilder;
			if(db.ServiceProvider.TryGet<IParameterBuilder>(out parameterBuilder))
			{
				DataSet ds = db.GetDataSetFromSql(this, CommandType.Text, releaseConnection, conn, tx, parameterBuilder.GetParameters(this));
				OnExecuted(db);
				return ds;
			}
			else
			{
				Args.Throw<InvalidOperationException>("Unable to get IParameterBuilder for the database with connection string ({0}), should you specify a Database instance of your own instead of depending on the default database initializer?  Be sure to call the appropriate Registrar method first", db.ConnectionString);
				return null;
			}
        }

        public IEnumerable<IFilterToken> Filters
        {
            get
            {
                return this.parameters.ToArray();
            }
        }
        
        public string GoText { get; set; }

        public int? NextNumber { get; set; }

        /// <summary>
        /// Appends GoText to the end of the current string
        /// </summary>
        /// <returns></returns>
        public virtual SqlStringBuilder Go()
        {
            _stringBuilder.Append(GoText);
            return this;
        }

        public virtual SqlStringBuilder Update(Dao instance)
        {
            return Update(instance.TableName(), instance.GetNewAssignValues());
        }

        public virtual SqlStringBuilder Update<T>(T instance) where T : Dao
        {
            return Update(Dao.TableName(instance), instance.GetNewAssignValues());
        }

        public virtual SqlStringBuilder Update(string tableName, params AssignValue[] values)
        {
			_stringBuilder.AppendFormat("UPDATE {0} ", TableNameFormatter(tableName));
            SetFormat set = new SetFormat();
            foreach (AssignValue value in values)
            {
                set.AddAssignment(value);
            }

            set.StartNumber = NextNumber;
            _stringBuilder.Append(set.Parse());
            NextNumber = set.NextNumber;
            this.parameters.AddRange(set.Parameters);
            return this;
        }

        public virtual SqlStringBuilder Insert<T>(T instance) where T : Dao, new()
        {
            return Insert(Dao.TableName(instance), instance.GetNewAssignValues());
        }

        public virtual SqlStringBuilder Insert(Dao instance)
        {
            return Insert(Dao.TableName(instance.GetType()), instance.GetNewAssignValues());
        }

        public virtual SqlStringBuilder Insert(string tableName, params AssignValue[] values)
        {
            _stringBuilder.AppendFormat("INSERT INTO {0} ", TableNameFormatter(tableName));
            InsertFormat insert = new InsertFormat();
            foreach (AssignValue value in values)
            {
                insert.AddAssignment(value);
            }

            insert.StartNumber = NextNumber;
            _stringBuilder.Append(insert.Parse());
            NextNumber = insert.NextNumber;
            this.parameters.AddRange(insert.Parameters);
            return this;
        }

        public virtual SqlStringBuilder Select<T>() where T: Dao, new()
        {
            return Select(Dao.TableName(typeof(T)), 
                ColumnAttribute.GetColumns(typeof(T)).ToDelimited(c => ColumnNameFormatter(c.Name)));
        }

        public virtual SqlStringBuilder Select<T>(params string[] columns)
        {
            List<string> goodColumns = ColumnAttribute.GetColumns(typeof(T)).Select(c => c.Name).ToList();
            foreach (string column in columns)
            {
                if (!goodColumns.Contains(column))
                {
					throw new InvalidOperationException(string.Format("Invalid column specified {0}", ColumnNameFormatter(column)));
                }
            }

            return Select(Dao.TableName(typeof(T)),
                columns.ToDelimited(c => ColumnNameFormatter(c)));
        }

        /// <summary>
        /// Select Top [topCount].  Same as SelectTop
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder Top<T>(int topCount) where T : Dao, new()
        {
            return SelectTop<T>(topCount);
        }

        /// <summary>
        /// Select Top [topCount].  Same as Top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public virtual SqlStringBuilder SelectTop<T>(int topCount) where T : Dao, new()
        {
            return SelectTop(topCount, Dao.TableName(typeof(T)),
				ColumnAttribute.GetColumns(typeof(T)).ToDelimited(c => ColumnNameFormatter(c.Name)));
        }

        public virtual SqlStringBuilder Select(string tableName, params string[] columnNames)
        {
            return SelectTop(-1, tableName, columnNames);
        }

        public virtual SqlStringBuilder SelectTop(int topCount, string tableName, params string[] columnNames)
        {
            if (columnNames.Length == 0)
            {
                columnNames = new string[] { "*" };
            }

            string top = string.Empty;
            if (topCount > 0)
            {
                top = string.Format(" TOP {0}", topCount);
            }
            string cols = columnNames.ToDelimited(s => string.Format("{0}", s));
            _stringBuilder.AppendFormat("SELECT {0}{1} FROM {2} ", top, cols, TableNameFormatter(tableName));
            return this;
        }

        public virtual SqlStringBuilder Count<T>() where T : Dao, new()
        {
            return SelectCount<T>();
        }

        public virtual SqlStringBuilder SelectCount<T>() where T : Dao, new()
        {
			//_stringBuilder.AppendFormat("SELECT COUNT(*) FROM {0} ", TableNameFormatter(Dao.TableName(typeof(T))));
            //return this;
			return SelectCount(Dao.TableName(typeof(T)));
        }

		public virtual SqlStringBuilder Count(string tableName)
		{
			return SelectCount(tableName);
		}

		public virtual SqlStringBuilder SelectCount(string tableName)
		{
			_stringBuilder.AppendFormat("SELECT COUNT(*) FROM {0} ", TableNameFormatter(tableName));
			return this;
		}

        public virtual SqlStringBuilder Delete(string tableName)
        {
			_stringBuilder.AppendFormat("DELETE FROM {0} ", TableNameFormatter(tableName));
            return this;
        }

        public SqlStringBuilder Where<C>(Func<C, IQueryFilter> where) where C : IQueryFilter, IFilterToken, new()
        {
            C columns = new C();
            IQueryFilter filter = where(columns);
            Where(filter);            
            return this;
        }

        public SqlStringBuilder OrderBy<C>(OrderBy<C> orderBy) where C : IQueryFilter, IFilterToken, new()
        {
            return OrderBy(orderBy.Column.ToString(), orderBy.SortOrder);
        }

        public virtual SqlStringBuilder Where(IQueryFilter filter)
        {
            WhereFormat where = new WhereFormat(filter);
            where.StartNumber = NextNumber;
            _stringBuilder.Append(where.Parse());
            NextNumber = where.NextNumber;
            this.parameters.AddRange(where.Parameters);
            return this;
        }


        public virtual SqlStringBuilder Where(AssignValue filter)
        {
            WhereFormat where = new WhereFormat();
            where.StartNumber = NextNumber;
            where.AddAssignment(filter);
            _stringBuilder.Append(where.Parse());
            NextNumber = where.NextNumber;
            this.parameters.AddRange(where.Parameters);
            return this;
        }

        public virtual SqlStringBuilder Id()
        {
            return Id("ID");
        }

        public virtual SqlStringBuilder Id(string idAs)
        {
            _stringBuilder.AppendFormat("{0}SELECT @@IDENTITY AS {1}", this.GoText, idAs);
            return this;
        }

        public IParameterInfo[] Parameters
        {
            get
            {
                return parameters.ToArray();
            }
            set
            {
                this.parameters.Clear();
                this.parameters.AddRange(value);
            }
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
		
		protected internal void OnExecuted(Database db)
		{
			if (Executed != null)
			{
				Executed(this, db);
			}
		}
		
		protected virtual SqlStringBuilder OrderBy(string columnName, SortOrder order = SortOrder.Ascending)
		{
			_stringBuilder.AppendFormat("ORDER BY {0} {1}", ColumnNameFormatter(columnName), GetSortOrder(order));
			return this;
		}

		protected string GetSortOrder(SortOrder order)
		{
			switch (order)
			{
				case SortOrder.Unspecified:
					return "ASC";
				case SortOrder.Descending:
					return "DESC";
				case SortOrder.Ascending:
					return "ASC";
				default:
					return "ASC";
			}
		}

		/// <summary>
		/// Contains the Sql statement thus far for this
		/// SqlStringBuilder, same as StringBuilder
		/// </summary>
		protected StringBuilder Builder
		{
			get
			{
				return _stringBuilder;
			}
			set
			{
				_stringBuilder = value;
			}
		}

		/// <summary>
		/// Contains the Sql statement thus far for this
		/// SqlStringBuilder, same as Builder
		/// </summary>
		protected StringBuilder StringBuilder
		{
			get
			{
				return this._stringBuilder;
			}
			set
			{
				_stringBuilder = value;
			}
		}

    }
}
