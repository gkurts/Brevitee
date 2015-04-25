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
	[Brevitee.Data.Table("PlayerTwo", "BattleStickers")]
	public partial class PlayerTwo: Dao
	{
		public PlayerTwo():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerTwo(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerTwo(DataRow data)
		{
			return new PlayerTwo(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerTwoCharacterHealth_PlayerTwoId", new PlayerTwoCharacterHealthCollection(Database.GetQuery<PlayerTwoCharacterHealthColumns, PlayerTwoCharacterHealth>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));	﻿
            this.ChildCollections.Add("PlayerTwoCharacter_PlayerTwoId", new PlayerTwoCharacterCollection(Database.GetQuery<PlayerTwoCharacterColumns, PlayerTwoCharacter>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));	﻿
            this.ChildCollections.Add("PlayerTwoWeapon_PlayerTwoId", new PlayerTwoWeaponCollection(Database.GetQuery<PlayerTwoWeaponColumns, PlayerTwoWeapon>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));	﻿
            this.ChildCollections.Add("PlayerTwoSpell_PlayerTwoId", new PlayerTwoSpellCollection(Database.GetQuery<PlayerTwoSpellColumns, PlayerTwoSpell>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));	﻿
            this.ChildCollections.Add("PlayerTwoSkill_PlayerTwoId", new PlayerTwoSkillCollection(Database.GetQuery<PlayerTwoSkillColumns, PlayerTwoSkill>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));	﻿
            this.ChildCollections.Add("PlayerTwoEquipment_PlayerTwoId", new PlayerTwoEquipmentCollection(Database.GetQuery<PlayerTwoEquipmentColumns, PlayerTwoEquipment>((c) => c.PlayerTwoId == this.Id), this, "PlayerTwoId"));				﻿
            this.ChildCollections.Add("PlayerTwo_PlayerTwoCharacter_Character",  new XrefDaoCollection<PlayerTwoCharacter, Character>(this, false));
				﻿
            this.ChildCollections.Add("PlayerTwo_PlayerTwoWeapon_Weapon",  new XrefDaoCollection<PlayerTwoWeapon, Weapon>(this, false));
				﻿
            this.ChildCollections.Add("PlayerTwo_PlayerTwoSpell_Spell",  new XrefDaoCollection<PlayerTwoSpell, Spell>(this, false));
				﻿
            this.ChildCollections.Add("PlayerTwo_PlayerTwoSkill_Skill",  new XrefDaoCollection<PlayerTwoSkill, Skill>(this, false));
				﻿
            this.ChildCollections.Add("PlayerTwo_PlayerTwoEquipment_Equipment",  new XrefDaoCollection<PlayerTwoEquipment, Equipment>(this, false));
							
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



﻿	// start BattleId -> BattleId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwo",
		Name="BattleId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Battle",
		Suffix="1")]
	public long? BattleId
	{
		get
		{
			return GetLongValue("BattleId");
		}
		set
		{
			SetValue("BattleId", value);
		}
	}

	Battle _battleOfBattleId;
	public Battle BattleOfBattleId
	{
		get
		{
			if(_battleOfBattleId == null)
			{
				_battleOfBattleId = Brevitee.BattleStickers.Services.Data.Battle.OneWhere(c => c.KeyColumn == this.BattleId);
			}
			return _battleOfBattleId;
		}
	}
	
﻿	// start PlayerId -> PlayerId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwo",
		Name="PlayerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Player",
		Suffix="2")]
	public long? PlayerId
	{
		get
		{
			return GetLongValue("PlayerId");
		}
		set
		{
			SetValue("PlayerId", value);
		}
	}

	Player _playerOfPlayerId;
	public Player PlayerOfPlayerId
	{
		get
		{
			if(_playerOfPlayerId == null)
			{
				_playerOfPlayerId = Brevitee.BattleStickers.Services.Data.Player.OneWhere(c => c.KeyColumn == this.PlayerId);
			}
			return _playerOfPlayerId;
		}
	}
	
				
﻿
	[Exclude]	
	public PlayerTwoCharacterHealthCollection PlayerTwoCharacterHealthsByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoCharacterHealth_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoCharacterHealthCollection)this.ChildCollections["PlayerTwoCharacterHealth_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoCharacterCollection PlayerTwoCharactersByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoCharacter_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoCharacterCollection)this.ChildCollections["PlayerTwoCharacter_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoWeaponCollection PlayerTwoWeaponsByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoWeapon_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoWeaponCollection)this.ChildCollections["PlayerTwoWeapon_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoSpellCollection PlayerTwoSpellsByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoSpell_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoSpellCollection)this.ChildCollections["PlayerTwoSpell_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoSkillCollection PlayerTwoSkillsByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoSkill_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoSkillCollection)this.ChildCollections["PlayerTwoSkill_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoEquipmentCollection PlayerTwoEquipmentsByPlayerTwoId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoEquipment_PlayerTwoId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoEquipmentCollection)this.ChildCollections["PlayerTwoEquipment_PlayerTwoId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			
﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoCharacter, Character> Characters
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("PlayerTwo_PlayerTwoCharacter_Character"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoCharacter, Character>)this.ChildCollections["PlayerTwo_PlayerTwoCharacter_Character"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoWeapon, Weapon> Weapons
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("PlayerTwo_PlayerTwoWeapon_Weapon"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoWeapon, Weapon>)this.ChildCollections["PlayerTwo_PlayerTwoWeapon_Weapon"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoSpell, Spell> Spells
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("PlayerTwo_PlayerTwoSpell_Spell"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoSpell, Spell>)this.ChildCollections["PlayerTwo_PlayerTwoSpell_Spell"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoSkill, Skill> Skills
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("PlayerTwo_PlayerTwoSkill_Skill"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoSkill, Skill>)this.ChildCollections["PlayerTwo_PlayerTwoSkill_Skill"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoEquipment, Equipment> Equipments
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("PlayerTwo_PlayerTwoEquipment_Equipment"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoEquipment, Equipment>)this.ChildCollections["PlayerTwo_PlayerTwoEquipment_Equipment"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }
		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PlayerTwoColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerTwo table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerTwoCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerTwo>();
			Database db = database ?? Db.For<PlayerTwo>();
			var results = new PlayerTwoCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerTwo GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerTwo GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerTwoCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerTwoCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerTwoColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerTwoColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoCollection Where(Func<PlayerTwoColumns, QueryFilter<PlayerTwoColumns>> where, OrderBy<PlayerTwoColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerTwo>();
			return new PlayerTwoCollection(database.GetQuery<PlayerTwoColumns, PlayerTwo>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoCollection Where(WhereDelegate<PlayerTwoColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwo>();
			var results = new PlayerTwoCollection(database, database.GetQuery<PlayerTwoColumns, PlayerTwo>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCollection Where(WhereDelegate<PlayerTwoColumns> where, OrderBy<PlayerTwoColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwo>();
			var results = new PlayerTwoCollection(database, database.GetQuery<PlayerTwoColumns, PlayerTwo>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwoCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerTwoCollection(database, Select<PlayerTwoColumns>.From<PlayerTwo>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerTwo GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerTwo OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerTwoColumns> whereDelegate = (c) => where;
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
		public static PlayerTwo GetOneWhere(WhereDelegate<PlayerTwoColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerTwoColumns c = new PlayerTwoColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerTwo instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwo OneWhere(WhereDelegate<PlayerTwoColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwo OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwo FirstOneWhere(WhereDelegate<PlayerTwoColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwo FirstOneWhere(WhereDelegate<PlayerTwoColumns> where, OrderBy<PlayerTwoColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwo FirstOneWhere(QueryFilter where, OrderBy<PlayerTwoColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerTwoColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCollection Top(int count, WhereDelegate<PlayerTwoColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCollection Top(int count, WhereDelegate<PlayerTwoColumns> where, OrderBy<PlayerTwoColumns> orderBy, Database database = null)
		{
			PlayerTwoColumns c = new PlayerTwoColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerTwo>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerTwo>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoCollection>(0);
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
		public static PlayerTwoCollection Top(int count, QueryFilter where, OrderBy<PlayerTwoColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwo>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwo>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoCollection>(0);
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
		public static PlayerTwoCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwo>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwo>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerTwoCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerTwoColumns> where, Database database = null)
		{
			PlayerTwoColumns c = new PlayerTwoColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerTwo>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerTwo>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerTwo CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwo>();			
			var dao = new PlayerTwo();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerTwo OneOrThrow(PlayerTwoCollection c)
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
