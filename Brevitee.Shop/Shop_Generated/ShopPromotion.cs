// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Shop
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Brevitee.Data.Table("ShopPromotion", "Shop")]
	public partial class ShopPromotion: Dao
	{
		public ShopPromotion():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopPromotion(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShopPromotion(DataRow data)
		{
			return new ShopPromotion(data);
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



﻿	// start ShopId -> ShopId
	[Brevitee.Data.ForeignKey(
        Table="ShopPromotion",
		Name="ShopId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Shop",
		Suffix="1")]
	public long? ShopId
	{
		get
		{
			return GetLongValue("ShopId");
		}
		set
		{
			SetValue("ShopId", value);
		}
	}

	Shop _shopOfShopId;
	public Shop ShopOfShopId
	{
		get
		{
			if(_shopOfShopId == null)
			{
				_shopOfShopId = Brevitee.Shop.Shop.OneWhere(c => c.KeyColumn == this.ShopId);
			}
			return _shopOfShopId;
		}
	}
	
﻿	// start PromotionId -> PromotionId
	[Brevitee.Data.ForeignKey(
        Table="ShopPromotion",
		Name="PromotionId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Promotion",
		Suffix="2")]
	public long? PromotionId
	{
		get
		{
			return GetLongValue("PromotionId");
		}
		set
		{
			SetValue("PromotionId", value);
		}
	}

	Promotion _promotionOfPromotionId;
	public Promotion PromotionOfPromotionId
	{
		get
		{
			if(_promotionOfPromotionId == null)
			{
				_promotionOfPromotionId = Brevitee.Shop.Promotion.OneWhere(c => c.KeyColumn == this.PromotionId);
			}
			return _promotionOfPromotionId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new ShopPromotionColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShopPromotion table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShopPromotionCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShopPromotion>();
			Database db = database ?? Db.For<ShopPromotion>();
			var results = new ShopPromotionCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShopPromotion GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShopPromotion GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShopPromotionCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShopPromotionCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShopPromotionColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShopPromotionColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopPromotionCollection Where(Func<ShopPromotionColumns, QueryFilter<ShopPromotionColumns>> where, OrderBy<ShopPromotionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShopPromotion>();
			return new ShopPromotionCollection(database.GetQuery<ShopPromotionColumns, ShopPromotion>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopPromotionCollection Where(WhereDelegate<ShopPromotionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShopPromotion>();
			var results = new ShopPromotionCollection(database, database.GetQuery<ShopPromotionColumns, ShopPromotion>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotionCollection Where(WhereDelegate<ShopPromotionColumns> where, OrderBy<ShopPromotionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShopPromotion>();
			var results = new ShopPromotionCollection(database, database.GetQuery<ShopPromotionColumns, ShopPromotion>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopPromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopPromotionCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShopPromotionCollection(database, Select<ShopPromotionColumns>.From<ShopPromotion>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShopPromotion GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShopPromotion OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShopPromotionColumns> whereDelegate = (c) => where;
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
		public static ShopPromotion GetOneWhere(WhereDelegate<ShopPromotionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShopPromotionColumns c = new ShopPromotionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShopPromotion instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotion OneWhere(WhereDelegate<ShopPromotionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopPromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopPromotion OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotion FirstOneWhere(WhereDelegate<ShopPromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotion FirstOneWhere(WhereDelegate<ShopPromotionColumns> where, OrderBy<ShopPromotionColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotion FirstOneWhere(QueryFilter where, OrderBy<ShopPromotionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShopPromotionColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotionCollection Top(int count, WhereDelegate<ShopPromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopPromotionCollection Top(int count, WhereDelegate<ShopPromotionColumns> where, OrderBy<ShopPromotionColumns> orderBy, Database database = null)
		{
			ShopPromotionColumns c = new ShopPromotionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShopPromotion>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShopPromotion>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShopPromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopPromotionCollection>(0);
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
		public static ShopPromotionCollection Top(int count, QueryFilter where, OrderBy<ShopPromotionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShopPromotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopPromotion>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShopPromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopPromotionCollection>(0);
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
		public static ShopPromotionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShopPromotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopPromotion>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShopPromotionCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShopPromotionColumns> where, Database database = null)
		{
			ShopPromotionColumns c = new ShopPromotionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShopPromotion>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShopPromotion>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShopPromotion CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShopPromotion>();			
			var dao = new ShopPromotion();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShopPromotion OneOrThrow(ShopPromotionCollection c)
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
