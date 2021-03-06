// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Logging.Data
{
	// schema = DaoLogger2
	// connection Name = DaoLogger2
	[Serializable]
	[Brevitee.Data.Table("EventParam", "DaoLogger2")]
	public partial class EventParam: Dao
	{
		public EventParam():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public EventParam(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator EventParam(DataRow data)
		{
			return new EventParam(data);
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



﻿	// start EventId -> EventId
	[Brevitee.Data.ForeignKey(
        Table="EventParam",
		Name="EventId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Event",
		Suffix="1")]
	public long? EventId
	{
		get
		{
			return GetLongValue("EventId");
		}
		set
		{
			SetValue("EventId", value);
		}
	}

	Event _eventOfEventId;
	public Event EventOfEventId
	{
		get
		{
			if(_eventOfEventId == null)
			{
				_eventOfEventId = Brevitee.Logging.Data.Event.OneWhere(c => c.KeyColumn == this.EventId);
			}
			return _eventOfEventId;
		}
	}
	
﻿	// start ParamId -> ParamId
	[Brevitee.Data.ForeignKey(
        Table="EventParam",
		Name="ParamId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Param",
		Suffix="2")]
	public long? ParamId
	{
		get
		{
			return GetLongValue("ParamId");
		}
		set
		{
			SetValue("ParamId", value);
		}
	}

	Param _paramOfParamId;
	public Param ParamOfParamId
	{
		get
		{
			if(_paramOfParamId == null)
			{
				_paramOfParamId = Brevitee.Logging.Data.Param.OneWhere(c => c.KeyColumn == this.ParamId);
			}
			return _paramOfParamId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new EventParamColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the EventParam table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static EventParamCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<EventParam>();
			Database db = database ?? Db.For<EventParam>();
			var results = new EventParamCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static EventParam GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static EventParam GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static EventParamCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static EventParamCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<EventParamColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a EventParamColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EventParamCollection Where(Func<EventParamColumns, QueryFilter<EventParamColumns>> where, OrderBy<EventParamColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<EventParam>();
			return new EventParamCollection(database.GetQuery<EventParamColumns, EventParam>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EventParamCollection Where(WhereDelegate<EventParamColumns> where, Database database = null)
		{		
			database = database ?? Db.For<EventParam>();
			var results = new EventParamCollection(database, database.GetQuery<EventParamColumns, EventParam>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EventParamCollection Where(WhereDelegate<EventParamColumns> where, OrderBy<EventParamColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<EventParam>();
			var results = new EventParamCollection(database, database.GetQuery<EventParamColumns, EventParam>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EventParamColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EventParamCollection Where(QiQuery where, Database database = null)
		{
			var results = new EventParamCollection(database, Select<EventParamColumns>.From<EventParam>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static EventParam GetOneWhere(QueryFilter where, Database database = null)
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
		public static EventParam OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<EventParamColumns> whereDelegate = (c) => where;
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
		public static EventParam GetOneWhere(WhereDelegate<EventParamColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				EventParamColumns c = new EventParamColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single EventParam instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventParam OneWhere(WhereDelegate<EventParamColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EventParamColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EventParam OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventParam FirstOneWhere(WhereDelegate<EventParamColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventParam FirstOneWhere(WhereDelegate<EventParamColumns> where, OrderBy<EventParamColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventParam FirstOneWhere(QueryFilter where, OrderBy<EventParamColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<EventParamColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventParamCollection Top(int count, WhereDelegate<EventParamColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EventParamCollection Top(int count, WhereDelegate<EventParamColumns> where, OrderBy<EventParamColumns> orderBy, Database database = null)
		{
			EventParamColumns c = new EventParamColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<EventParam>();
			QuerySet query = GetQuerySet(db); 
			query.Top<EventParam>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<EventParamColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EventParamCollection>(0);
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
		public static EventParamCollection Top(int count, QueryFilter where, OrderBy<EventParamColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<EventParam>();
			QuerySet query = GetQuerySet(db);
			query.Top<EventParam>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<EventParamColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EventParamCollection>(0);
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
		public static EventParamCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<EventParam>();
			QuerySet query = GetQuerySet(db);
			query.Top<EventParam>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<EventParamCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventParamColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventParamColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<EventParamColumns> where, Database database = null)
		{
			EventParamColumns c = new EventParamColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<EventParam>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<EventParam>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static EventParam CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<EventParam>();			
			var dao = new EventParam();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static EventParam OneOrThrow(EventParamCollection c)
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
