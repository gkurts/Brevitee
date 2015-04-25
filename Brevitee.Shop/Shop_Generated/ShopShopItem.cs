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
	[Brevitee.Data.Table("ShopShopItem", "Shop")]
	public partial class ShopShopItem: Dao
	{
		public ShopShopItem():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopShopItem(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShopShopItem(DataRow data)
		{
			return new ShopShopItem(data);
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
        Table="ShopShopItem",
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
	
﻿	// start ShopItemId -> ShopItemId
	[Brevitee.Data.ForeignKey(
        Table="ShopShopItem",
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
			var colFilter = new ShopShopItemColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShopShopItem table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShopShopItemCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShopShopItem>();
			Database db = database ?? Db.For<ShopShopItem>();
			var results = new ShopShopItemCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShopShopItem GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShopShopItem GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShopShopItemCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShopShopItemCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShopShopItemColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShopShopItemColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopShopItemCollection Where(Func<ShopShopItemColumns, QueryFilter<ShopShopItemColumns>> where, OrderBy<ShopShopItemColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShopShopItem>();
			return new ShopShopItemCollection(database.GetQuery<ShopShopItemColumns, ShopShopItem>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopShopItemCollection Where(WhereDelegate<ShopShopItemColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShopShopItem>();
			var results = new ShopShopItemCollection(database, database.GetQuery<ShopShopItemColumns, ShopShopItem>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItemCollection Where(WhereDelegate<ShopShopItemColumns> where, OrderBy<ShopShopItemColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShopShopItem>();
			var results = new ShopShopItemCollection(database, database.GetQuery<ShopShopItemColumns, ShopShopItem>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopShopItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopShopItemCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShopShopItemCollection(database, Select<ShopShopItemColumns>.From<ShopShopItem>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShopShopItem GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShopShopItem OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShopShopItemColumns> whereDelegate = (c) => where;
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
		public static ShopShopItem GetOneWhere(WhereDelegate<ShopShopItemColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShopShopItemColumns c = new ShopShopItemColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShopShopItem instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItem OneWhere(WhereDelegate<ShopShopItemColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopShopItemColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopShopItem OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItem FirstOneWhere(WhereDelegate<ShopShopItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItem FirstOneWhere(WhereDelegate<ShopShopItemColumns> where, OrderBy<ShopShopItemColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItem FirstOneWhere(QueryFilter where, OrderBy<ShopShopItemColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShopShopItemColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItemCollection Top(int count, WhereDelegate<ShopShopItemColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopShopItemCollection Top(int count, WhereDelegate<ShopShopItemColumns> where, OrderBy<ShopShopItemColumns> orderBy, Database database = null)
		{
			ShopShopItemColumns c = new ShopShopItemColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShopShopItem>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShopShopItem>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShopShopItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopShopItemCollection>(0);
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
		public static ShopShopItemCollection Top(int count, QueryFilter where, OrderBy<ShopShopItemColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShopShopItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopShopItem>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShopShopItemColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopShopItemCollection>(0);
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
		public static ShopShopItemCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShopShopItem>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopShopItem>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShopShopItemCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopShopItemColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopShopItemColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShopShopItemColumns> where, Database database = null)
		{
			ShopShopItemColumns c = new ShopShopItemColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShopShopItem>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShopShopItem>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShopShopItem CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShopShopItem>();			
			var dao = new ShopShopItem();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShopShopItem OneOrThrow(ShopShopItemCollection c)
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
