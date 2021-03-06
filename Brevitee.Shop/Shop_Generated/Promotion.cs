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
	[Brevitee.Data.Table("Promotion", "Shop")]
	public partial class Promotion: Dao
	{
		public Promotion():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Promotion(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Promotion(DataRow data)
		{
			return new Promotion(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PromotionEffect_PromotionId", new PromotionEffectCollection(Database.GetQuery<PromotionEffectColumns, PromotionEffect>((c) => c.PromotionId == this.Id), this, "PromotionId"));	﻿
            this.ChildCollections.Add("PromotionCondition_PromotionId", new PromotionConditionCollection(Database.GetQuery<PromotionConditionColumns, PromotionCondition>((c) => c.PromotionId == this.Id), this, "PromotionId"));	﻿
            this.ChildCollections.Add("ShopPromotion_PromotionId", new ShopPromotionCollection(Database.GetQuery<ShopPromotionColumns, ShopPromotion>((c) => c.PromotionId == this.Id), this, "PromotionId"));	﻿
            this.ChildCollections.Add("ShopItemPromotion_PromotionId", new ShopItemPromotionCollection(Database.GetQuery<ShopItemPromotionColumns, ShopItemPromotion>((c) => c.PromotionId == this.Id), this, "PromotionId"));							﻿
            this.ChildCollections.Add("Promotion_ShopPromotion_Shop",  new XrefDaoCollection<ShopPromotion, Shop>(this, false));
				﻿
            this.ChildCollections.Add("Promotion_ShopItemPromotion_ShopItem",  new XrefDaoCollection<ShopItemPromotion, ShopItem>(this, false));
				
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
	[Brevitee.Data.Column(Name="Name", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
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

﻿	// property:ValidFrom, columnName:ValidFrom	
	[Brevitee.Data.Column(Name="ValidFrom", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? ValidFrom
	{
		get
		{
			return GetDateTimeValue("ValidFrom");
		}
		set
		{
			SetValue("ValidFrom", value);
		}
	}

﻿	// property:ValidTo, columnName:ValidTo	
	[Brevitee.Data.Column(Name="ValidTo", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? ValidTo
	{
		get
		{
			return GetDateTimeValue("ValidTo");
		}
		set
		{
			SetValue("ValidTo", value);
		}
	}



				
﻿
	[Exclude]	
	public PromotionEffectCollection PromotionEffectsByPromotionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PromotionEffect_PromotionId"))
			{
				SetChildren();
			}

			var c = (PromotionEffectCollection)this.ChildCollections["PromotionEffect_PromotionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PromotionConditionCollection PromotionConditionsByPromotionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PromotionCondition_PromotionId"))
			{
				SetChildren();
			}

			var c = (PromotionConditionCollection)this.ChildCollections["PromotionCondition_PromotionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public ShopPromotionCollection ShopPromotionsByPromotionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("ShopPromotion_PromotionId"))
			{
				SetChildren();
			}

			var c = (ShopPromotionCollection)this.ChildCollections["ShopPromotion_PromotionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public ShopItemPromotionCollection ShopItemPromotionsByPromotionId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("ShopItemPromotion_PromotionId"))
			{
				SetChildren();
			}

			var c = (ShopItemPromotionCollection)this.ChildCollections["ShopItemPromotion_PromotionId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<ShopPromotion, Shop> Shops
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Promotion_ShopPromotion_Shop"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<ShopPromotion, Shop>)this.ChildCollections["Promotion_ShopPromotion_Shop"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<ShopItemPromotion, ShopItem> ShopItems
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Promotion_ShopItemPromotion_ShopItem"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<ShopItemPromotion, ShopItem>)this.ChildCollections["Promotion_ShopItemPromotion_ShopItem"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PromotionColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Promotion table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PromotionCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Promotion>();
			Database db = database ?? Db.For<Promotion>();
			var results = new PromotionCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Promotion GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Promotion GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PromotionCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PromotionCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PromotionColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PromotionColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionCollection Where(Func<PromotionColumns, QueryFilter<PromotionColumns>> where, OrderBy<PromotionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Promotion>();
			return new PromotionCollection(database.GetQuery<PromotionColumns, Promotion>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionCollection Where(WhereDelegate<PromotionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Promotion>();
			var results = new PromotionCollection(database, database.GetQuery<PromotionColumns, Promotion>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionCollection Where(WhereDelegate<PromotionColumns> where, OrderBy<PromotionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Promotion>();
			var results = new PromotionCollection(database, database.GetQuery<PromotionColumns, Promotion>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PromotionCollection Where(QiQuery where, Database database = null)
		{
			var results = new PromotionCollection(database, Select<PromotionColumns>.From<Promotion>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Promotion GetOneWhere(QueryFilter where, Database database = null)
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
		public static Promotion OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PromotionColumns> whereDelegate = (c) => where;
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
		public static Promotion GetOneWhere(WhereDelegate<PromotionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PromotionColumns c = new PromotionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Promotion instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Promotion OneWhere(WhereDelegate<PromotionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Promotion OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Promotion FirstOneWhere(WhereDelegate<PromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Promotion FirstOneWhere(WhereDelegate<PromotionColumns> where, OrderBy<PromotionColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Promotion FirstOneWhere(QueryFilter where, OrderBy<PromotionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PromotionColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCollection Top(int count, WhereDelegate<PromotionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionCollection Top(int count, WhereDelegate<PromotionColumns> where, OrderBy<PromotionColumns> orderBy, Database database = null)
		{
			PromotionColumns c = new PromotionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Promotion>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Promotion>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionCollection>(0);
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
		public static PromotionCollection Top(int count, QueryFilter where, OrderBy<PromotionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Promotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<Promotion>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PromotionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionCollection>(0);
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
		public static PromotionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Promotion>();
			QuerySet query = GetQuerySet(db);
			query.Top<Promotion>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PromotionCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PromotionColumns> where, Database database = null)
		{
			PromotionColumns c = new PromotionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Promotion>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Promotion>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Promotion CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Promotion>();			
			var dao = new Promotion();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Promotion OneOrThrow(PromotionCollection c)
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
