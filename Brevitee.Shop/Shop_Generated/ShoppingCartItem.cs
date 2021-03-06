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
	[Brevitee.Data.Table("ShoppingCartItem", "Shop")]
	public partial class ShoppingCartItem: Dao
	{
		public ShoppingCartItem():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingCartItem(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShoppingCartItem(DataRow data)
		{
			return new ShoppingCartItem(data);
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

﻿	// property:Quantity, columnName:Quantity	
	[Brevitee.Data.Column(Name="Quantity", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Quantity
	{
		get
		{
			return GetIntValue("Quantity");
		}
		set
		{
			SetValue("Quantity", value);
		}
	}



﻿	// start ShoppingCartId -> ShoppingCartId
	[Brevitee.Data.ForeignKey(
        Table="ShoppingCartItem",
		Name="ShoppingCartId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="ShoppingCart",
		Suffix="1")]
	public long? ShoppingCartId
	{
		get
		{
			return GetLongValue("ShoppingCartId");
		}
		set
		{
			SetValue("ShoppingCartId", value);
		}
	}

	ShoppingCart _shoppingCartOfShoppingCartId;
	public ShoppingCart ShoppingCartOfShoppingCartId
	{
		get
		{
			if(_shoppingCartOfShoppingCartId == null)
			{
				_shoppingCartOfShoppingCartId = Brevitee.Shop.ShoppingCart.OneWhere(c => c.KeyColumn == this.ShoppingCartId);
			}
			return _shoppingCartOfShoppingCartId;
		}
	}
	
﻿	// start ShopItemId -> ShopItemId
	[Brevitee.Data.ForeignKey(
        Table="ShoppingCartItem",
		Name="ShopItemId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="ShopItem",
		Suffix="2")]
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
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new ShoppingCartItemColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShoppingCartItem table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShoppingCartItemCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShoppingCartItem>();
			Database db = database ?? Db.For<ShoppingCartItem>();
			var results = new ShoppingCartItemCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShoppingCartItem GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShoppingCartItem GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShoppingCartItemCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShoppingCartItemCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShoppingCartItemColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShoppingCartItemColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingCartItemCollection Where(Func<ShoppingCartItemColumns, QueryFilter<ShoppingCartItemColumns>> where, OrderBy<ShoppingCartItemColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShoppingCartItem>();
			return new ShoppingCartItemCollection(database.GetQuery<ShoppingCartItemColumns, ShoppingCartItem>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingCartItemCollection Where(WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShoppingCartItem>();
			var results = new ShoppingCartItemCollection(database, database.GetQuery<ShoppingCartItemColumns, ShoppingCartItem>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItemCollection Where(WhereDelegate<ShoppingCartItemColumns> where, OrderBy<ShoppingCartItemColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShoppingCartItem>();
			var results = new ShoppingCartItemCollection(database, database.GetQuery<ShoppingCartItemColumns, ShoppingCartItem>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingCartItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingCartItemCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShoppingCartItemCollection(database, Select<ShoppingCartItemColumns>.From<ShoppingCartItem>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShoppingCartItem GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShoppingCartItem OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShoppingCartItemColumns> whereDelegate = (c) => where;
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
		public static ShoppingCartItem GetOneWhere(WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShoppingCartItemColumns c = new ShoppingCartItemColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShoppingCartItem instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItem OneWhere(WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingCartItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingCartItem OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItem FirstOneWhere(WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItem FirstOneWhere(WhereDelegate<ShoppingCartItemColumns> where, OrderBy<ShoppingCartItemColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItem FirstOneWhere(QueryFilter where, OrderBy<ShoppingCartItemColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShoppingCartItemColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItemCollection Top(int count, WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartItemCollection Top(int count, WhereDelegate<ShoppingCartItemColumns> where, OrderBy<ShoppingCartItemColumns> orderBy, Database database = null)
		{
			ShoppingCartItemColumns c = new ShoppingCartItemColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShoppingCartItem>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShoppingCartItem>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingCartItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingCartItemCollection>(0);
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
		public static ShoppingCartItemCollection Top(int count, QueryFilter where, OrderBy<ShoppingCartItemColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCartItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingCartItem>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingCartItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingCartItemCollection>(0);
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
		public static ShoppingCartItemCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCartItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingCartItem>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShoppingCartItemCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShoppingCartItemColumns> where, Database database = null)
		{
			ShoppingCartItemColumns c = new ShoppingCartItemColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShoppingCartItem>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShoppingCartItem>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShoppingCartItem CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCartItem>();			
			var dao = new ShoppingCartItem();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShoppingCartItem OneOrThrow(ShoppingCartItemCollection c)
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
