// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Logging.Data
{
	// schema = DaoLogger
	// connection Name = DaoLogger
	[Serializable]
	[Brevitee.Data.Table("LogEvent", "DaoLogger")]
	public partial class LogEvent: Dao
	{
		public LogEvent():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public LogEvent(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator LogEvent(DataRow data)
		{
			return new LogEvent(data);
		}

		private void SetChildren()
		{
						
		}

﻿	// property:Id, columnName:Id	
	[Exclude]
	[Brevitee.Data.KeyColumn(Name="Id", DbDataType="BigInt", MaxLength="19")]
	public long? Id
	{
		get
		{
			return GetLongValue("Id");
		}
		set
		{
			SetValue("Id", value);
		}
	}

﻿	// property:Uuid, columnName:Uuid	
	[Brevitee.Data.Column(Name="Uuid", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Uuid
	{
		get
		{
			return GetStringValue("Uuid");
		}
		set
		{
			SetValue("Uuid", value);
		}
	}

﻿	// property:Source, columnName:Source	
	[Brevitee.Data.Column(Name="Source", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Source
	{
		get
		{
			return GetStringValue("Source");
		}
		set
		{
			SetValue("Source", value);
		}
	}

﻿	// property:Category, columnName:Category	
	[Brevitee.Data.Column(Name="Category", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Category
	{
		get
		{
			return GetStringValue("Category");
		}
		set
		{
			SetValue("Category", value);
		}
	}

﻿	// property:EventId, columnName:EventId	
	[Brevitee.Data.Column(Name="EventId", DbDataType="Int", MaxLength="10", AllowNull=true)]
	public int? EventId
	{
		get
		{
			return GetIntValue("EventId");
		}
		set
		{
			SetValue("EventId", value);
		}
	}

﻿	// property:User, columnName:User	
	[Brevitee.Data.Column(Name="User", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string User
	{
		get
		{
			return GetStringValue("User");
		}
		set
		{
			SetValue("User", value);
		}
	}

﻿	// property:Time, columnName:Time	
	[Brevitee.Data.Column(Name="Time", DbDataType="DateTime", MaxLength="8", AllowNull=true)]
	public DateTime? Time
	{
		get
		{
			return GetDateTimeValue("Time");
		}
		set
		{
			SetValue("Time", value);
		}
	}

﻿	// property:MessageSignature, columnName:MessageSignature	
	[Brevitee.Data.Column(Name="MessageSignature", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string MessageSignature
	{
		get
		{
			return GetStringValue("MessageSignature");
		}
		set
		{
			SetValue("MessageSignature", value);
		}
	}

﻿	// property:MessageVariableValues, columnName:MessageVariableValues	
	[Brevitee.Data.Column(Name="MessageVariableValues", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string MessageVariableValues
	{
		get
		{
			return GetStringValue("MessageVariableValues");
		}
		set
		{
			SetValue("MessageVariableValues", value);
		}
	}

﻿	// property:Message, columnName:Message	
	[Brevitee.Data.Column(Name="Message", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Message
	{
		get
		{
			return GetStringValue("Message");
		}
		set
		{
			SetValue("Message", value);
		}
	}

﻿	// property:Computer, columnName:Computer	
	[Brevitee.Data.Column(Name="Computer", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Computer
	{
		get
		{
			return GetStringValue("Computer");
		}
		set
		{
			SetValue("Computer", value);
		}
	}

﻿	// property:Severity, columnName:Severity	
	[Brevitee.Data.Column(Name="Severity", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Severity
	{
		get
		{
			return GetStringValue("Severity");
		}
		set
		{
			SetValue("Severity", value);
		}
	}



				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new LogEventColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the LogEvent table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static LogEventCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<LogEvent>();
			Database db = database ?? Db.For<LogEvent>();
			var results = new LogEventCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static LogEvent GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static LogEvent GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static LogEventCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static LogEventCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<LogEventColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a LogEventColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LogEventCollection Where(Func<LogEventColumns, QueryFilter<LogEventColumns>> where, OrderBy<LogEventColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<LogEvent>();
			return new LogEventCollection(database.GetQuery<LogEventColumns, LogEvent>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LogEventCollection Where(WhereDelegate<LogEventColumns> where, Database database = null)
		{		
			database = database ?? Db.For<LogEvent>();
			var results = new LogEventCollection(database, database.GetQuery<LogEventColumns, LogEvent>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LogEventCollection Where(WhereDelegate<LogEventColumns> where, OrderBy<LogEventColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<LogEvent>();
			var results = new LogEventCollection(database, database.GetQuery<LogEventColumns, LogEvent>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<LogEventColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LogEventCollection Where(QiQuery where, Database database = null)
		{
			var results = new LogEventCollection(database, Select<LogEventColumns>.From<LogEvent>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static LogEvent GetOneWhere(QueryFilter where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				result = CreateFromFilter(where, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LogEvent OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<LogEventColumns> whereDelegate = (c) => where;
			var result = Top(1, whereDelegate, database);
			return OneOrThrow(result);
		}

		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LogEvent GetOneWhere(WhereDelegate<LogEventColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				LogEventColumns c = new LogEventColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single LogEvent instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LogEvent OneWhere(WhereDelegate<LogEventColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<LogEventColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LogEvent OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LogEvent FirstOneWhere(WhereDelegate<LogEventColumns> where, Database database = null)
		{
			var results = Top(1, where, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LogEvent FirstOneWhere(WhereDelegate<LogEventColumns> where, OrderBy<LogEventColumns> orderBy, Database database = null)
		{
			var results = Top(1, where, orderBy, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Shortcut for Top(1, where, orderBy, database)
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LogEvent FirstOneWhere(QueryFilter where, OrderBy<LogEventColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<LogEventColumns> whereDelegate = (c) => where;
			var results = Top(1, whereDelegate, orderBy, database);
			if(results.Count > 0)
			{
				return results[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Execute a query and return the specified number
		/// of values. This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LogEventCollection Top(int count, WhereDelegate<LogEventColumns> where, Database database = null)
		{
			return Top(count, where, null, database);
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LogEventCollection Top(int count, WhereDelegate<LogEventColumns> where, OrderBy<LogEventColumns> orderBy, Database database = null)
		{
			LogEventColumns c = new LogEventColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<LogEvent>();
			QuerySet query = GetQuerySet(db); 
			query.Top<LogEvent>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<LogEventColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LogEventCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A QueryFilter used to filter the 
		/// results
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="db"></param>
		public static LogEventCollection Top(int count, QueryFilter where, OrderBy<LogEventColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<LogEvent>();
			QuerySet query = GetQuerySet(db);
			query.Top<LogEvent>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<LogEventColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LogEventCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the specified number of values.  This method
		/// will issue a sql TOP clause so only the specified number of values
		/// will be returned.
		/// of values
		/// </summary>
		/// <param name="count">The number of values to return.
		/// This value is used in the sql query so no more than this 
		/// number of values will be returned by the database.
		/// </param>
		/// <param name="where">A QueryFilter used to filter the 
		/// results
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="db"></param>
		public static LogEventCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<LogEvent>();
			QuerySet query = GetQuerySet(db);
			query.Top<LogEvent>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<LogEventCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LogEventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LogEventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<LogEventColumns> where, Database database = null)
		{
			LogEventColumns c = new LogEventColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<LogEvent>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<LogEvent>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static LogEvent CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<LogEvent>();			
			var dao = new LogEvent();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static LogEvent OneOrThrow(LogEventCollection c)
		{
			if(c.Count == 1)
			{
				return c[0];
			}
			else if(c.Count > 1)
			{
				throw new MultipleEntriesFoundException();
			}

			return null;
		}

	}
}																								
