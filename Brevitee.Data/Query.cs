using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Data;
using System.Data;
using System.Data.Common;

namespace Brevitee.Data
{
	public static class Query
	{
		public static QueryFilter Where(string columnName)
		{
			return new QueryFilter(columnName);
		}
	}

    /// <summary>
    /// Convenience class for queries
    /// </summary>
    /// <typeparam name="C">The type defining column names</typeparam>
    /// <typeparam name="T">The matching table type T for columns C</typeparam>
    public class Query<C, T> 
        where C : IQueryFilter, IFilterToken, new()
        where T: Dao, new()
    {
        public Query() { }
        public Query(WhereDelegate<C> where, OrderBy<C> orderBy = null, Database db = null)
        {
            this.FilterDelegate = where;
            this.OrderBy = orderBy;
            this.Database = db;
        }

        public Query(Func<C, QueryFilter<C>> where, OrderBy<C> orderBy = null, Database db = null)
        {
            this.FilterDelegate = where;
            this.OrderBy = orderBy;
            this.Database = db;
        }

        public Query(Delegate where, Database db = null)
        {
            this.FilterDelegate = where;
            this.Database = db;
        }

		Func<ColumnAttribute, string> _columnNameProvider;
		public Func<ColumnAttribute, string> ColumnNameProvider
		{
			get
			{
				if (_columnNameProvider == null)
				{
					_columnNameProvider = (c) =>
					{
						return string.Format("[{0}]", c.Name);
					};
				}

				return _columnNameProvider;
			}
			set
			{
				_columnNameProvider = value;
			}
		}
        protected internal Delegate FilterDelegate
        {
            get;
            set;
        }

        protected internal OrderBy<C> OrderBy
        {
            get;
            set;
        }

        protected internal Database Database
        {
            get;
            set;
        }

        public DataTable Where(WhereDelegate<C> where, Database db = null)
        {
            return Where(where, null, db);
        }

        public DataTable Where(Func<C, QueryFilter<C>> where, OrderBy<C> orderBy = null, Database db = null)
        {  
            Establish(where, orderBy, db);
            SqlStringBuilder sql = GetFilteredQuery(db);
            db = EstablishOrderAndDb(orderBy, db, sql);

            return GetDataTable(db, sql);
        }
		
        public DataTable Where(WhereDelegate<C> where, OrderBy<C> orderBy = null, Database db = null)
        {
            Establish(where, orderBy, db);
            SqlStringBuilder sql = GetFilteredQuery(db);
            db = EstablishOrderAndDb(orderBy, db, sql);

            return GetDataTable(db, sql);
        }

        public DataTable Where(Qi.QiQuery query, Database db = null)
        {
            SqlStringBuilder sql = new SqlStringBuilder();
            if (query.limit > 0)
            {
                sql.SelectTop(query.limit, query.table, query.columns).Where(query);
            }
            else
            {
                sql.Select(query.table, query.columns).Where(query);
            }
            
            if (db == null)
            {
                db = Db.For(query.cxName);
            }

            return GetDataTable(db, sql);
        }
        public DataTable GetDataTable()
        {
            return GetDataTable(Database);
        }

        public DataTable GetDataTable(Database database)
        {
            SqlStringBuilder sql = GetFilteredQuery(database);
            Database db = EstablishOrderAndDb(OrderBy, database, sql);
            return GetDataTable(db, sql);
        }

        private Database EstablishOrderAndDb(OrderBy<C> orderBy, Database db, SqlStringBuilder sql)
        {
            if (orderBy != null)
            {
                OrderBy = orderBy;
                sql.OrderBy(orderBy);
            }

            if (db == null)
            {
                db = Db.For<T>();
                Database = db;
            }
            return db;
        }
        
        private void Establish(Delegate where, OrderBy<C> orderBy = null, Database db = null)
        {
			db = db ?? Db.For<T>();
            this.FilterDelegate = where;
            this.OrderBy = orderBy;
            this.Database = db;
        }

        private SqlStringBuilder GetFilteredQuery(Database db)
        {
            if (FilterDelegate == null)
            {
                throw new ArgumentNullException("FilterDelegate was not set");
            }
			
			db = db ?? Db.For<T>();
            C columns = new C();
            IQueryFilter queryFilter = (IQueryFilter)FilterDelegate.DynamicInvoke(columns);
            return GetSqlStringBuilder(db).Where(queryFilter);
        }

        private static DataTable GetDataTable(Database db, SqlStringBuilder sql)
        {
			db = db ?? Db.For<T>();
            IParameterBuilder parameterBuilder = db.ServiceProvider.Get<IParameterBuilder>();
            DbParameter[] parameters = parameterBuilder.GetParameters(sql);
            return db.GetDataTableFromSql(sql, System.Data.CommandType.Text, parameters);
        }

        private SqlStringBuilder GetSqlStringBuilder(Database db)
        {
			db = db ?? Db.For<T>();
			SqlStringBuilder sql = db == null ? new SqlStringBuilder(): db.ServiceProvider.Get<SqlStringBuilder>();
            sql.Select(Dao.TableName(typeof(T)), ColumnAttribute.GetColumns(typeof(T)).ToDelimited(c => db.ColumnNameProvider(c)));
            return sql;
        }

    }
}
