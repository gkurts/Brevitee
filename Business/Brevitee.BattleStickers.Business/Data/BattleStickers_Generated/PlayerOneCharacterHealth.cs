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
	[Brevitee.Data.Table("PlayerOneCharacterHealth", "BattleStickers")]
	public partial class PlayerOneCharacterHealth: Dao
	{
		public PlayerOneCharacterHealth():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerOneCharacterHealth(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerOneCharacterHealth(DataRow data)
		{
			return new PlayerOneCharacterHealth(data);
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



﻿	// start PlayerOneId -> PlayerOneId
	[Brevitee.Data.ForeignKey(
        Table="PlayerOneCharacterHealth",
		Name="PlayerOneId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="PlayerOne",
		Suffix="1")]
	public long? PlayerOneId
	{
		get
		{
			return GetLongValue("PlayerOneId");
		}
		set
		{
			SetValue("PlayerOneId", value);
		}
	}

	PlayerOne _playerOneOfPlayerOneId;
	public PlayerOne PlayerOneOfPlayerOneId
	{
		get
		{
			if(_playerOneOfPlayerOneId == null)
			{
				_playerOneOfPlayerOneId = Brevitee.BattleStickers.Services.Data.PlayerOne.OneWhere(c => c.KeyColumn == this.PlayerOneId);
			}
			return _playerOneOfPlayerOneId;
		}
	}
	
﻿	// start CharacterId -> CharacterId
	[Brevitee.Data.ForeignKey(
        Table="PlayerOneCharacterHealth",
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
			var colFilter = new PlayerOneCharacterHealthColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerOneCharacterHealth table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerOneCharacterHealthCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerOneCharacterHealth>();
			Database db = database ?? Db.For<PlayerOneCharacterHealth>();
			var results = new PlayerOneCharacterHealthCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerOneCharacterHealth GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerOneCharacterHealth GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerOneCharacterHealthCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerOneCharacterHealthCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerOneCharacterHealthColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerOneCharacterHealthCollection Where(Func<PlayerOneCharacterHealthColumns, QueryFilter<PlayerOneCharacterHealthColumns>> where, OrderBy<PlayerOneCharacterHealthColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerOneCharacterHealth>();
			return new PlayerOneCharacterHealthCollection(database.GetQuery<PlayerOneCharacterHealthColumns, PlayerOneCharacterHealth>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerOneCharacterHealthCollection Where(WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerOneCharacterHealth>();
			var results = new PlayerOneCharacterHealthCollection(database, database.GetQuery<PlayerOneCharacterHealthColumns, PlayerOneCharacterHealth>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealthCollection Where(WhereDelegate<PlayerOneCharacterHealthColumns> where, OrderBy<PlayerOneCharacterHealthColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerOneCharacterHealth>();
			var results = new PlayerOneCharacterHealthCollection(database, database.GetQuery<PlayerOneCharacterHealthColumns, PlayerOneCharacterHealth>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerOneCharacterHealthColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealthCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerOneCharacterHealthCollection(database, Select<PlayerOneCharacterHealthColumns>.From<PlayerOneCharacterHealth>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerOneCharacterHealth GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerOneCharacterHealth OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerOneCharacterHealthColumns> whereDelegate = (c) => where;
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
		public static PlayerOneCharacterHealth GetOneWhere(WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerOneCharacterHealthColumns c = new PlayerOneCharacterHealthColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerOneCharacterHealth instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealth OneWhere(WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerOneCharacterHealthColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealth OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealth FirstOneWhere(WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealth FirstOneWhere(WhereDelegate<PlayerOneCharacterHealthColumns> where, OrderBy<PlayerOneCharacterHealthColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealth FirstOneWhere(QueryFilter where, OrderBy<PlayerOneCharacterHealthColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerOneCharacterHealthColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealthCollection Top(int count, WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneCharacterHealthCollection Top(int count, WhereDelegate<PlayerOneCharacterHealthColumns> where, OrderBy<PlayerOneCharacterHealthColumns> orderBy, Database database = null)
		{
			PlayerOneCharacterHealthColumns c = new PlayerOneCharacterHealthColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerOneCharacterHealth>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerOneCharacterHealth>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerOneCharacterHealthColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerOneCharacterHealthCollection>(0);
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
		public static PlayerOneCharacterHealthCollection Top(int count, QueryFilter where, OrderBy<PlayerOneCharacterHealthColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneCharacterHealth>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerOneCharacterHealth>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerOneCharacterHealthColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerOneCharacterHealthCollection>(0);
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
		public static PlayerOneCharacterHealthCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneCharacterHealth>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerOneCharacterHealth>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerOneCharacterHealthCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneCharacterHealthColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneCharacterHealthColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerOneCharacterHealthColumns> where, Database database = null)
		{
			PlayerOneCharacterHealthColumns c = new PlayerOneCharacterHealthColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerOneCharacterHealth>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerOneCharacterHealth>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerOneCharacterHealth CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneCharacterHealth>();			
			var dao = new PlayerOneCharacterHealth();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerOneCharacterHealth OneOrThrow(PlayerOneCharacterHealthCollection c)
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
