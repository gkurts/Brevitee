// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Stickerize.Business.Data
{
	// schema = Stickerize
	// connection Name = Stickerize
	[Serializable]
	[Brevitee.Data.Table("StickerizerStickerizee", "Stickerize")]
	public partial class StickerizerStickerizee: Dao
	{
		public StickerizerStickerizee():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public StickerizerStickerizee(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator StickerizerStickerizee(DataRow data)
		{
			return new StickerizerStickerizee(data);
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



﻿	// start StickerizerId -> StickerizerId
	[Brevitee.Data.ForeignKey(
        Table="StickerizerStickerizee",
		Name="StickerizerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizer",
		Suffix="1")]
	public long? StickerizerId
	{
		get
		{
			return GetLongValue("StickerizerId");
		}
		set
		{
			SetValue("StickerizerId", value);
		}
	}

	Stickerizer _stickerizerOfStickerizerId;
	public Stickerizer StickerizerOfStickerizerId
	{
		get
		{
			if(_stickerizerOfStickerizerId == null)
			{
				_stickerizerOfStickerizerId = Brevitee.Stickerize.Business.Data.Stickerizer.OneWhere(c => c.KeyColumn == this.StickerizerId);
			}
			return _stickerizerOfStickerizerId;
		}
	}
	
﻿	// start StickerizeeId -> StickerizeeId
	[Brevitee.Data.ForeignKey(
        Table="StickerizerStickerizee",
		Name="StickerizeeId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizee",
		Suffix="2")]
	public long? StickerizeeId
	{
		get
		{
			return GetLongValue("StickerizeeId");
		}
		set
		{
			SetValue("StickerizeeId", value);
		}
	}

	Stickerizee _stickerizeeOfStickerizeeId;
	public Stickerizee StickerizeeOfStickerizeeId
	{
		get
		{
			if(_stickerizeeOfStickerizeeId == null)
			{
				_stickerizeeOfStickerizeeId = Brevitee.Stickerize.Business.Data.Stickerizee.OneWhere(c => c.KeyColumn == this.StickerizeeId);
			}
			return _stickerizeeOfStickerizeeId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new StickerizerStickerizeeColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the StickerizerStickerizee table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static StickerizerStickerizeeCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<StickerizerStickerizee>();
			Database db = database ?? Db.For<StickerizerStickerizee>();
			var results = new StickerizerStickerizeeCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static StickerizerStickerizee GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static StickerizerStickerizee GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static StickerizerStickerizeeCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static StickerizerStickerizeeCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<StickerizerStickerizeeColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizerStickerizeeCollection Where(Func<StickerizerStickerizeeColumns, QueryFilter<StickerizerStickerizeeColumns>> where, OrderBy<StickerizerStickerizeeColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<StickerizerStickerizee>();
			return new StickerizerStickerizeeCollection(database.GetQuery<StickerizerStickerizeeColumns, StickerizerStickerizee>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizerStickerizeeCollection Where(WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
		{		
			database = database ?? Db.For<StickerizerStickerizee>();
			var results = new StickerizerStickerizeeCollection(database, database.GetQuery<StickerizerStickerizeeColumns, StickerizerStickerizee>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizeeCollection Where(WhereDelegate<StickerizerStickerizeeColumns> where, OrderBy<StickerizerStickerizeeColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<StickerizerStickerizee>();
			var results = new StickerizerStickerizeeCollection(database, database.GetQuery<StickerizerStickerizeeColumns, StickerizerStickerizee>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizerStickerizeeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizerStickerizeeCollection Where(QiQuery where, Database database = null)
		{
			var results = new StickerizerStickerizeeCollection(database, Select<StickerizerStickerizeeColumns>.From<StickerizerStickerizee>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static StickerizerStickerizee GetOneWhere(QueryFilter where, Database database = null)
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
		public static StickerizerStickerizee OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<StickerizerStickerizeeColumns> whereDelegate = (c) => where;
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
		public static StickerizerStickerizee GetOneWhere(WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				StickerizerStickerizeeColumns c = new StickerizerStickerizeeColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single StickerizerStickerizee instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizee OneWhere(WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizerStickerizeeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizerStickerizee OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizee FirstOneWhere(WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizee FirstOneWhere(WhereDelegate<StickerizerStickerizeeColumns> where, OrderBy<StickerizerStickerizeeColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizee FirstOneWhere(QueryFilter where, OrderBy<StickerizerStickerizeeColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<StickerizerStickerizeeColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizeeCollection Top(int count, WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizerStickerizeeCollection Top(int count, WhereDelegate<StickerizerStickerizeeColumns> where, OrderBy<StickerizerStickerizeeColumns> orderBy, Database database = null)
		{
			StickerizerStickerizeeColumns c = new StickerizerStickerizeeColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<StickerizerStickerizee>();
			QuerySet query = GetQuerySet(db); 
			query.Top<StickerizerStickerizee>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<StickerizerStickerizeeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizerStickerizeeCollection>(0);
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
		public static StickerizerStickerizeeCollection Top(int count, QueryFilter where, OrderBy<StickerizerStickerizeeColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<StickerizerStickerizee>();
			QuerySet query = GetQuerySet(db);
			query.Top<StickerizerStickerizee>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<StickerizerStickerizeeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizerStickerizeeCollection>(0);
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
		public static StickerizerStickerizeeCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<StickerizerStickerizee>();
			QuerySet query = GetQuerySet(db);
			query.Top<StickerizerStickerizee>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<StickerizerStickerizeeCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizerStickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizerStickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<StickerizerStickerizeeColumns> where, Database database = null)
		{
			StickerizerStickerizeeColumns c = new StickerizerStickerizeeColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<StickerizerStickerizee>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<StickerizerStickerizee>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static StickerizerStickerizee CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<StickerizerStickerizee>();			
			var dao = new StickerizerStickerizee();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static StickerizerStickerizee OneOrThrow(StickerizerStickerizeeCollection c)
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
