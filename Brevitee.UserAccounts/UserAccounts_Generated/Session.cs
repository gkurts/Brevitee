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
	[Brevitee.Data.Table("Session", "UserAccounts")]
	public partial class Session: Dao
	{
		public Session():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Session(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Session(DataRow data)
		{
			return new Session(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("SessionState_SessionId", new SessionStateCollection(Database.GetQuery<SessionStateColumns, SessionState>((c) => c.SessionId == this.Id), this, "SessionId"));	﻿
            this.ChildCollections.Add("UserBehavior_SessionId", new UserBehaviorCollection(Database.GetQuery<UserBehaviorColumns, UserBehavior>((c) => c.SessionId == this.Id), this, "SessionId"));							
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

﻿	// property:Identifier, columnName:Identifier	
	[Brevitee.Data.Column(Name="Identifier", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Identifier
	{
		get
		{
			return GetStringValue("Identifier");
		}
		set
		{
			SetValue("Identifier", value);
		}
	}

﻿	// property:CreationDate, columnName:CreationDate	
	[Brevitee.Data.Column(Name="CreationDate", DbDataType="DateTime", MaxLength="8", AllowNull=true)]
	public DateTime? CreationDate
	{
		get
		{
			return GetDateTimeValue("CreationDate");
		}
		set
		{
			SetValue("CreationDate", value);
		}
	}

﻿	// property:LastActivity, columnName:LastActivity	
	[Brevitee.Data.Column(Name="LastActivity", DbDataType="DateTime", MaxLength="8", AllowNull=true)]
	public DateTime? LastActivity
	{
		get
		{
			return GetDateTimeValue("LastActivity");
		}
		set
		{
			SetValue("LastActivity", value);
		}
	}

﻿	// property:IsActive, columnName:IsActive	
	[Brevitee.Data.Column(Name="IsActive", DbDataType="Bit", MaxLength="1", AllowNull=true)]
	public bool? IsActive
	{
		get
		{
			return GetBooleanValue("IsActive");
		}
		set
		{
			SetValue("IsActive", value);
		}
	}



﻿	// start UserId -> UserId
	[Brevitee.Data.ForeignKey(
        Table="Session",
		Name="UserId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="User",
		Suffix="1")]
	public long? UserId
	{
		get
		{
			return GetLongValue("UserId");
		}
		set
		{
			SetValue("UserId", value);
		}
	}

	User _userOfUserId;
	public User UserOfUserId
	{
		get
		{
			if(_userOfUserId == null)
			{
				_userOfUserId = Brevitee.UserAccounts.Data.User.OneWhere(c => c.KeyColumn == this.UserId);
			}
			return _userOfUserId;
		}
	}
	
				
﻿
	[Exclude]	
	public SessionStateCollection SessionStatesBySessionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("SessionState_SessionId"))
			{
				SetChildren();
			}

			var c = (SessionStateCollection)this.ChildCollections["SessionState_SessionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public UserBehaviorCollection UserBehaviorsBySessionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("UserBehavior_SessionId"))
			{
				SetChildren();
			}

			var c = (UserBehaviorCollection)this.ChildCollections["UserBehavior_SessionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new SessionColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Session table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SessionCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Session>();
			Database db = database ?? Db.For<Session>();
			var results = new SessionCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Session GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Session GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SessionCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SessionCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SessionColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SessionColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SessionCollection Where(Func<SessionColumns, QueryFilter<SessionColumns>> where, OrderBy<SessionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Session>();
			return new SessionCollection(database.GetQuery<SessionColumns, Session>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SessionCollection Where(WhereDelegate<SessionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Session>();
			var results = new SessionCollection(database, database.GetQuery<SessionColumns, Session>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SessionCollection Where(WhereDelegate<SessionColumns> where, OrderBy<SessionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Session>();
			var results = new SessionCollection(database, database.GetQuery<SessionColumns, Session>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SessionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SessionCollection Where(QiQuery where, Database database = null)
		{
			var results = new SessionCollection(database, Select<SessionColumns>.From<Session>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Session GetOneWhere(QueryFilter where, Database database = null)
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
		public static Session OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SessionColumns> whereDelegate = (c) => where;
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
		public static Session GetOneWhere(WhereDelegate<SessionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SessionColumns c = new SessionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Session instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Session OneWhere(WhereDelegate<SessionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SessionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Session OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Session FirstOneWhere(WhereDelegate<SessionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Session FirstOneWhere(WhereDelegate<SessionColumns> where, OrderBy<SessionColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Session FirstOneWhere(QueryFilter where, OrderBy<SessionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SessionColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SessionCollection Top(int count, WhereDelegate<SessionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SessionCollection Top(int count, WhereDelegate<SessionColumns> where, OrderBy<SessionColumns> orderBy, Database database = null)
		{
			SessionColumns c = new SessionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Session>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Session>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SessionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SessionCollection>(0);
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
		public static SessionCollection Top(int count, QueryFilter where, OrderBy<SessionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Session>();
			QuerySet query = GetQuerySet(db);
			query.Top<Session>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SessionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SessionCollection>(0);
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
		public static SessionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Session>();
			QuerySet query = GetQuerySet(db);
			query.Top<Session>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SessionCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SessionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SessionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SessionColumns> where, Database database = null)
		{
			SessionColumns c = new SessionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Session>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Session>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Session CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Session>();			
			var dao = new Session();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Session OneOrThrow(SessionCollection c)
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
