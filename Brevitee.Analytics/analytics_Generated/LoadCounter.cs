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
	[Brevitee.Data.Table("LoadCounter", "Analytics")]
	public partial class LoadCounter: Dao
	{
		public LoadCounter():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public LoadCounter(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator LoadCounter(DataRow data)
		{
			return new LoadCounter(data);
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

﻿	// property:UrlUuid, columnName:UrlUuid	
	[Brevitee.Data.Column(Name="UrlUuid", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string UrlUuid
	{
		get
		{
			return GetStringValue("UrlUuid");
		}
		set
		{
			SetValue("UrlUuid", value);
		}
	}



﻿	// start CounterId -> CounterId
	[Brevitee.Data.ForeignKey(
        Table="LoadCounter",
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
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new LoadCounterColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the LoadCounter table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static LoadCounterCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<LoadCounter>();
			Database db = database ?? Db.For<LoadCounter>();
			var results = new LoadCounterCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static LoadCounter GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static LoadCounter GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static LoadCounterCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static LoadCounterCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<LoadCounterColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a LoadCounterColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LoadCounterCollection Where(Func<LoadCounterColumns, QueryFilter<LoadCounterColumns>> where, OrderBy<LoadCounterColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<LoadCounter>();
			return new LoadCounterCollection(database.GetQuery<LoadCounterColumns, LoadCounter>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static LoadCounterCollection Where(WhereDelegate<LoadCounterColumns> where, Database database = null)
		{		
			database = database ?? Db.For<LoadCounter>();
			var results = new LoadCounterCollection(database, database.GetQuery<LoadCounterColumns, LoadCounter>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LoadCounterCollection Where(WhereDelegate<LoadCounterColumns> where, OrderBy<LoadCounterColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<LoadCounter>();
			var results = new LoadCounterCollection(database, database.GetQuery<LoadCounterColumns, LoadCounter>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<LoadCounterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LoadCounterCollection Where(QiQuery where, Database database = null)
		{
			var results = new LoadCounterCollection(database, Select<LoadCounterColumns>.From<LoadCounter>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static LoadCounter GetOneWhere(QueryFilter where, Database database = null)
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
		public static LoadCounter OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<LoadCounterColumns> whereDelegate = (c) => where;
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
		public static LoadCounter GetOneWhere(WhereDelegate<LoadCounterColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				LoadCounterColumns c = new LoadCounterColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single LoadCounter instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadCounter OneWhere(WhereDelegate<LoadCounterColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<LoadCounterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static LoadCounter OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadCounter FirstOneWhere(WhereDelegate<LoadCounterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadCounter FirstOneWhere(WhereDelegate<LoadCounterColumns> where, OrderBy<LoadCounterColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadCounter FirstOneWhere(QueryFilter where, OrderBy<LoadCounterColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<LoadCounterColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static LoadCounterCollection Top(int count, WhereDelegate<LoadCounterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static LoadCounterCollection Top(int count, WhereDelegate<LoadCounterColumns> where, OrderBy<LoadCounterColumns> orderBy, Database database = null)
		{
			LoadCounterColumns c = new LoadCounterColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<LoadCounter>();
			QuerySet query = GetQuerySet(db); 
			query.Top<LoadCounter>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<LoadCounterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LoadCounterCollection>(0);
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
		public static LoadCounterCollection Top(int count, QueryFilter where, OrderBy<LoadCounterColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<LoadCounter>();
			QuerySet query = GetQuerySet(db);
			query.Top<LoadCounter>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<LoadCounterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<LoadCounterCollection>(0);
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
		public static LoadCounterCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<LoadCounter>();
			QuerySet query = GetQuerySet(db);
			query.Top<LoadCounter>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<LoadCounterCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a LoadCounterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between LoadCounterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<LoadCounterColumns> where, Database database = null)
		{
			LoadCounterColumns c = new LoadCounterColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<LoadCounter>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<LoadCounter>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static LoadCounter CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<LoadCounter>();			
			var dao = new LoadCounter();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static LoadCounter OneOrThrow(LoadCounterCollection c)
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
