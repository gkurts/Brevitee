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
	[Brevitee.Data.Table("ShoppingCart", "Shop")]
	public partial class ShoppingCart: Dao
	{
		public ShoppingCart():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShoppingCart(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShoppingCart(DataRow data)
		{
			return new ShoppingCart(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("ShoppingCartItem_ShoppingCartId", new ShoppingCartItemCollection(Database.GetQuery<ShoppingCartItemColumns, ShoppingCartItem>((c) => c.ShoppingCartId == this.Id), this, "ShoppingCartId"));							
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

﻿	// property:Name, columnName:Name	
	[Brevitee.Data.Column(Name="Name", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Name
	{
		get
		{
			return GetStringValue("Name");
		}
		set
		{
			SetValue("Name", value);
		}
	}



﻿	// start ShopperId -> ShopperId
	[Brevitee.Data.ForeignKey(
        Table="ShoppingCart",
		Name="ShopperId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Shopper",
		Suffix="1")]
	public long? ShopperId
	{
		get
		{
			return GetLongValue("ShopperId");
		}
		set
		{
			SetValue("ShopperId", value);
		}
	}

	Shopper _shopperOfShopperId;
	public Shopper ShopperOfShopperId
	{
		get
		{
			if(_shopperOfShopperId == null)
			{
				_shopperOfShopperId = Brevitee.Shop.Shopper.OneWhere(c => c.KeyColumn == this.ShopperId);
			}
			return _shopperOfShopperId;
		}
	}
	
				
﻿
	[Exclude]	
	public ShoppingCartItemCollection ShoppingCartItemsByShoppingCartId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("ShoppingCartItem_ShoppingCartId"))
			{
				SetChildren();
			}

			var c = (ShoppingCartItemCollection)this.ChildCollections["ShoppingCartItem_ShoppingCartId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new ShoppingCartColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShoppingCart table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShoppingCartCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShoppingCart>();
			Database db = database ?? Db.For<ShoppingCart>();
			var results = new ShoppingCartCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShoppingCart GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShoppingCart GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShoppingCartCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShoppingCartCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShoppingCartColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShoppingCartColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingCartCollection Where(Func<ShoppingCartColumns, QueryFilter<ShoppingCartColumns>> where, OrderBy<ShoppingCartColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShoppingCart>();
			return new ShoppingCartCollection(database.GetQuery<ShoppingCartColumns, ShoppingCart>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShoppingCartCollection Where(WhereDelegate<ShoppingCartColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShoppingCart>();
			var results = new ShoppingCartCollection(database, database.GetQuery<ShoppingCartColumns, ShoppingCart>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartCollection Where(WhereDelegate<ShoppingCartColumns> where, OrderBy<ShoppingCartColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShoppingCart>();
			var results = new ShoppingCartCollection(database, database.GetQuery<ShoppingCartColumns, ShoppingCart>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingCartColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingCartCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShoppingCartCollection(database, Select<ShoppingCartColumns>.From<ShoppingCart>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShoppingCart GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShoppingCart OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShoppingCartColumns> whereDelegate = (c) => where;
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
		public static ShoppingCart GetOneWhere(WhereDelegate<ShoppingCartColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShoppingCartColumns c = new ShoppingCartColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShoppingCart instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCart OneWhere(WhereDelegate<ShoppingCartColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShoppingCartColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShoppingCart OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCart FirstOneWhere(WhereDelegate<ShoppingCartColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCart FirstOneWhere(WhereDelegate<ShoppingCartColumns> where, OrderBy<ShoppingCartColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCart FirstOneWhere(QueryFilter where, OrderBy<ShoppingCartColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShoppingCartColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartCollection Top(int count, WhereDelegate<ShoppingCartColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShoppingCartCollection Top(int count, WhereDelegate<ShoppingCartColumns> where, OrderBy<ShoppingCartColumns> orderBy, Database database = null)
		{
			ShoppingCartColumns c = new ShoppingCartColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShoppingCart>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShoppingCart>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingCartColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingCartCollection>(0);
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
		public static ShoppingCartCollection Top(int count, QueryFilter where, OrderBy<ShoppingCartColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCart>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingCart>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShoppingCartColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShoppingCartCollection>(0);
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
		public static ShoppingCartCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCart>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShoppingCart>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShoppingCartCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShoppingCartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShoppingCartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShoppingCartColumns> where, Database database = null)
		{
			ShoppingCartColumns c = new ShoppingCartColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShoppingCart>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShoppingCart>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShoppingCart CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShoppingCart>();			
			var dao = new ShoppingCart();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShoppingCart OneOrThrow(ShoppingCartCollection c)
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
