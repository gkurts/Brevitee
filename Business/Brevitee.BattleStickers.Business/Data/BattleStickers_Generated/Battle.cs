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
	[Brevitee.Data.Table("Battle", "BattleStickers")]
	public partial class Battle: Dao
	{
		public Battle():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Battle(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Battle(DataRow data)
		{
			return new Battle(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("PlayerOne_BattleId", new PlayerOneCollection(Database.GetQuery<PlayerOneColumns, PlayerOne>((c) => c.BattleId == this.Id), this, "BattleId"));	﻿
            this.ChildCollections.Add("PlayerTwo_BattleId", new PlayerTwoCollection(Database.GetQuery<PlayerTwoColumns, PlayerTwo>((c) => c.BattleId == this.Id), this, "BattleId"));							
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

﻿	// property:MaxActiveCharacters, columnName:MaxActiveCharacters	
	[Brevitee.Data.Column(Name="MaxActiveCharacters", DbDataType="Int", MaxLength="10", AllowNull=false)]
	public int? MaxActiveCharacters
	{
		get
		{
			return GetIntValue("MaxActiveCharacters");
		}
		set
		{
			SetValue("MaxActiveCharacters", value);
		}
	}



﻿	// start RockPaperScissorsWinnerId -> RockPaperScissorsWinnerId
	[Brevitee.Data.ForeignKey(
        Table="Battle",
		Name="RockPaperScissorsWinnerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Player",
		Suffix="1")]
	public long? RockPaperScissorsWinnerId
	{
		get
		{
			return GetLongValue("RockPaperScissorsWinnerId");
		}
		set
		{
			SetValue("RockPaperScissorsWinnerId", value);
		}
	}

	Player _playerOfRockPaperScissorsWinnerId;
	public Player PlayerOfRockPaperScissorsWinnerId
	{
		get
		{
			if(_playerOfRockPaperScissorsWinnerId == null)
			{
				_playerOfRockPaperScissorsWinnerId = Brevitee.BattleStickers.Services.Data.Player.OneWhere(c => c.KeyColumn == this.RockPaperScissorsWinnerId);
			}
			return _playerOfRockPaperScissorsWinnerId;
		}
	}
	
				
﻿
	[Exclude]	
	public PlayerOneCollection PlayerOnesByBattleId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOne_BattleId"))
			{
				SetChildren();
			}

			var c = (PlayerOneCollection)this.ChildCollections["PlayerOne_BattleId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoCollection PlayerTwosByBattleId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwo_BattleId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoCollection)this.ChildCollections["PlayerTwo_BattleId"];
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
			var colFilter = new BattleColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Battle table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static BattleCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Battle>();
			Database db = database ?? Db.For<Battle>();
			var results = new BattleCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Battle GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Battle GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static BattleCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static BattleCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<BattleColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a BattleColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static BattleCollection Where(Func<BattleColumns, QueryFilter<BattleColumns>> where, OrderBy<BattleColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Battle>();
			return new BattleCollection(database.GetQuery<BattleColumns, Battle>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static BattleCollection Where(WhereDelegate<BattleColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Battle>();
			var results = new BattleCollection(database, database.GetQuery<BattleColumns, Battle>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static BattleCollection Where(WhereDelegate<BattleColumns> where, OrderBy<BattleColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Battle>();
			var results = new BattleCollection(database, database.GetQuery<BattleColumns, Battle>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<BattleColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static BattleCollection Where(QiQuery where, Database database = null)
		{
			var results = new BattleCollection(database, Select<BattleColumns>.From<Battle>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Battle GetOneWhere(QueryFilter where, Database database = null)
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
		public static Battle OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<BattleColumns> whereDelegate = (c) => where;
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
		public static Battle GetOneWhere(WhereDelegate<BattleColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				BattleColumns c = new BattleColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Battle instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Battle OneWhere(WhereDelegate<BattleColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<BattleColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Battle OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Battle FirstOneWhere(WhereDelegate<BattleColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Battle FirstOneWhere(WhereDelegate<BattleColumns> where, OrderBy<BattleColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Battle FirstOneWhere(QueryFilter where, OrderBy<BattleColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<BattleColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BattleCollection Top(int count, WhereDelegate<BattleColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static BattleCollection Top(int count, WhereDelegate<BattleColumns> where, OrderBy<BattleColumns> orderBy, Database database = null)
		{
			BattleColumns c = new BattleColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Battle>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Battle>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<BattleColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<BattleCollection>(0);
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
		public static BattleCollection Top(int count, QueryFilter where, OrderBy<BattleColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Battle>();
			QuerySet query = GetQuerySet(db);
			query.Top<Battle>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<BattleColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<BattleCollection>(0);
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
		public static BattleCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Battle>();
			QuerySet query = GetQuerySet(db);
			query.Top<Battle>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<BattleCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BattleColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BattleColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<BattleColumns> where, Database database = null)
		{
			BattleColumns c = new BattleColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Battle>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Battle>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Battle CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Battle>();			
			var dao = new Battle();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Battle OneOrThrow(BattleCollection c)
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
