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
	[Brevitee.Data.Table("ShoppingListShopItem", "Shop")]
	public partial class ShoppingListShopItem: Dao
	{
		public ShoppingListShopItem():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingListShopItem(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShoppingListShopItem(DataRow data)
		{
			return new ShoppingListShopItem(data);
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



﻿	// start ShoppingListId -> ShoppingListId
	[Brevitee.Data.ForeignKey(
        Table="ShoppingListShopItem",
		Name="ShoppingListId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="ShoppingList",
		Suffix="1")]
	public long? ShoppingListId
	{
		get
		{
			return GetLongValue("ShoppingListId");
		}
		set
		{
			SetValue("ShoppingListId", value);
		}
	}

	ShoppingList _shoppingListOfShoppingListId;
	public ShoppingList ShoppingListOfShoppingListId
	{
		get
		{
			if(_shoppingListOfShoppingListId == null)
			{
				_shoppingListOfShoppingListId = Brevitee.Shop.ShoppingList.OneWhere(c => c.KeyColumn == this.ShoppingListId);
			}
			return _shoppingListOfShoppingListId;
		}
	}
	
﻿	// start ShopItemId -> ShopItemId
	[Brevitee.Data.ForeignKey(
        Table="ShoppingListShopItem",
		Name="ShopItemId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
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
			var colFilter = new ShoppingListShopItemColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShoppingListShopItem table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShoppingListShopItemCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShoppingListShopItem>();
			Database db = database ?? Db.For<ShoppingListShopItem>();
			var results = new ShoppingListShopItemCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShoppingListShopItem GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShoppingListShopItem GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShoppingListShopItemCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShoppingListShopItemCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShoppingListShopItemColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShoppingListShopItemColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingListShopItemCollection Where(Func<ShoppingListShopItemColumns, QueryFilter<ShoppingListShopItemColumns>> where, OrderBy<ShoppingListShopItemColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShoppingListShopItem>();
			return new ShoppingListShopItemCollection(database.GetQuery<ShoppingListShopItemColumns, ShoppingListShopItem>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingListShopItemCollection Where(WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShoppingListShopItem>();
			var results = new ShoppingListShopItemCollection(database, database.GetQuery<ShoppingListShopItemColumns, ShoppingListShopItem>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItemCollection Where(WhereDelegate<ShoppingListShopItemColumns> where, OrderBy<ShoppingListShopItemColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShoppingListShopItem>();
			var results = new ShoppingListShopItemCollection(database, database.GetQuery<ShoppingListShopItemColumns, ShoppingListShopItem>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingListShopItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingListShopItemCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShoppingListShopItemCollection(database, Select<ShoppingListShopItemColumns>.From<ShoppingListShopItem>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShoppingListShopItem GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShoppingListShopItem OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShoppingListShopItemColumns> whereDelegate = (c) => where;
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
		public static ShoppingListShopItem GetOneWhere(WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShoppingListShopItemColumns c = new ShoppingListShopItemColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShoppingListShopItem instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItem OneWhere(WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingListShopItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingListShopItem OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItem FirstOneWhere(WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItem FirstOneWhere(WhereDelegate<ShoppingListShopItemColumns> where, OrderBy<ShoppingListShopItemColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItem FirstOneWhere(QueryFilter where, OrderBy<ShoppingListShopItemColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShoppingListShopItemColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItemCollection Top(int count, WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingListShopItemCollection Top(int count, WhereDelegate<ShoppingListShopItemColumns> where, OrderBy<ShoppingListShopItemColumns> orderBy, Database database = null)
		{
			ShoppingListShopItemColumns c = new ShoppingListShopItemColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShoppingListShopItem>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShoppingListShopItem>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingListShopItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingListShopItemCollection>(0);
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
		public static ShoppingListShopItemCollection Top(int count, QueryFilter where, OrderBy<ShoppingListShopItemColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingListShopItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingListShopItem>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingListShopItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingListShopItemCollection>(0);
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
		public static ShoppingListShopItemCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingListShopItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingListShopItem>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShoppingListShopItemCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingListShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingListShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShoppingListShopItemColumns> where, Database database = null)
		{
			ShoppingListShopItemColumns c = new ShoppingListShopItemColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShoppingListShopItem>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShoppingListShopItem>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShoppingListShopItem CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingListShopItem>();			
			var dao = new ShoppingListShopItem();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShoppingListShopItem OneOrThrow(ShoppingListShopItemCollection c)
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
