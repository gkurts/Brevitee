using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Incubation;
using Brevitee.Logging;
using System.Threading;
using System.Reflection;
using System.IO;

namespace Brevitee.Data
{
    public class Database
    {
        AutoResetEvent _resetEvent;
        List<DbConnection> _connections;
        public Database()
        {
			this._resetEvent = new AutoResetEvent(false);
			this._connections = new List<DbConnection>();
			this._schemaNames = new HashSet<string>();
            this.ServiceProvider = Incubator.Default;           
            this.MaxConnections = 25;
        }

        public Database(Incubator serviceProvider, string connectionString, string connectionName = null)
            : this()
        {
            this.ServiceProvider = serviceProvider;
            this.ConnectionString = connectionString;
            this.ConnectionName = connectionName;
			this.ParameterPrefix = "@";
        }

        public DaoTransaction BeginTransaction()
        {
            return Db.BeginTransaction(this);
        }

        public int MaxConnections { get; set; }

        public Incubator ServiceProvider { get; set; }

		public string ParameterPrefix { get; set; }
		/// <summary>
		/// Used to locate the connection string in the 
		/// configuration file as well as uniquely identify
		/// types that are associated with a specific 
		/// schema.  This is a legacy feature and may
		/// be deprecated in favor of using SchemaNames and
		/// TryEnsureSchema.
		/// </summary>
        public string ConnectionName { get; set; }

		HashSet<string> _schemaNames;
		public string[] SchemaNames
		{
			get
			{
				return _schemaNames.ToArray();
			}
		}

        public virtual string Name
        {
            get
            {
                DbConnectionStringBuilder cb = CreateConnectionStringBuilder();                
                cb.ConnectionString = this.ConnectionString;

                string databaseName = cb["Initial Catalog"] as string;

                if (string.IsNullOrEmpty(databaseName))
                {
                    databaseName = cb["Database"] as string;
                }

                if (string.IsNullOrEmpty(databaseName))
                {
                    databaseName = cb["Data Source"] as string;
                }

                if (string.IsNullOrEmpty(databaseName))
                {
                    throw new InvalidOperationException("Unable to determine database name from the connection string");
                }
                return databaseName;
            }
        }

        public Dictionary<EnumType, T> FillEnumDictionary<EnumType, T>(Dictionary<EnumType, T> dictionary, string nameColumn) where T : Dao, new()
        {
            QuerySet query = ExecuteQuery<T>();

            QueryResult result = ((QueryResult)query.Results[0]);
            if (result.DataTable.Rows.Count == 0)
            {
                InitEnumValues<EnumType, T>("Value", nameColumn);
                query = ExecuteQuery<T>();
                result = ((QueryResult)query.Results[0]);
            }

            foreach (DataRow row in result.DataTable.Rows)
            {
                EnumType enumVal = (EnumType)Enum.Parse(typeof(EnumType), (string)row[nameColumn]);
                T inst = new T();
                inst.DataRow = row;
                dictionary.AddMissing(enumVal, inst);
            }

            return dictionary;
        }

		public virtual Query<C, T> GetQuery<C, T>() 
			where C : IQueryFilter, IFilterToken, new()
			where T: Dao, new()
		{
			return new Query<C,T>();
		}

		public virtual Query<C, T> GetQuery<C, T>(WhereDelegate<C> where, OrderBy<C> orderBy = null)
			where C : IQueryFilter, IFilterToken, new()
			where T : Dao, new()
		{
			return new Query<C, T>(where, orderBy, this);
		}

		public virtual Query<C, T> GetQuery<C, T>(Func<C, QueryFilter<C>> where, OrderBy<C> orderBy = null)
			where C : IQueryFilter, IFilterToken, new()
			where T : Dao, new()
		{
			return new Query<C, T>(where, orderBy, this);
		}

		public virtual Query<C, T> GetQuery<C, T>(Delegate where)
			where C : IQueryFilter, IFilterToken, new()
			where T : Dao, new()
		{
			return new Query<C, T>(where, this);
		}

        /// <summary>
        /// Execute the specified SqlStringBuilder using the 
        /// specified generic type to determine which database
        /// to use.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        public virtual void ExecuteSql<T>(SqlStringBuilder builder) where T : Dao
        {
            Database db = Db.For<T>();
            ExecuteSql(builder, db.ServiceProvider.Get<IParameterBuilder>());
        }

        public virtual void ExecuteSql(SqlStringBuilder builder)
        {
            ExecuteSql(builder, ServiceProvider.Get<IParameterBuilder>());
        }

        public virtual void ExecuteSql(SqlStringBuilder builder, IParameterBuilder parameterBuilder)
        {
            ExecuteSql(builder, CommandType.Text, parameterBuilder.GetParameters(builder));
        }

        public virtual void ExecuteSql(string sqlStatement, CommandType commandType, params DbParameter[] dbParameters)
        {
            DbProviderFactory providerFactory = ServiceProvider.Get<DbProviderFactory>();
            DbConnection conn = GetDbConnection();
            try
            {
                conn.Open();
                DbCommand cmd = BuildCommand(sqlStatement, commandType, dbParameters, providerFactory, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(conn);
            }
        }
        
		public virtual DataRow GetFirstRowFromSql(string sqlStatement, CommandType commandType, params DbParameter[] dbParameters)
		{
			return GetDataTableFromSql(sqlStatement, commandType, dbParameters).Rows[0];
		}

		public virtual DataTable GetDataTableFromSql(string sqlStatement, CommandType commandType, params DbParameter[] dbParameters)
        {
            DbProviderFactory providerFactory = ServiceProvider.Get<DbProviderFactory>();
            DbConnection conn = GetDbConnection();
            DataTable table = new DataTable();
            try
            {
				DbCommand command = BuildCommand(sqlStatement, commandType, dbParameters, providerFactory, conn);
                FillTable(table, command);
            }
            finally
            {
                ReleaseConnection(conn);
            }

            return table;
        }

		public T GetServiceProver<T>()
		{
			return ServiceProvider.Get<T>();
		}

        public virtual DbCommand CreateCommand()
        {
            return ServiceProvider.Get<DbProviderFactory>().CreateCommand();
        }

        public virtual DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return ServiceProvider.Get<DbProviderFactory>().CreateConnectionStringBuilder();
        }

        public virtual DataSet GetDataSetFromSql(string sqlStatement, CommandType commandType, params DbParameter[] dbParamaters)
        {
            return GetDataSetFromSql(sqlStatement, commandType, true, dbParamaters);
        }

        public virtual DataSet GetDataSetFromSql(string sqlStatement, CommandType commandType, bool releaseConnection, params DbParameter[] dbParamaters)
        {
            DbConnection conn = GetDbConnection();
            return GetDataSetFromSql(sqlStatement, commandType, releaseConnection,  conn, dbParamaters);
        }

        public virtual DataSet GetDataSetFromSql(string sqlStatement, CommandType commandType, bool releaseConnection, DbConnection conn, params DbParameter[] dbParamaters)
        {
            return GetDataSetFromSql(sqlStatement, commandType, releaseConnection, conn, null, dbParamaters);
        }

		public virtual DataSet GetDataSetFromSql(string sqlStatement, CommandType commandType, bool releaseConnection, DbConnection conn, DbTransaction tx, params DbParameter[] dbParamaters)
		{
			return GetDataSetFromSql<object>(sqlStatement, commandType, releaseConnection, conn, tx, dbParamaters);
		}

        public virtual DataSet GetDataSetFromSql<T>(string sqlStatement, CommandType commandType, bool releaseConnection, DbConnection conn, DbTransaction tx, params DbParameter[] dbParamaters)
        {
            DbProviderFactory providerFactory = ServiceProvider.Get<DbProviderFactory>();

			DataSet set = new DataSet(Dao.ConnectionName<T>().Or(8.RandomLetters()));
            try
            {
                DbCommand command = BuildCommand(sqlStatement, commandType, dbParamaters, providerFactory, conn, tx);
                FillDataSet(set, command);
            }
            finally
            {
                if (releaseConnection)
                {
                    ReleaseConnection(conn);
                }
            }

            return set;
        }

		protected internal virtual AssignValue GetAssignment(string keyColumn, object value)
		{
			return new AssignValue(keyColumn, value);
		}

        internal static DbCommand BuildCommand(string sqlStatement, CommandType commandType, DbParameter[] dbParameters, DbProviderFactory providerFactory, DbConnection conn, DbTransaction tx  =null)
        {
            DbCommand command = providerFactory.CreateCommand();
            command.Connection = conn;
            if (tx != null)
            {
                command.Transaction = tx;
            }
            command.CommandText = sqlStatement;
            command.CommandType = commandType;
            command.CommandTimeout = 10000;            
            command.Parameters.AddRange(dbParameters);
            return command;
        }

        protected void FillTable(DataTable table, DbCommand command)
        {
            DbDataAdapter adapter = ServiceProvider.Get<DbProviderFactory>().CreateDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }

        protected void FillDataSet(DataSet dataSet, DbCommand command)
        {
            DbDataAdapter adapter = ServiceProvider.Get<DbProviderFactory>().CreateDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dataSet);
        }

        public virtual string ConnectionString
        {
            get;
            set;
        }

		public override bool Equals(object obj)
		{
			if (obj.GetType() == this.GetType() && 
				!string.IsNullOrEmpty(ConnectionString))
			{
				Database db = obj as Database;
				return db.ConnectionString.Equals(this.ConnectionString);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			if(!string.IsNullOrEmpty(ConnectionString))
			{
				return ConnectionString.GetHashCode();
			}
			else
			{
				return base.GetHashCode();
			}
		}

        public DbConnection GetDbConnection()
        {
            return GetDbConnection(this.MaxConnections);
        }

		public EnsureSchemaStatus TryEnsureSchema(Type type, ILogger logger = null)
		{
			Exception e;
			return TryEnsureSchema(type, out e, logger);
		}
		public EnsureSchemaStatus TryEnsureSchema(Type type, out Exception ex, ILogger logger = null)
		{
			return TryEnsureSchema(type, false, out ex, logger);
		}

		public virtual EnsureSchemaStatus TryEnsureSchema(Type type, bool force, out Exception ex, ILogger logger = null)
		{
			EnsureSchemaStatus result = EnsureSchemaStatus.Invalid;
			ex = null;
			try
			{
				string schemaName = Dao.RealConnectionName(type);
				if (!SchemaNames.Contains(schemaName) || force)
				{
					_schemaNames.Add(schemaName);
					SchemaWriter schema = ServiceProvider.Get<SchemaWriter>();
					schema.WriteSchemaScript(type);
					ExecuteSql(schema, ServiceProvider.Get<IParameterBuilder>());					
					result = EnsureSchemaStatus.Success;
				}
				else
				{
					result = EnsureSchemaStatus.AlreadyDone;
				}
			}
			catch (Exception e)
			{
				ex = e;
				result = EnsureSchemaStatus.Error;
				logger = logger ?? Log.Default;
				logger.AddEntry("Non fatal error occurred trying to write schema for type {0}: {1}", LogEventType.Warning, ex, type.Name, ex.Message);
			}
			return result;
		}

		Func<ColumnAttribute, string> _columnNameProvider;
		protected internal virtual Func<ColumnAttribute, string> ColumnNameProvider
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

        object connectionLock = new object();
        protected void ReleaseConnection(DbConnection conn)
        {
            try
            {
                lock (connectionLock)
                {
                    if (_connections.Contains(conn))
                    {
                        _connections.Remove(conn);
                    }

                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            catch //(Exception ex)
            {
                // do nothing
            }

            _resetEvent.Set();
        }
		
		private QuerySet ExecuteQuery<T>() where T : Dao, new()
		{
			QuerySet query = new QuerySet();
			query.Select<T>();
			query.Execute(this);
			return query;
		}

		static object initEnumLock = new object();
		private void InitEnumValues<EnumType, T>(string valueColumn, string nameColumn) where T : Dao, new()
		{
			FieldInfo[] fields = typeof(EnumType).GetFields(BindingFlags.Public | BindingFlags.Static);
			foreach (FieldInfo field in fields)
			{
				T entry = new T();
				entry.SetValue(valueColumn, field.GetRawConstantValue());
				entry.SetValue(nameColumn, field.Name);
				entry.Save();
			}
		}

		private DbConnection GetDbConnection(int max)
		{
			if (_connections.Count >= max)
			{
				_resetEvent.WaitOne();
			}

			DbConnection conn = ServiceProvider.Get<DbProviderFactory>().CreateConnection();
			conn.ConnectionString = this.ConnectionString;
			lock (connectionLock)
			{
				_connections.Add(conn);
			}
			return conn;
		}
    }
}
