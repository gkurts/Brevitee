// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.UserAccounts.Data
{
	// schema = UserAccounts
	// connection Name = UserAccounts
	[Serializable]
	[Brevitee.Data.Table("UserBehavior", "UserAccounts")]
	public partial class UserBehavior: Dao
	{
		public UserBehavior():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public UserBehavior(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator UserBehavior(DataRow data)
		{
			return new UserBehavior(data);
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

﻿	// property:DateTime, columnName:DateTime	
	[Brevitee.Data.Column(Name="DateTime", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? DateTime
	{
		get
		{
			return GetDateTimeValue("DateTime");
		}
		set
		{
			SetValue("DateTime", value);
		}
	}

﻿	// property:Selector, columnName:Selector	
	[Brevitee.Data.Column(Name="Selector", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Selector
	{
		get
		{
			return GetStringValue("Selector");
		}
		set
		{
			SetValue("Selector", value);
		}
	}

﻿	// property:EventName, columnName:EventName	
	[Brevitee.Data.Column(Name="EventName", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string EventName
	{
		get
		{
			return GetStringValue("EventName");
		}
		set
		{
			SetValue("EventName", value);
		}
	}

﻿	// property:Data, columnName:Data	
	[Brevitee.Data.Column(Name="Data", DbDataType="VarBinary", MaxLength="8000", AllowNull=true)]
	public byte[] Data
	{
		get
		{
			return GetByteValue("Data");
		}
		set
		{
			SetValue("Data", value);
		}
	}

﻿	// property:Url, columnName:Url	
	[Brevitee.Data.Column(Name="Url", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Url
	{
		get
		{
			return GetStringValue("Url");
		}
		set
		{
			SetValue("Url", value);
		}
	}



﻿	// start SessionId -> SessionId
	[Brevitee.Data.ForeignKey(
        Table="UserBehavior",
		Name="SessionId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Session",
		Suffix="1")]
	public long? SessionId
	{
		get
		{
			return GetLongValue("SessionId");
		}
		set
		{
			SetValue("SessionId", value);
		}
	}

	Session _sessionOfSessionId;
	public Session SessionOfSessionId
	{
		get
		{
			if(_sessionOfSessionId == null)
			{
				_sessionOfSessionId = Brevitee.UserAccounts.Data.Session.OneWhere(c => c.KeyColumn == this.SessionId);
			}
			return _sessionOfSessionId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new UserBehaviorColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the UserBehavior table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static UserBehaviorCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<UserBehavior>();
			Database db = database ?? Db.For<UserBehavior>();
			var results = new UserBehaviorCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static UserBehavior GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static UserBehavior GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static UserBehaviorCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static UserBehaviorCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<UserBehaviorColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a UserBehaviorColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static UserBehaviorCollection Where(Func<UserBehaviorColumns, QueryFilter<UserBehaviorColumns>> where, OrderBy<UserBehaviorColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<UserBehavior>();
			return new UserBehaviorCollection(database.GetQuery<UserBehaviorColumns, UserBehavior>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static UserBehaviorCollection Where(WhereDelegate<UserBehaviorColumns> where, Database database = null)
		{		
			database = database ?? Db.For<UserBehavior>();
			var results = new UserBehaviorCollection(database, database.GetQuery<UserBehaviorColumns, UserBehavior>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static UserBehaviorCollection Where(WhereDelegate<UserBehaviorColumns> where, OrderBy<UserBehaviorColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<UserBehavior>();
			var results = new UserBehaviorCollection(database, database.GetQuery<UserBehaviorColumns, UserBehavior>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<UserBehaviorColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static UserBehaviorCollection Where(QiQuery where, Database database = null)
		{
			var results = new UserBehaviorCollection(database, Select<UserBehaviorColumns>.From<UserBehavior>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static UserBehavior GetOneWhere(QueryFilter where, Database database = null)
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
		public static UserBehavior OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<UserBehaviorColumns> whereDelegate = (c) => where;
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
		public static UserBehavior GetOneWhere(WhereDelegate<UserBehaviorColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				UserBehaviorColumns c = new UserBehaviorColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single UserBehavior instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UserBehavior OneWhere(WhereDelegate<UserBehaviorColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<UserBehaviorColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static UserBehavior OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UserBehavior FirstOneWhere(WhereDelegate<UserBehaviorColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UserBehavior FirstOneWhere(WhereDelegate<UserBehaviorColumns> where, OrderBy<UserBehaviorColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UserBehavior FirstOneWhere(QueryFilter where, OrderBy<UserBehaviorColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<UserBehaviorColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UserBehaviorCollection Top(int count, WhereDelegate<UserBehaviorColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static UserBehaviorCollection Top(int count, WhereDelegate<UserBehaviorColumns> where, OrderBy<UserBehaviorColumns> orderBy, Database database = null)
		{
			UserBehaviorColumns c = new UserBehaviorColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<UserBehavior>();
			QuerySet query = GetQuerySet(db); 
			query.Top<UserBehavior>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<UserBehaviorColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<UserBehaviorCollection>(0);
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
		public static UserBehaviorCollection Top(int count, QueryFilter where, OrderBy<UserBehaviorColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<UserBehavior>();
			QuerySet query = GetQuerySet(db);
			query.Top<UserBehavior>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<UserBehaviorColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<UserBehaviorCollection>(0);
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
		public static UserBehaviorCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<UserBehavior>();
			QuerySet query = GetQuerySet(db);
			query.Top<UserBehavior>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<UserBehaviorCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UserBehaviorColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UserBehaviorColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<UserBehaviorColumns> where, Database database = null)
		{
			UserBehaviorColumns c = new UserBehaviorColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<UserBehavior>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<UserBehavior>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static UserBehavior CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<UserBehavior>();			
			var dao = new UserBehavior();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static UserBehavior OneOrThrow(UserBehaviorCollection c)
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
