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
	[Brevitee.Data.Table("EffectOverTime", "BattleStickers")]
	public partial class EffectOverTime: Dao
	{
		public EffectOverTime():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public EffectOverTime(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator EffectOverTime(DataRow data)
		{
			return new EffectOverTime(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("Weapon_EffectOverTimeId", new WeaponCollection(Database.GetQuery<WeaponColumns, Weapon>((c) => c.EffectOverTimeId == this.Id), this, "EffectOverTimeId"));	﻿
            this.ChildCollections.Add("Spell_EffectOverTimeId", new SpellCollection(Database.GetQuery<SpellColumns, Spell>((c) => c.EffectOverTimeId == this.Id), this, "EffectOverTimeId"));	﻿
            this.ChildCollections.Add("Skill_EffectOverTimeId", new SkillCollection(Database.GetQuery<SkillColumns, Skill>((c) => c.EffectOverTimeId == this.Id), this, "EffectOverTimeId"));							
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



				
﻿
	[Exclude]	
	public WeaponCollection WeaponsByEffectOverTimeId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Weapon_EffectOverTimeId"))
			{
				SetChildren();
			}

			var c = (WeaponCollection)this.ChildCollections["Weapon_EffectOverTimeId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public SpellCollection SpellsByEffectOverTimeId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Spell_EffectOverTimeId"))
			{
				SetChildren();
			}

			var c = (SpellCollection)this.ChildCollections["Spell_EffectOverTimeId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public SkillCollection SkillsByEffectOverTimeId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Skill_EffectOverTimeId"))
			{
				SetChildren();
			}

			var c = (SkillCollection)this.ChildCollections["Skill_EffectOverTimeId"];
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
			var colFilter = new EffectOverTimeColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the EffectOverTime table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static EffectOverTimeCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<EffectOverTime>();
			Database db = database ?? Db.For<EffectOverTime>();
			var results = new EffectOverTimeCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static EffectOverTime GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static EffectOverTime GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static EffectOverTimeCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static EffectOverTimeCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<EffectOverTimeColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a EffectOverTimeColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EffectOverTimeCollection Where(Func<EffectOverTimeColumns, QueryFilter<EffectOverTimeColumns>> where, OrderBy<EffectOverTimeColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<EffectOverTime>();
			return new EffectOverTimeCollection(database.GetQuery<EffectOverTimeColumns, EffectOverTime>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EffectOverTimeCollection Where(WhereDelegate<EffectOverTimeColumns> where, Database database = null)
		{		
			database = database ?? Db.For<EffectOverTime>();
			var results = new EffectOverTimeCollection(database, database.GetQuery<EffectOverTimeColumns, EffectOverTime>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTimeCollection Where(WhereDelegate<EffectOverTimeColumns> where, OrderBy<EffectOverTimeColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<EffectOverTime>();
			var results = new EffectOverTimeCollection(database, database.GetQuery<EffectOverTimeColumns, EffectOverTime>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EffectOverTimeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EffectOverTimeCollection Where(QiQuery where, Database database = null)
		{
			var results = new EffectOverTimeCollection(database, Select<EffectOverTimeColumns>.From<EffectOverTime>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static EffectOverTime GetOneWhere(QueryFilter where, Database database = null)
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
		public static EffectOverTime OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<EffectOverTimeColumns> whereDelegate = (c) => where;
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
		public static EffectOverTime GetOneWhere(WhereDelegate<EffectOverTimeColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				EffectOverTimeColumns c = new EffectOverTimeColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single EffectOverTime instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTime OneWhere(WhereDelegate<EffectOverTimeColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EffectOverTimeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EffectOverTime OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTime FirstOneWhere(WhereDelegate<EffectOverTimeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTime FirstOneWhere(WhereDelegate<EffectOverTimeColumns> where, OrderBy<EffectOverTimeColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTime FirstOneWhere(QueryFilter where, OrderBy<EffectOverTimeColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<EffectOverTimeColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTimeCollection Top(int count, WhereDelegate<EffectOverTimeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EffectOverTimeCollection Top(int count, WhereDelegate<EffectOverTimeColumns> where, OrderBy<EffectOverTimeColumns> orderBy, Database database = null)
		{
			EffectOverTimeColumns c = new EffectOverTimeColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<EffectOverTime>();
			QuerySet query = GetQuerySet(db); 
			query.Top<EffectOverTime>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<EffectOverTimeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EffectOverTimeCollection>(0);
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
		public static EffectOverTimeCollection Top(int count, QueryFilter where, OrderBy<EffectOverTimeColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<EffectOverTime>();
			QuerySet query = GetQuerySet(db);
			query.Top<EffectOverTime>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<EffectOverTimeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EffectOverTimeCollection>(0);
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
		public static EffectOverTimeCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<EffectOverTime>();
			QuerySet query = GetQuerySet(db);
			query.Top<EffectOverTime>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<EffectOverTimeCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectOverTimeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectOverTimeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<EffectOverTimeColumns> where, Database database = null)
		{
			EffectOverTimeColumns c = new EffectOverTimeColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<EffectOverTime>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<EffectOverTime>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static EffectOverTime CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<EffectOverTime>();			
			var dao = new EffectOverTime();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static EffectOverTime OneOrThrow(EffectOverTimeCollection c)
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
