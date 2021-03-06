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
	[Brevitee.Data.Table("MethodTimer", "Analytics")]
	public partial class MethodTimer: Dao
	{
		public MethodTimer():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public MethodTimer(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator MethodTimer(DataRow data)
		{
			return new MethodTimer(data);
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

﻿	// property:MethodName, columnName:MethodName	
	[Brevitee.Data.Column(Name="MethodName", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string MethodName
	{
		get
		{
			return GetStringValue("MethodName");
		}
		set
		{
			SetValue("MethodName", value);
		}
	}



﻿	// start TimerId -> TimerId
	[Brevitee.Data.ForeignKey(
        Table="MethodTimer",
		Name="TimerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Timer",
		Suffix="1")]
	public long? TimerId
	{
		get
		{
			return GetLongValue("TimerId");
		}
		set
		{
			SetValue("TimerId", value);
		}
	}

	Timer _timerOfTimerId;
	public Timer TimerOfTimerId
	{
		get
		{
			if(_timerOfTimerId == null)
			{
				_timerOfTimerId = Brevitee.Analytics.Timer.OneWhere(c => c.KeyColumn == this.TimerId);
			}
			return _timerOfTimerId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new MethodTimerColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the MethodTimer table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static MethodTimerCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<MethodTimer>();
			Database db = database ?? Db.For<MethodTimer>();
			var results = new MethodTimerCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static MethodTimer GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static MethodTimer GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static MethodTimerCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static MethodTimerCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<MethodTimerColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a MethodTimerColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static MethodTimerCollection Where(Func<MethodTimerColumns, QueryFilter<MethodTimerColumns>> where, OrderBy<MethodTimerColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<MethodTimer>();
			return new MethodTimerCollection(database.GetQuery<MethodTimerColumns, MethodTimer>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static MethodTimerCollection Where(WhereDelegate<MethodTimerColumns> where, Database database = null)
		{		
			database = database ?? Db.For<MethodTimer>();
			var results = new MethodTimerCollection(database, database.GetQuery<MethodTimerColumns, MethodTimer>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static MethodTimerCollection Where(WhereDelegate<MethodTimerColumns> where, OrderBy<MethodTimerColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<MethodTimer>();
			var results = new MethodTimerCollection(database, database.GetQuery<MethodTimerColumns, MethodTimer>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<MethodTimerColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static MethodTimerCollection Where(QiQuery where, Database database = null)
		{
			var results = new MethodTimerCollection(database, Select<MethodTimerColumns>.From<MethodTimer>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static MethodTimer GetOneWhere(QueryFilter where, Database database = null)
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
		public static MethodTimer OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<MethodTimerColumns> whereDelegate = (c) => where;
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
		public static MethodTimer GetOneWhere(WhereDelegate<MethodTimerColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				MethodTimerColumns c = new MethodTimerColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single MethodTimer instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static MethodTimer OneWhere(WhereDelegate<MethodTimerColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<MethodTimerColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static MethodTimer OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static MethodTimer FirstOneWhere(WhereDelegate<MethodTimerColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static MethodTimer FirstOneWhere(WhereDelegate<MethodTimerColumns> where, OrderBy<MethodTimerColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static MethodTimer FirstOneWhere(QueryFilter where, OrderBy<MethodTimerColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<MethodTimerColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static MethodTimerCollection Top(int count, WhereDelegate<MethodTimerColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static MethodTimerCollection Top(int count, WhereDelegate<MethodTimerColumns> where, OrderBy<MethodTimerColumns> orderBy, Database database = null)
		{
			MethodTimerColumns c = new MethodTimerColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<MethodTimer>();
			QuerySet query = GetQuerySet(db); 
			query.Top<MethodTimer>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<MethodTimerColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<MethodTimerCollection>(0);
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
		public static MethodTimerCollection Top(int count, QueryFilter where, OrderBy<MethodTimerColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<MethodTimer>();
			QuerySet query = GetQuerySet(db);
			query.Top<MethodTimer>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<MethodTimerColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<MethodTimerCollection>(0);
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
		public static MethodTimerCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<MethodTimer>();
			QuerySet query = GetQuerySet(db);
			query.Top<MethodTimer>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<MethodTimerCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a MethodTimerColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between MethodTimerColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<MethodTimerColumns> where, Database database = null)
		{
			MethodTimerColumns c = new MethodTimerColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<MethodTimer>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<MethodTimer>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static MethodTimer CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<MethodTimer>();			
			var dao = new MethodTimer();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static MethodTimer OneOrThrow(MethodTimerCollection c)
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
