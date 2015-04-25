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
	[Brevitee.Data.Table("Skill", "BattleStickers")]
	public partial class Skill: Dao
	{
		public Skill():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Skill(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Skill(DataRow data)
		{
			return new Skill(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerSkill_SkillId", new PlayerSkillCollection(Database.GetQuery<PlayerSkillColumns, PlayerSkill>((c) => c.SkillId == this.Id), this, "SkillId"));	﻿
            this.ChildCollections.Add("PlayerOneSkill_SkillId", new PlayerOneSkillCollection(Database.GetQuery<PlayerOneSkillColumns, PlayerOneSkill>((c) => c.SkillId == this.Id), this, "SkillId"));	﻿
            this.ChildCollections.Add("PlayerTwoSkill_SkillId", new PlayerTwoSkillCollection(Database.GetQuery<PlayerTwoSkillColumns, PlayerTwoSkill>((c) => c.SkillId == this.Id), this, "SkillId"));	﻿
            this.ChildCollections.Add("RequiredLevelSkill_SkillId", new RequiredLevelSkillCollection(Database.GetQuery<RequiredLevelSkillColumns, RequiredLevelSkill>((c) => c.SkillId == this.Id), this, "SkillId"));							﻿
            this.ChildCollections.Add("Skill_PlayerSkill_Player",  new XrefDaoCollection<PlayerSkill, Player>(this, false));
				﻿
            this.ChildCollections.Add("Skill_PlayerOneSkill_PlayerOne",  new XrefDaoCollection<PlayerOneSkill, PlayerOne>(this, false));
				﻿
            this.ChildCollections.Add("Skill_PlayerTwoSkill_PlayerTwo",  new XrefDaoCollection<PlayerTwoSkill, PlayerTwo>(this, false));
				﻿
            this.ChildCollections.Add("Skill_RequiredLevelSkill_RequiredLevel",  new XrefDaoCollection<RequiredLevelSkill, RequiredLevel>(this, false));
				
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
        Table="Skill",
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
	public PlayerSkillCollection PlayerSkillsBySkillId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerSkill_SkillId"))
			{
				SetChildren();
			}

			var c = (PlayerSkillCollection)this.ChildCollections["PlayerSkill_SkillId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneSkillCollection PlayerOneSkillsBySkillId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneSkill_SkillId"))
			{
				SetChildren();
			}

			var c = (PlayerOneSkillCollection)this.ChildCollections["PlayerOneSkill_SkillId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoSkillCollection PlayerTwoSkillsBySkillId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoSkill_SkillId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoSkillCollection)this.ChildCollections["PlayerTwoSkill_SkillId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelSkillCollection RequiredLevelSkillsBySkillId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelSkill_SkillId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelSkillCollection)this.ChildCollections["RequiredLevelSkill_SkillId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<PlayerSkill, Player> Players
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Skill_PlayerSkill_Player"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerSkill, Player>)this.ChildCollections["Skill_PlayerSkill_Player"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerOneSkill, PlayerOne> PlayerOnes
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Skill_PlayerOneSkill_PlayerOne"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerOneSkill, PlayerOne>)this.ChildCollections["Skill_PlayerOneSkill_PlayerOne"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoSkill, PlayerTwo> PlayerTwos
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Skill_PlayerTwoSkill_PlayerTwo"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoSkill, PlayerTwo>)this.ChildCollections["Skill_PlayerTwoSkill_PlayerTwo"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelSkill, RequiredLevel> RequiredLevels
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Skill_RequiredLevelSkill_RequiredLevel"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelSkill, RequiredLevel>)this.ChildCollections["Skill_RequiredLevelSkill_RequiredLevel"];
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
			var colFilter = new SkillColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Skill table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SkillCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Skill>();
			Database db = database ?? Db.For<Skill>();
			var results = new SkillCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Skill GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Skill GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SkillCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SkillCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SkillColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SkillColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SkillCollection Where(Func<SkillColumns, QueryFilter<SkillColumns>> where, OrderBy<SkillColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Skill>();
			return new SkillCollection(database.GetQuery<SkillColumns, Skill>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SkillCollection Where(WhereDelegate<SkillColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Skill>();
			var results = new SkillCollection(database, database.GetQuery<SkillColumns, Skill>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SkillCollection Where(WhereDelegate<SkillColumns> where, OrderBy<SkillColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Skill>();
			var results = new SkillCollection(database, database.GetQuery<SkillColumns, Skill>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SkillColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SkillCollection Where(QiQuery where, Database database = null)
		{
			var results = new SkillCollection(database, Select<SkillColumns>.From<Skill>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Skill GetOneWhere(QueryFilter where, Database database = null)
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
		public static Skill OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SkillColumns> whereDelegate = (c) => where;
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
		public static Skill GetOneWhere(WhereDelegate<SkillColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SkillColumns c = new SkillColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Skill instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Skill OneWhere(WhereDelegate<SkillColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SkillColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Skill OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Skill FirstOneWhere(WhereDelegate<SkillColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Skill FirstOneWhere(WhereDelegate<SkillColumns> where, OrderBy<SkillColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Skill FirstOneWhere(QueryFilter where, OrderBy<SkillColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SkillColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SkillCollection Top(int count, WhereDelegate<SkillColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SkillCollection Top(int count, WhereDelegate<SkillColumns> where, OrderBy<SkillColumns> orderBy, Database database = null)
		{
			SkillColumns c = new SkillColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Skill>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Skill>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SkillColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SkillCollection>(0);
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
		public static SkillCollection Top(int count, QueryFilter where, OrderBy<SkillColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Skill>();
			QuerySet query = GetQuerySet(db);
			query.Top<Skill>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SkillColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SkillCollection>(0);
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
		public static SkillCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Skill>();
			QuerySet query = GetQuerySet(db);
			query.Top<Skill>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SkillCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SkillColumns> where, Database database = null)
		{
			SkillColumns c = new SkillColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Skill>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Skill>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Skill CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Skill>();			
			var dao = new Skill();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Skill OneOrThrow(SkillCollection c)
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
