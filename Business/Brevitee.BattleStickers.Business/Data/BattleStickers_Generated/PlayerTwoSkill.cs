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
	[Brevitee.Data.Table("PlayerTwoSkill", "BattleStickers")]
	public partial class PlayerTwoSkill: Dao
	{
		public PlayerTwoSkill():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerTwoSkill(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerTwoSkill(DataRow data)
		{
			return new PlayerTwoSkill(data);
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



﻿	// start PlayerTwoId -> PlayerTwoId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwoSkill",
		Name="PlayerTwoId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="PlayerTwo",
		Suffix="1")]
	public long? PlayerTwoId
	{
		get
		{
			return GetLongValue("PlayerTwoId");
		}
		set
		{
			SetValue("PlayerTwoId", value);
		}
	}

	PlayerTwo _playerTwoOfPlayerTwoId;
	public PlayerTwo PlayerTwoOfPlayerTwoId
	{
		get
		{
			if(_playerTwoOfPlayerTwoId == null)
			{
				_playerTwoOfPlayerTwoId = Brevitee.BattleStickers.Services.Data.PlayerTwo.OneWhere(c => c.KeyColumn == this.PlayerTwoId);
			}
			return _playerTwoOfPlayerTwoId;
		}
	}
	
﻿	// start SkillId -> SkillId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwoSkill",
		Name="SkillId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Skill",
		Suffix="2")]
	public long? SkillId
	{
		get
		{
			return GetLongValue("SkillId");
		}
		set
		{
			SetValue("SkillId", value);
		}
	}

	Skill _skillOfSkillId;
	public Skill SkillOfSkillId
	{
		get
		{
			if(_skillOfSkillId == null)
			{
				_skillOfSkillId = Brevitee.BattleStickers.Services.Data.Skill.OneWhere(c => c.KeyColumn == this.SkillId);
			}
			return _skillOfSkillId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PlayerTwoSkillColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerTwoSkill table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerTwoSkillCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerTwoSkill>();
			Database db = database ?? Db.For<PlayerTwoSkill>();
			var results = new PlayerTwoSkillCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerTwoSkill GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerTwoSkill GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerTwoSkillCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerTwoSkillCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerTwoSkillColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerTwoSkillColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoSkillCollection Where(Func<PlayerTwoSkillColumns, QueryFilter<PlayerTwoSkillColumns>> where, OrderBy<PlayerTwoSkillColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerTwoSkill>();
			return new PlayerTwoSkillCollection(database.GetQuery<PlayerTwoSkillColumns, PlayerTwoSkill>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoSkillCollection Where(WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwoSkill>();
			var results = new PlayerTwoSkillCollection(database, database.GetQuery<PlayerTwoSkillColumns, PlayerTwoSkill>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkillCollection Where(WhereDelegate<PlayerTwoSkillColumns> where, OrderBy<PlayerTwoSkillColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwoSkill>();
			var results = new PlayerTwoSkillCollection(database, database.GetQuery<PlayerTwoSkillColumns, PlayerTwoSkill>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoSkillColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwoSkillCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerTwoSkillCollection(database, Select<PlayerTwoSkillColumns>.From<PlayerTwoSkill>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerTwoSkill GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerTwoSkill OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerTwoSkillColumns> whereDelegate = (c) => where;
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
		public static PlayerTwoSkill GetOneWhere(WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerTwoSkillColumns c = new PlayerTwoSkillColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerTwoSkill instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkill OneWhere(WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoSkillColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwoSkill OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkill FirstOneWhere(WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkill FirstOneWhere(WhereDelegate<PlayerTwoSkillColumns> where, OrderBy<PlayerTwoSkillColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkill FirstOneWhere(QueryFilter where, OrderBy<PlayerTwoSkillColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerTwoSkillColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkillCollection Top(int count, WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoSkillCollection Top(int count, WhereDelegate<PlayerTwoSkillColumns> where, OrderBy<PlayerTwoSkillColumns> orderBy, Database database = null)
		{
			PlayerTwoSkillColumns c = new PlayerTwoSkillColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerTwoSkill>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerTwoSkill>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoSkillColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoSkillCollection>(0);
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
		public static PlayerTwoSkillCollection Top(int count, QueryFilter where, OrderBy<PlayerTwoSkillColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoSkill>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwoSkill>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoSkillColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoSkillCollection>(0);
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
		public static PlayerTwoSkillCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoSkill>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwoSkill>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerTwoSkillCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoSkillColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoSkillColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerTwoSkillColumns> where, Database database = null)
		{
			PlayerTwoSkillColumns c = new PlayerTwoSkillColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerTwoSkill>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerTwoSkill>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerTwoSkill CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoSkill>();			
			var dao = new PlayerTwoSkill();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerTwoSkill OneOrThrow(PlayerTwoSkillCollection c)
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
