// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.BattleStickers.Services.Data
{
	// schema = BattleStickers
	// connection Name = BattleStickers
	[Serializable]
	[Brevitee.Data.Table("Weapon", "BattleStickers")]
	public partial class Weapon: Dao
	{
		public Weapon():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Weapon(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Weapon(DataRow data)
		{
			return new Weapon(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerWeapon_WeaponId", new PlayerWeaponCollection(Database.GetQuery<PlayerWeaponColumns, PlayerWeapon>((c) => c.WeaponId == this.Id), this, "WeaponId"));	﻿
            this.ChildCollections.Add("PlayerOneWeapon_WeaponId", new PlayerOneWeaponCollection(Database.GetQuery<PlayerOneWeaponColumns, PlayerOneWeapon>((c) => c.WeaponId == this.Id), this, "WeaponId"));	﻿
            this.ChildCollections.Add("PlayerTwoWeapon_WeaponId", new PlayerTwoWeaponCollection(Database.GetQuery<PlayerTwoWeaponColumns, PlayerTwoWeapon>((c) => c.WeaponId == this.Id), this, "WeaponId"));	﻿
            this.ChildCollections.Add("RequiredLevelWeapon_WeaponId", new RequiredLevelWeaponCollection(Database.GetQuery<RequiredLevelWeaponColumns, RequiredLevelWeapon>((c) => c.WeaponId == this.Id), this, "WeaponId"));							﻿
            this.ChildCollections.Add("Weapon_PlayerWeapon_Player",  new XrefDaoCollection<PlayerWeapon, Player>(this, false));
				﻿
            this.ChildCollections.Add("Weapon_PlayerOneWeapon_PlayerOne",  new XrefDaoCollection<PlayerOneWeapon, PlayerOne>(this, false));
				﻿
            this.ChildCollections.Add("Weapon_PlayerTwoWeapon_PlayerTwo",  new XrefDaoCollection<PlayerTwoWeapon, PlayerTwo>(this, false));
				﻿
            this.ChildCollections.Add("Weapon_RequiredLevelWeapon_RequiredLevel",  new XrefDaoCollection<RequiredLevelWeapon, RequiredLevel>(this, false));
				
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

﻿	// property:Strength, columnName:Strength	
	[Brevitee.Data.Column(Name="Strength", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Strength
	{
		get
		{
			return GetIntValue("Strength");
		}
		set
		{
			SetValue("Strength", value);
		}
	}

﻿	// property:Element, columnName:Element	
	[Brevitee.Data.Column(Name="Element", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Element
	{
		get
		{
			return GetStringValue("Element");
		}
		set
		{
			SetValue("Element", value);
		}
	}



﻿	// start EffectOverTimeId -> EffectOverTimeId
	[Brevitee.Data.ForeignKey(
        Table="Weapon",
		Name="EffectOverTimeId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="EffectOverTime",
		Suffix="1")]
	public long? EffectOverTimeId
	{
		get
		{
			return GetLongValue("EffectOverTimeId");
		}
		set
		{
			SetValue("EffectOverTimeId", value);
		}
	}

	EffectOverTime _effectOverTimeOfEffectOverTimeId;
	public EffectOverTime EffectOverTimeOfEffectOverTimeId
	{
		get
		{
			if(_effectOverTimeOfEffectOverTimeId == null)
			{
				_effectOverTimeOfEffectOverTimeId = Brevitee.BattleStickers.Services.Data.EffectOverTime.OneWhere(c => c.KeyColumn == this.EffectOverTimeId);
			}
			return _effectOverTimeOfEffectOverTimeId;
		}
	}
	
				
﻿
	[Exclude]	
	public PlayerWeaponCollection PlayerWeaponsByWeaponId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerWeapon_WeaponId"))
			{
				SetChildren();
			}

			var c = (PlayerWeaponCollection)this.ChildCollections["PlayerWeapon_WeaponId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneWeaponCollection PlayerOneWeaponsByWeaponId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneWeapon_WeaponId"))
			{
				SetChildren();
			}

			var c = (PlayerOneWeaponCollection)this.ChildCollections["PlayerOneWeapon_WeaponId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoWeaponCollection PlayerTwoWeaponsByWeaponId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoWeapon_WeaponId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoWeaponCollection)this.ChildCollections["PlayerTwoWeapon_WeaponId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelWeaponCollection RequiredLevelWeaponsByWeaponId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelWeapon_WeaponId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelWeaponCollection)this.ChildCollections["RequiredLevelWeapon_WeaponId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<PlayerWeapon, Player> Players
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Weapon_PlayerWeapon_Player"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerWeapon, Player>)this.ChildCollections["Weapon_PlayerWeapon_Player"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerOneWeapon, PlayerOne> PlayerOnes
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Weapon_PlayerOneWeapon_PlayerOne"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerOneWeapon, PlayerOne>)this.ChildCollections["Weapon_PlayerOneWeapon_PlayerOne"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoWeapon, PlayerTwo> PlayerTwos
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Weapon_PlayerTwoWeapon_PlayerTwo"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoWeapon, PlayerTwo>)this.ChildCollections["Weapon_PlayerTwoWeapon_PlayerTwo"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelWeapon, RequiredLevel> RequiredLevels
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Weapon_RequiredLevelWeapon_RequiredLevel"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelWeapon, RequiredLevel>)this.ChildCollections["Weapon_RequiredLevelWeapon_RequiredLevel"];
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
			var colFilter = new WeaponColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Weapon table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static WeaponCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Weapon>();
			Database db = database ?? Db.For<Weapon>();
			var results = new WeaponCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Weapon GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Weapon GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static WeaponCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static WeaponCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<WeaponColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a WeaponColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static WeaponCollection Where(Func<WeaponColumns, QueryFilter<WeaponColumns>> where, OrderBy<WeaponColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Weapon>();
			return new WeaponCollection(database.GetQuery<WeaponColumns, Weapon>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static WeaponCollection Where(WhereDelegate<WeaponColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Weapon>();
			var results = new WeaponCollection(database, database.GetQuery<WeaponColumns, Weapon>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static WeaponCollection Where(WhereDelegate<WeaponColumns> where, OrderBy<WeaponColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Weapon>();
			var results = new WeaponCollection(database, database.GetQuery<WeaponColumns, Weapon>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<WeaponColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static WeaponCollection Where(QiQuery where, Database database = null)
		{
			var results = new WeaponCollection(database, Select<WeaponColumns>.From<Weapon>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Weapon GetOneWhere(QueryFilter where, Database database = null)
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
		public static Weapon OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<WeaponColumns> whereDelegate = (c) => where;
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
		public static Weapon GetOneWhere(WhereDelegate<WeaponColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				WeaponColumns c = new WeaponColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Weapon instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Weapon OneWhere(WhereDelegate<WeaponColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<WeaponColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Weapon OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Weapon FirstOneWhere(WhereDelegate<WeaponColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Weapon FirstOneWhere(WhereDelegate<WeaponColumns> where, OrderBy<WeaponColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Weapon FirstOneWhere(QueryFilter where, OrderBy<WeaponColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<WeaponColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static WeaponCollection Top(int count, WhereDelegate<WeaponColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static WeaponCollection Top(int count, WhereDelegate<WeaponColumns> where, OrderBy<WeaponColumns> orderBy, Database database = null)
		{
			WeaponColumns c = new WeaponColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Weapon>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Weapon>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<WeaponColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<WeaponCollection>(0);
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
		public static WeaponCollection Top(int count, QueryFilter where, OrderBy<WeaponColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Weapon>();
			QuerySet query = GetQuerySet(db);
			query.Top<Weapon>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<WeaponColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<WeaponCollection>(0);
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
		public static WeaponCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Weapon>();
			QuerySet query = GetQuerySet(db);
			query.Top<Weapon>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<WeaponCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a WeaponColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between WeaponColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<WeaponColumns> where, Database database = null)
		{
			WeaponColumns c = new WeaponColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Weapon>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Weapon>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Weapon CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Weapon>();			
			var dao = new Weapon();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Weapon OneOrThrow(WeaponCollection c)
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
