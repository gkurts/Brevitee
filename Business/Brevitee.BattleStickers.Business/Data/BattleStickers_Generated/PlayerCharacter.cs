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
	[Brevitee.Data.Table("PlayerCharacter", "BattleStickers")]
	public partial class PlayerCharacter: Dao
	{
		public PlayerCharacter():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerCharacter(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerCharacter(DataRow data)
		{
			return new PlayerCharacter(data);
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



﻿	// start PlayerId -> PlayerId
	[Brevitee.Data.ForeignKey(
        Table="PlayerCharacter",
		Name="PlayerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Player",
		Suffix="1")]
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
	
﻿	// start CharacterId -> CharacterId
	[Brevitee.Data.ForeignKey(
        Table="PlayerCharacter",
		Name="CharacterId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Character",
		Suffix="2")]
	public long? CharacterId
	{
		get
		{
			return GetLongValue("CharacterId");
		}
		set
		{
			SetValue("CharacterId", value);
		}
	}

	Character _characterOfCharacterId;
	public Character CharacterOfCharacterId
	{
		get
		{
			if(_characterOfCharacterId == null)
			{
				_characterOfCharacterId = Brevitee.BattleStickers.Services.Data.Character.OneWhere(c => c.KeyColumn == this.CharacterId);
			}
			return _characterOfCharacterId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PlayerCharacterColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerCharacter table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerCharacterCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerCharacter>();
			Database db = database ?? Db.For<PlayerCharacter>();
			var results = new PlayerCharacterCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerCharacter GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerCharacter GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerCharacterCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerCharacterCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerCharacterColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerCharacterColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerCharacterCollection Where(Func<PlayerCharacterColumns, QueryFilter<PlayerCharacterColumns>> where, OrderBy<PlayerCharacterColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerCharacter>();
			return new PlayerCharacterCollection(database.GetQuery<PlayerCharacterColumns, PlayerCharacter>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerCharacterCollection Where(WhereDelegate<PlayerCharacterColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerCharacter>();
			var results = new PlayerCharacterCollection(database, database.GetQuery<PlayerCharacterColumns, PlayerCharacter>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacterCollection Where(WhereDelegate<PlayerCharacterColumns> where, OrderBy<PlayerCharacterColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerCharacter>();
			var results = new PlayerCharacterCollection(database, database.GetQuery<PlayerCharacterColumns, PlayerCharacter>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerCharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerCharacterCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerCharacterCollection(database, Select<PlayerCharacterColumns>.From<PlayerCharacter>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerCharacter GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerCharacter OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerCharacterColumns> whereDelegate = (c) => where;
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
		public static PlayerCharacter GetOneWhere(WhereDelegate<PlayerCharacterColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerCharacterColumns c = new PlayerCharacterColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerCharacter instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacter OneWhere(WhereDelegate<PlayerCharacterColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerCharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerCharacter OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacter FirstOneWhere(WhereDelegate<PlayerCharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacter FirstOneWhere(WhereDelegate<PlayerCharacterColumns> where, OrderBy<PlayerCharacterColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacter FirstOneWhere(QueryFilter where, OrderBy<PlayerCharacterColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerCharacterColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacterCollection Top(int count, WhereDelegate<PlayerCharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerCharacterCollection Top(int count, WhereDelegate<PlayerCharacterColumns> where, OrderBy<PlayerCharacterColumns> orderBy, Database database = null)
		{
			PlayerCharacterColumns c = new PlayerCharacterColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerCharacter>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerCharacter>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerCharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerCharacterCollection>(0);
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
		public static PlayerCharacterCollection Top(int count, QueryFilter where, OrderBy<PlayerCharacterColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerCharacter>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerCharacter>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerCharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerCharacterCollection>(0);
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
		public static PlayerCharacterCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerCharacter>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerCharacter>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerCharacterCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerCharacterColumns> where, Database database = null)
		{
			PlayerCharacterColumns c = new PlayerCharacterColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerCharacter>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerCharacter>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerCharacter CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerCharacter>();			
			var dao = new PlayerCharacter();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerCharacter OneOrThrow(PlayerCharacterCollection c)
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