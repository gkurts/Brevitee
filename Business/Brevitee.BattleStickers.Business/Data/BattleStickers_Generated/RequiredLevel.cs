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
	[Brevitee.Data.Table("RequiredLevel", "BattleStickers")]
	public partial class RequiredLevel: Dao
	{
		public RequiredLevel():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public RequiredLevel(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator RequiredLevel(DataRow data)
		{
			return new RequiredLevel(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("RequiredLevelCharacter_RequiredLevelId", new RequiredLevelCharacterCollection(Database.GetQuery<RequiredLevelCharacterColumns, RequiredLevelCharacter>((c) => c.RequiredLevelId == this.Id), this, "RequiredLevelId"));	﻿
            this.ChildCollections.Add("RequiredLevelWeapon_RequiredLevelId", new RequiredLevelWeaponCollection(Database.GetQuery<RequiredLevelWeaponColumns, RequiredLevelWeapon>((c) => c.RequiredLevelId == this.Id), this, "RequiredLevelId"));	﻿
            this.ChildCollections.Add("RequiredLevelSpell_RequiredLevelId", new RequiredLevelSpellCollection(Database.GetQuery<RequiredLevelSpellColumns, RequiredLevelSpell>((c) => c.RequiredLevelId == this.Id), this, "RequiredLevelId"));	﻿
            this.ChildCollections.Add("RequiredLevelSkill_RequiredLevelId", new RequiredLevelSkillCollection(Database.GetQuery<RequiredLevelSkillColumns, RequiredLevelSkill>((c) => c.RequiredLevelId == this.Id), this, "RequiredLevelId"));				﻿
            this.ChildCollections.Add("RequiredLevel_RequiredLevelCharacter_Character",  new XrefDaoCollection<RequiredLevelCharacter, Character>(this, false));
				﻿
            this.ChildCollections.Add("RequiredLevel_RequiredLevelWeapon_Weapon",  new XrefDaoCollection<RequiredLevelWeapon, Weapon>(this, false));
				﻿
            this.ChildCollections.Add("RequiredLevel_RequiredLevelSpell_Spell",  new XrefDaoCollection<RequiredLevelSpell, Spell>(this, false));
				﻿
            this.ChildCollections.Add("RequiredLevel_RequiredLevelSkill_Skill",  new XrefDaoCollection<RequiredLevelSkill, Skill>(this, false));
							
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
	[Brevitee.Data.Column(Name="Value", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? Value
	{
		get
		{
			return GetIntValue("Value");
		}
		set
		{
			SetValue("Value", value);
		}
	}



				
﻿
	[Exclude]	
	public RequiredLevelCharacterCollection RequiredLevelCharactersByRequiredLevelId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelCharacter_RequiredLevelId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelCharacterCollection)this.ChildCollections["RequiredLevelCharacter_RequiredLevelId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelWeaponCollection RequiredLevelWeaponsByRequiredLevelId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelWeapon_RequiredLevelId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelWeaponCollection)this.ChildCollections["RequiredLevelWeapon_RequiredLevelId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelSpellCollection RequiredLevelSpellsByRequiredLevelId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelSpell_RequiredLevelId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelSpellCollection)this.ChildCollections["RequiredLevelSpell_RequiredLevelId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public RequiredLevelSkillCollection RequiredLevelSkillsByRequiredLevelId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("RequiredLevelSkill_RequiredLevelId"))
			{
				SetChildren();
			}

			var c = (RequiredLevelSkillCollection)this.ChildCollections["RequiredLevelSkill_RequiredLevelId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			
﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelCharacter, Character> Characters
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("RequiredLevel_RequiredLevelCharacter_Character"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelCharacter, Character>)this.ChildCollections["RequiredLevel_RequiredLevelCharacter_Character"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelWeapon, Weapon> Weapons
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("RequiredLevel_RequiredLevelWeapon_Weapon"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelWeapon, Weapon>)this.ChildCollections["RequiredLevel_RequiredLevelWeapon_Weapon"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelSpell, Spell> Spells
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("RequiredLevel_RequiredLevelSpell_Spell"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelSpell, Spell>)this.ChildCollections["RequiredLevel_RequiredLevelSpell_Spell"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<RequiredLevelSkill, Skill> Skills
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("RequiredLevel_RequiredLevelSkill_Skill"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<RequiredLevelSkill, Skill>)this.ChildCollections["RequiredLevel_RequiredLevelSkill_Skill"];
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
			var colFilter = new RequiredLevelColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the RequiredLevel table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static RequiredLevelCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<RequiredLevel>();
			Database db = database ?? Db.For<RequiredLevel>();
			var results = new RequiredLevelCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static RequiredLevel GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static RequiredLevel GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static RequiredLevelCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static RequiredLevelCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<RequiredLevelColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a RequiredLevelColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelCollection Where(Func<RequiredLevelColumns, QueryFilter<RequiredLevelColumns>> where, OrderBy<RequiredLevelColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<RequiredLevel>();
			return new RequiredLevelCollection(database.GetQuery<RequiredLevelColumns, RequiredLevel>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelCollection Where(WhereDelegate<RequiredLevelColumns> where, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevel>();
			var results = new RequiredLevelCollection(database, database.GetQuery<RequiredLevelColumns, RequiredLevel>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCollection Where(WhereDelegate<RequiredLevelColumns> where, OrderBy<RequiredLevelColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevel>();
			var results = new RequiredLevelCollection(database, database.GetQuery<RequiredLevelColumns, RequiredLevel>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevelCollection Where(QiQuery where, Database database = null)
		{
			var results = new RequiredLevelCollection(database, Select<RequiredLevelColumns>.From<RequiredLevel>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static RequiredLevel GetOneWhere(QueryFilter where, Database database = null)
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
		public static RequiredLevel OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<RequiredLevelColumns> whereDelegate = (c) => where;
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
		public static RequiredLevel GetOneWhere(WhereDelegate<RequiredLevelColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				RequiredLevelColumns c = new RequiredLevelColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single RequiredLevel instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevel OneWhere(WhereDelegate<RequiredLevelColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevel OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevel FirstOneWhere(WhereDelegate<RequiredLevelColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevel FirstOneWhere(WhereDelegate<RequiredLevelColumns> where, OrderBy<RequiredLevelColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevel FirstOneWhere(QueryFilter where, OrderBy<RequiredLevelColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<RequiredLevelColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCollection Top(int count, WhereDelegate<RequiredLevelColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCollection Top(int count, WhereDelegate<RequiredLevelColumns> where, OrderBy<RequiredLevelColumns> orderBy, Database database = null)
		{
			RequiredLevelColumns c = new RequiredLevelColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<RequiredLevel>();
			QuerySet query = GetQuerySet(db); 
			query.Top<RequiredLevel>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelCollection>(0);
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
		public static RequiredLevelCollection Top(int count, QueryFilter where, OrderBy<RequiredLevelColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevel>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevel>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelCollection>(0);
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
		public static RequiredLevelCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevel>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevel>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<RequiredLevelCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<RequiredLevelColumns> where, Database database = null)
		{
			RequiredLevelColumns c = new RequiredLevelColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<RequiredLevel>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<RequiredLevel>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static RequiredLevel CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevel>();			
			var dao = new RequiredLevel();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static RequiredLevel OneOrThrow(RequiredLevelCollection c)
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
