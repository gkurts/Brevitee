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
	[Brevitee.Data.Table("Character", "BattleStickers")]
	public partial class Character: Dao
	{
		public Character():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Character(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Character(DataRow data)
		{
			return new Character(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerTwoCharacterHealth_CharacterId", new PlayerTwoCharacterHealthCollection(Database.GetQuery<PlayerTwoCharacterHealthColumns, PlayerTwoCharacterHealth>((c) => c.CharacterId == this.Id), this, "CharacterId"));	﻿
            this.ChildCollections.Add("PlayerOneCharacterHealth_CharacterId", new PlayerOneCharacterHealthCollection(Database.GetQuery<PlayerOneCharacterHealthColumns, PlayerOneCharacterHealth>((c) => c.CharacterId == this.Id), this, "CharacterId"));	﻿
            this.ChildCollections.Add("PlayerCharacter_CharacterId", new PlayerCharacterCollection(Database.GetQuery<PlayerCharacterColumns, PlayerCharacter>((c) => c.CharacterId == this.Id), this, "CharacterId"));	﻿
            this.ChildCollections.Add("PlayerOneCharacter_CharacterId", new PlayerOneCharacterCollection(Database.GetQuery<PlayerOneCharacterColumns, PlayerOneCharacter>((c) => c.CharacterId == this.Id), this, "CharacterId"));	﻿
            this.ChildCollections.Add("PlayerTwoCharacter_CharacterId", new PlayerTwoCharacterCollection(Database.GetQuery<PlayerTwoCharacterColumns, PlayerTwoCharacter>((c) => c.CharacterId == this.Id), this, "CharacterId"));	﻿
            this.ChildCollections.Add("RequiredLevelCharacter_CharacterId", new RequiredLevelCharacterCollection(Database.GetQuery<RequiredLevelCharacterColumns, RequiredLevelCharacter>((c) => c.CharacterId == this.Id), this, "CharacterId"));							﻿
            this.ChildCollections.Add("Character_PlayerCharacter_Player",  new XrefDaoCollection<PlayerCharacter, Player>(this, false));
				﻿
            this.ChildCollections.Add("Character_PlayerOneCharacter_PlayerOne",  new XrefDaoCollection<PlayerOneCharacter, PlayerOne>(this, false));
				﻿
            this.ChildCollections.Add("Character_PlayerTwoCharacter_PlayerTwo",  new XrefDaoCollection<PlayerTwoCharacter, PlayerTwo>(this, false));
				﻿
            this.ChildCollections.Add("Character_RequiredLevelCharacter_RequiredLevel",  new XrefDaoCollection<RequiredLevelCharacter, RequiredLevel>(this, false));
				
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

﻿	// property:Defense, columnName:Defense	
	[Brevitee.Data.Column(Name="Defense", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Defense
	{
		get
		{
			return GetIntValue("Defense");
		}
		set
		{
			SetValue("Defense", value);
		}
	}

﻿	// property:Speed, columnName:Speed	
	[Brevitee.Data.Column(Name="Speed", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Speed
	{
		get
		{
			return GetIntValue("Speed");
		}
		set
		{
			SetValue("Speed", value);
		}
	}

﻿	// property:Magic, columnName:Magic	
	[Brevitee.Data.Column(Name="Magic", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Magic
	{
		get
		{
			return GetIntValue("Magic");
		}
		set
		{
			SetValue("Magic", value);
		}
	}

﻿	// property:Acuracy, columnName:Acuracy	
	[Brevitee.Data.Column(Name="Acuracy", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Acuracy
	{
		get
		{
			return GetIntValue("Acuracy");
		}
		set
		{
			SetValue("Acuracy", value);
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

﻿	// property:MaxHealth, columnName:MaxHealth	
	[Brevitee.Data.Column(Name="MaxHealth", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? MaxHealth
	{
		get
		{
			return GetIntValue("MaxHealth");
		}
		set
		{
			SetValue("MaxHealth", value);
		}
	}



				
﻿
	[Exclude]	
	public PlayerTwoCharacterHealthCollection PlayerTwoCharacterHealthsByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoCharacterHealth_CharacterId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoCharacterHealthCollection)this.ChildCollections["PlayerTwoCharacterHealth_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneCharacterHealthCollection PlayerOneCharacterHealthsByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneCharacterHealth_CharacterId"))
			{
				SetChildren();
			}

			var c = (PlayerOneCharacterHealthCollection)this.ChildCollections["PlayerOneCharacterHealth_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerCharacterCollection PlayerCharactersByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerCharacter_CharacterId"))
			{
				SetChildren();
			}

			var c = (PlayerCharacterCollection)this.ChildCollections["PlayerCharacter_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneCharacterCollection PlayerOneCharactersByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneCharacter_CharacterId"))
			{
				SetChildren();
			}

			var c = (PlayerOneCharacterCollection)this.ChildCollections["PlayerOneCharacter_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoCharacterCollection PlayerTwoCharactersByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoCharacter_CharacterId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoCharacterCollection)this.ChildCollections["PlayerTwoCharacter_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelCharacterCollection RequiredLevelCharactersByCharacterId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelCharacter_CharacterId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelCharacterCollection)this.ChildCollections["RequiredLevelCharacter_CharacterId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<PlayerCharacter, Player> Players
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Character_PlayerCharacter_Player"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerCharacter, Player>)this.ChildCollections["Character_PlayerCharacter_Player"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerOneCharacter, PlayerOne> PlayerOnes
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Character_PlayerOneCharacter_PlayerOne"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerOneCharacter, PlayerOne>)this.ChildCollections["Character_PlayerOneCharacter_PlayerOne"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoCharacter, PlayerTwo> PlayerTwos
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Character_PlayerTwoCharacter_PlayerTwo"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoCharacter, PlayerTwo>)this.ChildCollections["Character_PlayerTwoCharacter_PlayerTwo"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelCharacter, RequiredLevel> RequiredLevels
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Character_RequiredLevelCharacter_RequiredLevel"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelCharacter, RequiredLevel>)this.ChildCollections["Character_RequiredLevelCharacter_RequiredLevel"];
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
			var colFilter = new CharacterColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Character table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static CharacterCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Character>();
			Database db = database ?? Db.For<Character>();
			var results = new CharacterCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Character GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Character GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static CharacterCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static CharacterCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<CharacterColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a CharacterColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CharacterCollection Where(Func<CharacterColumns, QueryFilter<CharacterColumns>> where, OrderBy<CharacterColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Character>();
			return new CharacterCollection(database.GetQuery<CharacterColumns, Character>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CharacterCollection Where(WhereDelegate<CharacterColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Character>();
			var results = new CharacterCollection(database, database.GetQuery<CharacterColumns, Character>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CharacterCollection Where(WhereDelegate<CharacterColumns> where, OrderBy<CharacterColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Character>();
			var results = new CharacterCollection(database, database.GetQuery<CharacterColumns, Character>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static CharacterCollection Where(QiQuery where, Database database = null)
		{
			var results = new CharacterCollection(database, Select<CharacterColumns>.From<Character>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Character GetOneWhere(QueryFilter where, Database database = null)
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
		public static Character OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<CharacterColumns> whereDelegate = (c) => where;
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
		public static Character GetOneWhere(WhereDelegate<CharacterColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				CharacterColumns c = new CharacterColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Character instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Character OneWhere(WhereDelegate<CharacterColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Character OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Character FirstOneWhere(WhereDelegate<CharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Character FirstOneWhere(WhereDelegate<CharacterColumns> where, OrderBy<CharacterColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Character FirstOneWhere(QueryFilter where, OrderBy<CharacterColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<CharacterColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CharacterCollection Top(int count, WhereDelegate<CharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CharacterCollection Top(int count, WhereDelegate<CharacterColumns> where, OrderBy<CharacterColumns> orderBy, Database database = null)
		{
			CharacterColumns c = new CharacterColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Character>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Character>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<CharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CharacterCollection>(0);
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
		public static CharacterCollection Top(int count, QueryFilter where, OrderBy<CharacterColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Character>();
			QuerySet query = GetQuerySet(db);
			query.Top<Character>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<CharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CharacterCollection>(0);
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
		public static CharacterCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Character>();
			QuerySet query = GetQuerySet(db);
			query.Top<Character>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<CharacterCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<CharacterColumns> where, Database database = null)
		{
			CharacterColumns c = new CharacterColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Character>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Character>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Character CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Character>();			
			var dao = new Character();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Character OneOrThrow(CharacterCollection c)
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
