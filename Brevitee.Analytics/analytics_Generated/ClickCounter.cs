// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Analytics
{
	// schema = Analytics
	// connection Name = Analytics
	[Serializable]
	[Brevitee.Data.Table("ClickCounter", "Analytics")]
	public partial class ClickCounter: Dao
	{
		public ClickCounter():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ClickCounter(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ClickCounter(DataRow data)
		{
			return new ClickCounter(data);
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

﻿	// property:UrlId, columnName:UrlId	
	[Brevitee.Data.Column(Name="UrlId", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? UrlId
	{
		get
		{
			return GetIntValue("UrlId");
		}
		set
		{
			SetValue("UrlId", value);
		}
	}



﻿	// start CounterId -> CounterId
	[Brevitee.Data.ForeignKey(
        Table="ClickCounter",
		Name="CounterId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Counter",
		Suffix="1")]
	public long? CounterId
	{
		get
		{
			return GetLongValue("CounterId");
		}
		set
		{
			SetValue("CounterId", value);
		}
	}

	Counter _counterOfCounterId;
	public Counter CounterOfCounterId
	{
		get
		{
			if(_counterOfCounterId == null)
			{
				_counterOfCounterId = Brevitee.Analytics.Counter.OneWhere(c => c.KeyColumn == this.CounterId);
			}
			return _counterOfCounterId;
		}
	}
	
﻿	// start UserIdentifierId -> UserIdentifierId
	[Brevitee.Data.ForeignKey(
        Table="ClickCounter",
		Name="UserIdentifierId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="UserIdentifier",
		Suffix="2")]
	public long? UserIdentifierId
	{
		get
		{
			return GetLongValue("UserIdentifierId");
		}
		set
		{
			SetValue("UserIdentifierId", value);
		}
	}

	UserIdentifier _userIdentifierOfUserIdentifierId;
	public UserIdentifier UserIdentifierOfUserIdentifierId
	{
		get
		{
			if(_userIdentifierOfUserIdentifierId == null)
			{
				_userIdentifierOfUserIdentifierId = Brevitee.Analytics.UserIdentifier.OneWhere(c => c.KeyColumn == this.UserIdentifierId);
			}
			return _userIdentifierOfUserIdentifierId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new ClickCounterColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ClickCounter table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ClickCounterCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ClickCounter>();
			Database db = database ?? Db.For<ClickCounter>();
			var results = new ClickCounterCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ClickCounter GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ClickCounter GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ClickCounterCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ClickCounterCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ClickCounterColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ClickCounterColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ClickCounterCollection Where(Func<ClickCounterColumns, QueryFilter<ClickCounterColumns>> where, OrderBy<ClickCounterColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ClickCounter>();
			return new ClickCounterCollection(database.GetQuery<ClickCounterColumns, ClickCounter>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ClickCounterCollection Where(WhereDelegate<ClickCounterColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ClickCounter>();
			var results = new ClickCounterCollection(database, database.GetQuery<ClickCounterColumns, ClickCounter>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ClickCounterCollection Where(WhereDelegate<ClickCounterColumns> where, OrderBy<ClickCounterColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ClickCounter>();
			var results = new ClickCounterCollection(database, database.GetQuery<ClickCounterColumns, ClickCounter>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ClickCounterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ClickCounterCollection Where(QiQuery where, Database database = null)
		{
			var results = new ClickCounterCollection(database, Select<ClickCounterColumns>.From<ClickCounter>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ClickCounter GetOneWhere(QueryFilter where, Database database = null)
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
		public static ClickCounter OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ClickCounterColumns> whereDelegate = (c) => where;
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
		public static ClickCounter GetOneWhere(WhereDelegate<ClickCounterColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ClickCounterColumns c = new ClickCounterColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ClickCounter instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ClickCounter OneWhere(WhereDelegate<ClickCounterColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ClickCounterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ClickCounter OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ClickCounter FirstOneWhere(WhereDelegate<ClickCounterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ClickCounter FirstOneWhere(WhereDelegate<ClickCounterColumns> where, OrderBy<ClickCounterColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ClickCounter FirstOneWhere(QueryFilter where, OrderBy<ClickCounterColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ClickCounterColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ClickCounterCollection Top(int count, WhereDelegate<ClickCounterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ClickCounterCollection Top(int count, WhereDelegate<ClickCounterColumns> where, OrderBy<ClickCounterColumns> orderBy, Database database = null)
		{
			ClickCounterColumns c = new ClickCounterColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ClickCounter>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ClickCounter>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ClickCounterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ClickCounterCollection>(0);
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
		public static ClickCounterCollection Top(int count, QueryFilter where, OrderBy<ClickCounterColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ClickCounter>();
			QuerySet query = GetQuerySet(db);
			query.Top<ClickCounter>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ClickCounterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ClickCounterCollection>(0);
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
		public static ClickCounterCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ClickCounter>();
			QuerySet query = GetQuerySet(db);
			query.Top<ClickCounter>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ClickCounterCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ClickCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ClickCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ClickCounterColumns> where, Database database = null)
		{
			ClickCounterColumns c = new ClickCounterColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ClickCounter>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ClickCounter>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ClickCounter CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ClickCounter>();			
			var dao = new ClickCounter();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ClickCounter OneOrThrow(ClickCounterCollection c)
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
