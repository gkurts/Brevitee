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
	[Brevitee.Data.Table("ShopItemPromotion", "Shop")]
	public partial class ShopItemPromotion: Dao
	{
		public ShopItemPromotion():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopItemPromotion(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShopItemPromotion(DataRow data)
		{
			return new ShopItemPromotion(data);
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



﻿	// start ShopItemId -> ShopItemId
	[Brevitee.Data.ForeignKey(
        Table="ShopItemPromotion",
		Name="ShopItemId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="ShopItem",
		Suffix="1")]
	public long? ShopItemId
	{
		get
		{
			return GetLongValue("ShopItemId");
		}
		set
		{
			SetValue("ShopItemId", value);
		}
	}

	ShopItem _shopItemOfShopItemId;
	public ShopItem ShopItemOfShopItemId
	{
		get
		{
			if(_shopItemOfShopItemId == null)
			{
				_shopItemOfShopItemId = Brevitee.Shop.ShopItem.OneWhere(c => c.KeyColumn == this.ShopItemId);
			}
			return _shopItemOfShopItemId;
		}
	}
	
﻿	// start PromotionId -> PromotionId
	[Brevitee.Data.ForeignKey(
        Table="ShopItemPromotion",
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
			var colFilter = new ShopItemPromotionColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShopItemPromotion table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShopItemPromotionCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShopItemPromotion>();
			Database db = database ?? Db.For<ShopItemPromotion>();
			var results = new ShopItemPromotionCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShopItemPromotion GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShopItemPromotion GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShopItemPromotionCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShopItemPromotionCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShopItemPromotionColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShopItemPromotionColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemPromotionCollection Where(Func<ShopItemPromotionColumns, QueryFilter<ShopItemPromotionColumns>> where, OrderBy<ShopItemPromotionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShopItemPromotion>();
			return new ShopItemPromotionCollection(database.GetQuery<ShopItemPromotionColumns, ShopItemPromotion>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemPromotionCollection Where(WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShopItemPromotion>();
			var results = new ShopItemPromotionCollection(database, database.GetQuery<ShopItemPromotionColumns, ShopItemPromotion>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotionCollection Where(WhereDelegate<ShopItemPromotionColumns> where, OrderBy<ShopItemPromotionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShopItemPromotion>();
			var results = new ShopItemPromotionCollection(database, database.GetQuery<ShopItemPromotionColumns, ShopItemPromotion>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemPromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemPromotionCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShopItemPromotionCollection(database, Select<ShopItemPromotionColumns>.From<ShopItemPromotion>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShopItemPromotion GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShopItemPromotion OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShopItemPromotionColumns> whereDelegate = (c) => where;
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
		public static ShopItemPromotion GetOneWhere(WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShopItemPromotionColumns c = new ShopItemPromotionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShopItemPromotion instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotion OneWhere(WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemPromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemPromotion OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotion FirstOneWhere(WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotion FirstOneWhere(WhereDelegate<ShopItemPromotionColumns> where, OrderBy<ShopItemPromotionColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotion FirstOneWhere(QueryFilter where, OrderBy<ShopItemPromotionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShopItemPromotionColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotionCollection Top(int count, WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemPromotionCollection Top(int count, WhereDelegate<ShopItemPromotionColumns> where, OrderBy<ShopItemPromotionColumns> orderBy, Database database = null)
		{
			ShopItemPromotionColumns c = new ShopItemPromotionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShopItemPromotion>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShopItemPromotion>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemPromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemPromotionCollection>(0);
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
		public static ShopItemPromotionCollection Top(int count, QueryFilter where, OrderBy<ShopItemPromotionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemPromotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemPromotion>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemPromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemPromotionCollection>(0);
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
		public static ShopItemPromotionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemPromotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemPromotion>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShopItemPromotionCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemPromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemPromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShopItemPromotionColumns> where, Database database = null)
		{
			ShopItemPromotionColumns c = new ShopItemPromotionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShopItemPromotion>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShopItemPromotion>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShopItemPromotion CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemPromotion>();			
			var dao = new ShopItemPromotion();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShopItemPromotion OneOrThrow(ShopItemPromotionCollection c)
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
