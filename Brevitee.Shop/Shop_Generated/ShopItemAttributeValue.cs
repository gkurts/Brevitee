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
	[Brevitee.Data.Table("ShopItemAttributeValue", "Shop")]
	public partial class ShopItemAttributeValue: Dao
	{
		public ShopItemAttributeValue():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public ShopItemAttributeValue(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator ShopItemAttributeValue(DataRow data)
		{
			return new ShopItemAttributeValue(data);
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

﻿	// property:Value, columnName:Value	
	[Brevitee.Data.Column(Name="Value", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Value
	{
		get
		{
			return GetStringValue("Value");
		}
		set
		{
			SetValue("Value", value);
		}
	}



﻿	// start ShopItemAttributeId -> ShopItemAttributeId
	[Brevitee.Data.ForeignKey(
        Table="ShopItemAttributeValue",
		Name="ShopItemAttributeId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="ShopItemAttribute",
		Suffix="1")]
	public long? ShopItemAttributeId
	{
		get
		{
			return GetLongValue("ShopItemAttributeId");
		}
		set
		{
			SetValue("ShopItemAttributeId", value);
		}
	}

	ShopItemAttribute _shopItemAttributeOfShopItemAttributeId;
	public ShopItemAttribute ShopItemAttributeOfShopItemAttributeId
	{
		get
		{
			if(_shopItemAttributeOfShopItemAttributeId == null)
			{
				_shopItemAttributeOfShopItemAttributeId = Brevitee.Shop.ShopItemAttribute.OneWhere(c => c.KeyColumn == this.ShopItemAttributeId);
			}
			return _shopItemAttributeOfShopItemAttributeId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new ShopItemAttributeValueColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the ShopItemAttributeValue table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ShopItemAttributeValueCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<ShopItemAttributeValue>();
			Database db = database ?? Db.For<ShopItemAttributeValue>();
			var results = new ShopItemAttributeValueCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static ShopItemAttributeValue GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static ShopItemAttributeValue GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ShopItemAttributeValueCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ShopItemAttributeValueCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ShopItemAttributeValueColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemAttributeValueCollection Where(Func<ShopItemAttributeValueColumns, QueryFilter<ShopItemAttributeValueColumns>> where, OrderBy<ShopItemAttributeValueColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<ShopItemAttributeValue>();
			return new ShopItemAttributeValueCollection(database.GetQuery<ShopItemAttributeValueColumns, ShopItemAttributeValue>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ShopItemAttributeValueCollection Where(WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
		{		
			database = database ?? Db.For<ShopItemAttributeValue>();
			var results = new ShopItemAttributeValueCollection(database, database.GetQuery<ShopItemAttributeValueColumns, ShopItemAttributeValue>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValueCollection Where(WhereDelegate<ShopItemAttributeValueColumns> where, OrderBy<ShopItemAttributeValueColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<ShopItemAttributeValue>();
			var results = new ShopItemAttributeValueCollection(database, database.GetQuery<ShopItemAttributeValueColumns, ShopItemAttributeValue>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemAttributeValueColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemAttributeValueCollection Where(QiQuery where, Database database = null)
		{
			var results = new ShopItemAttributeValueCollection(database, Select<ShopItemAttributeValueColumns>.From<ShopItemAttributeValue>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static ShopItemAttributeValue GetOneWhere(QueryFilter where, Database database = null)
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
		public static ShopItemAttributeValue OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ShopItemAttributeValueColumns> whereDelegate = (c) => where;
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
		public static ShopItemAttributeValue GetOneWhere(WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ShopItemAttributeValueColumns c = new ShopItemAttributeValueColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single ShopItemAttributeValue instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValue OneWhere(WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ShopItemAttributeValueColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ShopItemAttributeValue OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValue FirstOneWhere(WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValue FirstOneWhere(WhereDelegate<ShopItemAttributeValueColumns> where, OrderBy<ShopItemAttributeValueColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValue FirstOneWhere(QueryFilter where, OrderBy<ShopItemAttributeValueColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ShopItemAttributeValueColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValueCollection Top(int count, WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ShopItemAttributeValueCollection Top(int count, WhereDelegate<ShopItemAttributeValueColumns> where, OrderBy<ShopItemAttributeValueColumns> orderBy, Database database = null)
		{
			ShopItemAttributeValueColumns c = new ShopItemAttributeValueColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<ShopItemAttributeValue>();
			QuerySet query = GetQuerySet(db); 
			query.Top<ShopItemAttributeValue>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemAttributeValueColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemAttributeValueCollection>(0);
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
		public static ShopItemAttributeValueCollection Top(int count, QueryFilter where, OrderBy<ShopItemAttributeValueColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemAttributeValue>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemAttributeValue>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ShopItemAttributeValueColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ShopItemAttributeValueCollection>(0);
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
		public static ShopItemAttributeValueCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemAttributeValue>();
			QuerySet query = GetQuerySet(db);
			query.Top<ShopItemAttributeValue>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ShopItemAttributeValueCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ShopItemAttributeValueColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ShopItemAttributeValueColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ShopItemAttributeValueColumns> where, Database database = null)
		{
			ShopItemAttributeValueColumns c = new ShopItemAttributeValueColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<ShopItemAttributeValue>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<ShopItemAttributeValue>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static ShopItemAttributeValue CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<ShopItemAttributeValue>();			
			var dao = new ShopItemAttributeValue();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static ShopItemAttributeValue OneOrThrow(ShopItemAttributeValueCollection c)
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
