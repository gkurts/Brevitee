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
	[Brevitee.Data.Table("PlayerOneSpell", "BattleStickers")]
	public partial class PlayerOneSpell: Dao
	{
		public PlayerOneSpell():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PlayerOneSpell(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PlayerOneSpell(DataRow data)
		{
			return new PlayerOneSpell(data);
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



﻿	// start PlayerOneId -> PlayerOneId
	[Brevitee.Data.ForeignKey(
        Table="PlayerOneSpell",
		Name="PlayerOneId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
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
	
﻿	// start SpellId -> SpellId
	[Brevitee.Data.ForeignKey(
        Table="PlayerOneSpell",
		Name="SpellId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Spell",
		Suffix="2")]
	public long? SpellId
	{
		get
		{
			return GetLongValue("SpellId");
		}
		set
		{
			SetValue("SpellId", value);
		}
	}

	Spell _spellOfSpellId;
	public Spell SpellOfSpellId
	{
		get
		{
			if(_spellOfSpellId == null)
			{
				_spellOfSpellId = Brevitee.BattleStickers.Services.Data.Spell.OneWhere(c => c.KeyColumn == this.SpellId);
			}
			return _spellOfSpellId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PlayerOneSpellColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PlayerOneSpell table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PlayerOneSpellCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PlayerOneSpell>();
			Database db = database ?? Db.For<PlayerOneSpell>();
			var results = new PlayerOneSpellCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PlayerOneSpell GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PlayerOneSpell GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PlayerOneSpellCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PlayerOneSpellCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PlayerOneSpellColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PlayerOneSpellColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerOneSpellCollection Where(Func<PlayerOneSpellColumns, QueryFilter<PlayerOneSpellColumns>> where, OrderBy<PlayerOneSpellColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PlayerOneSpell>();
			return new PlayerOneSpellCollection(database.GetQuery<PlayerOneSpellColumns, PlayerOneSpell>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PlayerOneSpellCollection Where(WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PlayerOneSpell>();
			var results = new PlayerOneSpellCollection(database, database.GetQuery<PlayerOneSpellColumns, PlayerOneSpell>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpellCollection Where(WhereDelegate<PlayerOneSpellColumns> where, OrderBy<PlayerOneSpellColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PlayerOneSpell>();
			var results = new PlayerOneSpellCollection(database, database.GetQuery<PlayerOneSpellColumns, PlayerOneSpell>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerOneSpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerOneSpellCollection Where(QiQuery where, Database database = null)
		{
			var results = new PlayerOneSpellCollection(database, Select<PlayerOneSpellColumns>.From<PlayerOneSpell>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PlayerOneSpell GetOneWhere(QueryFilter where, Database database = null)
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
		public static PlayerOneSpell OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PlayerOneSpellColumns> whereDelegate = (c) => where;
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
		public static PlayerOneSpell GetOneWhere(WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PlayerOneSpellColumns c = new PlayerOneSpellColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PlayerOneSpell instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpell OneWhere(WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PlayerOneSpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PlayerOneSpell OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpell FirstOneWhere(WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpell FirstOneWhere(WhereDelegate<PlayerOneSpellColumns> where, OrderBy<PlayerOneSpellColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpell FirstOneWhere(QueryFilter where, OrderBy<PlayerOneSpellColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PlayerOneSpellColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpellCollection Top(int count, WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PlayerOneSpellCollection Top(int count, WhereDelegate<PlayerOneSpellColumns> where, OrderBy<PlayerOneSpellColumns> orderBy, Database database = null)
		{
			PlayerOneSpellColumns c = new PlayerOneSpellColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PlayerOneSpell>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PlayerOneSpell>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PlayerOneSpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerOneSpellCollection>(0);
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
		public static PlayerOneSpellCollection Top(int count, QueryFilter where, OrderBy<PlayerOneSpellColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneSpell>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerOneSpell>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PlayerOneSpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PlayerOneSpellCollection>(0);
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
		public static PlayerOneSpellCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneSpell>();
			QuerySet query = GetQuerySet(db);
			query.Top<PlayerOneSpell>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PlayerOneSpellCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PlayerOneSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PlayerOneSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PlayerOneSpellColumns> where, Database database = null)
		{
			PlayerOneSpellColumns c = new PlayerOneSpellColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PlayerOneSpell>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PlayerOneSpell>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PlayerOneSpell CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PlayerOneSpell>();			
			var dao = new PlayerOneSpell();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PlayerOneSpell OneOrThrow(PlayerOneSpellCollection c)
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
