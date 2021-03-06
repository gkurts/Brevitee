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
	[Brevitee.Data.Table("Spell", "BattleStickers")]
	public partial class Spell: Dao
	{
		public Spell():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Spell(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Spell(DataRow data)
		{
			return new Spell(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerSpell_SpellId", new PlayerSpellCollection(Database.GetQuery<PlayerSpellColumns, PlayerSpell>((c) => c.SpellId == this.Id), this, "SpellId"));	﻿
            this.ChildCollections.Add("PlayerOneSpell_SpellId", new PlayerOneSpellCollection(Database.GetQuery<PlayerOneSpellColumns, PlayerOneSpell>((c) => c.SpellId == this.Id), this, "SpellId"));	﻿
            this.ChildCollections.Add("PlayerTwoSpell_SpellId", new PlayerTwoSpellCollection(Database.GetQuery<PlayerTwoSpellColumns, PlayerTwoSpell>((c) => c.SpellId == this.Id), this, "SpellId"));	﻿
            this.ChildCollections.Add("RequiredLevelSpell_SpellId", new RequiredLevelSpellCollection(Database.GetQuery<RequiredLevelSpellColumns, RequiredLevelSpell>((c) => c.SpellId == this.Id), this, "SpellId"));							﻿
            this.ChildCollections.Add("Spell_PlayerSpell_Player",  new XrefDaoCollection<PlayerSpell, Player>(this, false));
				﻿
            this.ChildCollections.Add("Spell_PlayerOneSpell_PlayerOne",  new XrefDaoCollection<PlayerOneSpell, PlayerOne>(this, false));
				﻿
            this.ChildCollections.Add("Spell_PlayerTwoSpell_PlayerTwo",  new XrefDaoCollection<PlayerTwoSpell, PlayerTwo>(this, false));
				﻿
            this.ChildCollections.Add("Spell_RequiredLevelSpell_RequiredLevel",  new XrefDaoCollection<RequiredLevelSpell, RequiredLevel>(this, false));
				
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
        Table="Spell",
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
	public PlayerSpellCollection PlayerSpellsBySpellId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerSpell_SpellId"))
			{
				SetChildren();
			}

			var c = (PlayerSpellCollection)this.ChildCollections["PlayerSpell_SpellId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneSpellCollection PlayerOneSpellsBySpellId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneSpell_SpellId"))
			{
				SetChildren();
			}

			var c = (PlayerOneSpellCollection)this.ChildCollections["PlayerOneSpell_SpellId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoSpellCollection PlayerTwoSpellsBySpellId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoSpell_SpellId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoSpellCollection)this.ChildCollections["PlayerTwoSpell_SpellId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelSpellCollection RequiredLevelSpellsBySpellId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelSpell_SpellId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelSpellCollection)this.ChildCollections["RequiredLevelSpell_SpellId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<PlayerSpell, Player> Players
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Spell_PlayerSpell_Player"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerSpell, Player>)this.ChildCollections["Spell_PlayerSpell_Player"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerOneSpell, PlayerOne> PlayerOnes
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Spell_PlayerOneSpell_PlayerOne"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerOneSpell, PlayerOne>)this.ChildCollections["Spell_PlayerOneSpell_PlayerOne"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoSpell, PlayerTwo> PlayerTwos
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Spell_PlayerTwoSpell_PlayerTwo"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoSpell, PlayerTwo>)this.ChildCollections["Spell_PlayerTwoSpell_PlayerTwo"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelSpell, RequiredLevel> RequiredLevels
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Spell_RequiredLevelSpell_RequiredLevel"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelSpell, RequiredLevel>)this.ChildCollections["Spell_RequiredLevelSpell_RequiredLevel"];
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
			var colFilter = new SpellColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Spell table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SpellCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Spell>();
			Database db = database ?? Db.For<Spell>();
			var results = new SpellCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Spell GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Spell GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SpellCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SpellCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SpellColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SpellColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SpellCollection Where(Func<SpellColumns, QueryFilter<SpellColumns>> where, OrderBy<SpellColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Spell>();
			return new SpellCollection(database.GetQuery<SpellColumns, Spell>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SpellCollection Where(WhereDelegate<SpellColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Spell>();
			var results = new SpellCollection(database, database.GetQuery<SpellColumns, Spell>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SpellCollection Where(WhereDelegate<SpellColumns> where, OrderBy<SpellColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Spell>();
			var results = new SpellCollection(database, database.GetQuery<SpellColumns, Spell>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SpellCollection Where(QiQuery where, Database database = null)
		{
			var results = new SpellCollection(database, Select<SpellColumns>.From<Spell>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Spell GetOneWhere(QueryFilter where, Database database = null)
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
		public static Spell OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SpellColumns> whereDelegate = (c) => where;
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
		public static Spell GetOneWhere(WhereDelegate<SpellColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SpellColumns c = new SpellColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Spell instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Spell OneWhere(WhereDelegate<SpellColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Spell OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Spell FirstOneWhere(WhereDelegate<SpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Spell FirstOneWhere(WhereDelegate<SpellColumns> where, OrderBy<SpellColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Spell FirstOneWhere(QueryFilter where, OrderBy<SpellColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SpellColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SpellCollection Top(int count, WhereDelegate<SpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SpellCollection Top(int count, WhereDelegate<SpellColumns> where, OrderBy<SpellColumns> orderBy, Database database = null)
		{
			SpellColumns c = new SpellColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Spell>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Spell>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SpellCollection>(0);
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
		public static SpellCollection Top(int count, QueryFilter where, OrderBy<SpellColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Spell>();
			QuerySet query = GetQuerySet(db);
			query.Top<Spell>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SpellCollection>(0);
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
		public static SpellCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Spell>();
			QuerySet query = GetQuerySet(db);
			query.Top<Spell>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SpellCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SpellColumns> where, Database database = null)
		{
			SpellColumns c = new SpellColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Spell>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Spell>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Spell CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Spell>();			
			var dao = new Spell();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Spell OneOrThrow(SpellCollection c)
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
