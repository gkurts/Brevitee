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
	[Brevitee.Data.Table("PlayerTwoCharacterHealth", "BattleStickers")]
	public partial class PlayerTwoCharacterHealth: Dao
	{
		public PlayerTwoCharacterHealth():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerTwoCharacterHealth(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerTwoCharacterHealth(DataRow data)
		{
			return new PlayerTwoCharacterHealth(data);
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



﻿	// start PlayerTwoId -> PlayerTwoId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwoCharacterHealth",
		Name="PlayerTwoId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
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
	
﻿	// start CharacterId -> CharacterId
	[Brevitee.Data.ForeignKey(
        Table="PlayerTwoCharacterHealth",
		Name="CharacterId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
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
			var colFilter = new PlayerTwoCharacterHealthColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerTwoCharacterHealth table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerTwoCharacterHealthCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerTwoCharacterHealth>();
			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();
			var results = new PlayerTwoCharacterHealthCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerTwoCharacterHealth GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerTwoCharacterHealth GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerTwoCharacterHealthCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerTwoCharacterHealthCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerTwoCharacterHealthColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoCharacterHealthCollection Where(Func<PlayerTwoCharacterHealthColumns, QueryFilter<PlayerTwoCharacterHealthColumns>> where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerTwoCharacterHealth>();
			return new PlayerTwoCharacterHealthCollection(database.GetQuery<PlayerTwoCharacterHealthColumns, PlayerTwoCharacterHealth>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerTwoCharacterHealthCollection Where(WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwoCharacterHealth>();
			var results = new PlayerTwoCharacterHealthCollection(database, database.GetQuery<PlayerTwoCharacterHealthColumns, PlayerTwoCharacterHealth>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealthCollection Where(WhereDelegate<PlayerTwoCharacterHealthColumns> where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerTwoCharacterHealth>();
			var results = new PlayerTwoCharacterHealthCollection(database, database.GetQuery<PlayerTwoCharacterHealthColumns, PlayerTwoCharacterHealth>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoCharacterHealthColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealthCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerTwoCharacterHealthCollection(database, Select<PlayerTwoCharacterHealthColumns>.From<PlayerTwoCharacterHealth>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerTwoCharacterHealth GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerTwoCharacterHealth OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerTwoCharacterHealthColumns> whereDelegate = (c) => where;
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
		public static PlayerTwoCharacterHealth GetOneWhere(WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerTwoCharacterHealthColumns c = new PlayerTwoCharacterHealthColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerTwoCharacterHealth instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealth OneWhere(WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerTwoCharacterHealthColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealth OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealth FirstOneWhere(WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealth FirstOneWhere(WhereDelegate<PlayerTwoCharacterHealthColumns> where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealth FirstOneWhere(QueryFilter where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerTwoCharacterHealthColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealthCollection Top(int count, WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerTwoCharacterHealthCollection Top(int count, WhereDelegate<PlayerTwoCharacterHealthColumns> where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy, Database database = null)
		{
			PlayerTwoCharacterHealthColumns c = new PlayerTwoCharacterHealthColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerTwoCharacterHealth>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoCharacterHealthColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoCharacterHealthCollection>(0);
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
		public static PlayerTwoCharacterHealthCollection Top(int count, QueryFilter where, OrderBy<PlayerTwoCharacterHealthColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwoCharacterHealth>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerTwoCharacterHealthColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerTwoCharacterHealthCollection>(0);
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
		public static PlayerTwoCharacterHealthCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerTwoCharacterHealth>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerTwoCharacterHealthCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerTwoCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerTwoCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerTwoCharacterHealthColumns> where, Database database = null)
		{
			PlayerTwoCharacterHealthColumns c = new PlayerTwoCharacterHealthColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerTwoCharacterHealth>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerTwoCharacterHealth CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerTwoCharacterHealth>();			
			var dao = new PlayerTwoCharacterHealth();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerTwoCharacterHealth OneOrThrow(PlayerTwoCharacterHealthCollection c)
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
