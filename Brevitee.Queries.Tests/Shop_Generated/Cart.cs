// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Data.Tests
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Brevitee.Data.Table("Cart", "Shop")]
	public partial class Cart: Dao
	{
		public Cart():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Cart(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Cart(DataRow data)
		{
			return new Cart(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("CartItem_CartId", new CartItemCollection(Database.GetQuery<CartItemColumns, CartItem>((c) => c.CartId == this.Id), this, "CartId"));							
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



				
﻿
	[Exclude]	
	public CartItemCollection CartItemsByCartId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("CartItem_CartId"))
			{
				SetChildren();
			}

			var c = (CartItemCollection)this.ChildCollections["CartItem_CartId"];
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
			var colFilter = new CartColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Cart table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static CartCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Cart>();
			Database db = database ?? Db.For<Cart>();
			var results = new CartCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Cart GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Cart GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static CartCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static CartCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<CartColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a CartColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CartCollection Where(Func<CartColumns, QueryFilter<CartColumns>> where, OrderBy<CartColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Cart>();
			return new CartCollection(database.GetQuery<CartColumns, Cart>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CartCollection Where(WhereDelegate<CartColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Cart>();
			var results = new CartCollection(database, database.GetQuery<CartColumns, Cart>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CartCollection Where(WhereDelegate<CartColumns> where, OrderBy<CartColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Cart>();
			var results = new CartCollection(database, database.GetQuery<CartColumns, Cart>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CartColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static CartCollection Where(QiQuery where, Database database = null)
		{
			var results = new CartCollection(database, Select<CartColumns>.From<Cart>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Cart GetOneWhere(QueryFilter where, Database database = null)
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
		public static Cart OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<CartColumns> whereDelegate = (c) => where;
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
		public static Cart GetOneWhere(WhereDelegate<CartColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				CartColumns c = new CartColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Cart instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Cart OneWhere(WhereDelegate<CartColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CartColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Cart OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Cart FirstOneWhere(WhereDelegate<CartColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Cart FirstOneWhere(WhereDelegate<CartColumns> where, OrderBy<CartColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Cart FirstOneWhere(QueryFilter where, OrderBy<CartColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<CartColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CartCollection Top(int count, WhereDelegate<CartColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CartCollection Top(int count, WhereDelegate<CartColumns> where, OrderBy<CartColumns> orderBy, Database database = null)
		{
			CartColumns c = new CartColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Cart>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Cart>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<CartColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CartCollection>(0);
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
		public static CartCollection Top(int count, QueryFilter where, OrderBy<CartColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Cart>();
			QuerySet query = GetQuerySet(db);
			query.Top<Cart>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<CartColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CartCollection>(0);
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
		public static CartCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Cart>();
			QuerySet query = GetQuerySet(db);
			query.Top<Cart>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<CartCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CartColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CartColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<CartColumns> where, Database database = null)
		{
			CartColumns c = new CartColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Cart>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Cart>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Cart CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Cart>();			
			var dao = new Cart();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Cart OneOrThrow(CartCollection c)
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
