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
	[Brevitee.Data.Table("RequiredLevelCharacter", "BattleStickers")]
	public partial class RequiredLevelCharacter: Dao
	{
		public RequiredLevelCharacter():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public RequiredLevelCharacter(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator RequiredLevelCharacter(DataRow data)
		{
			return new RequiredLevelCharacter(data);
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



﻿	// start RequiredLevelId -> RequiredLevelId
	[Brevitee.Data.ForeignKey(
        Table="RequiredLevelCharacter",
		Name="RequiredLevelId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="RequiredLevel",
		Suffix="1")]
	public long? RequiredLevelId
	{
		get
		{
			return GetLongValue("RequiredLevelId");
		}
		set
		{
			SetValue("RequiredLevelId", value);
		}
	}

	RequiredLevel _requiredLevelOfRequiredLevelId;
	public RequiredLevel RequiredLevelOfRequiredLevelId
	{
		get
		{
			if(_requiredLevelOfRequiredLevelId == null)
			{
				_requiredLevelOfRequiredLevelId = Brevitee.BattleStickers.Services.Data.RequiredLevel.OneWhere(c => c.KeyColumn == this.RequiredLevelId);
			}
			return _requiredLevelOfRequiredLevelId;
		}
	}
	
﻿	// start CharacterId -> CharacterId
	[Brevitee.Data.ForeignKey(
        Table="RequiredLevelCharacter",
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
			var colFilter = new RequiredLevelCharacterColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the RequiredLevelCharacter table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static RequiredLevelCharacterCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<RequiredLevelCharacter>();
			Database db = database ?? Db.For<RequiredLevelCharacter>();
			var results = new RequiredLevelCharacterCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static RequiredLevelCharacter GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static RequiredLevelCharacter GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static RequiredLevelCharacterCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static RequiredLevelCharacterCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<RequiredLevelCharacterColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelCharacterCollection Where(Func<RequiredLevelCharacterColumns, QueryFilter<RequiredLevelCharacterColumns>> where, OrderBy<RequiredLevelCharacterColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<RequiredLevelCharacter>();
			return new RequiredLevelCharacterCollection(database.GetQuery<RequiredLevelCharacterColumns, RequiredLevelCharacter>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelCharacterCollection Where(WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevelCharacter>();
			var results = new RequiredLevelCharacterCollection(database, database.GetQuery<RequiredLevelCharacterColumns, RequiredLevelCharacter>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacterCollection Where(WhereDelegate<RequiredLevelCharacterColumns> where, OrderBy<RequiredLevelCharacterColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevelCharacter>();
			var results = new RequiredLevelCharacterCollection(database, database.GetQuery<RequiredLevelCharacterColumns, RequiredLevelCharacter>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelCharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevelCharacterCollection Where(QiQuery where, Database database = null)
		{
			var results = new RequiredLevelCharacterCollection(database, Select<RequiredLevelCharacterColumns>.From<RequiredLevelCharacter>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static RequiredLevelCharacter GetOneWhere(QueryFilter where, Database database = null)
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
		public static RequiredLevelCharacter OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<RequiredLevelCharacterColumns> whereDelegate = (c) => where;
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
		public static RequiredLevelCharacter GetOneWhere(WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				RequiredLevelCharacterColumns c = new RequiredLevelCharacterColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single RequiredLevelCharacter instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacter OneWhere(WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelCharacterColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevelCharacter OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacter FirstOneWhere(WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacter FirstOneWhere(WhereDelegate<RequiredLevelCharacterColumns> where, OrderBy<RequiredLevelCharacterColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacter FirstOneWhere(QueryFilter where, OrderBy<RequiredLevelCharacterColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<RequiredLevelCharacterColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacterCollection Top(int count, WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelCharacterCollection Top(int count, WhereDelegate<RequiredLevelCharacterColumns> where, OrderBy<RequiredLevelCharacterColumns> orderBy, Database database = null)
		{
			RequiredLevelCharacterColumns c = new RequiredLevelCharacterColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<RequiredLevelCharacter>();
			QuerySet query = GetQuerySet(db); 
			query.Top<RequiredLevelCharacter>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelCharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelCharacterCollection>(0);
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
		public static RequiredLevelCharacterCollection Top(int count, QueryFilter where, OrderBy<RequiredLevelCharacterColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelCharacter>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevelCharacter>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelCharacterColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelCharacterCollection>(0);
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
		public static RequiredLevelCharacterCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelCharacter>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevelCharacter>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<RequiredLevelCharacterCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelCharacterColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelCharacterColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<RequiredLevelCharacterColumns> where, Database database = null)
		{
			RequiredLevelCharacterColumns c = new RequiredLevelCharacterColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<RequiredLevelCharacter>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<RequiredLevelCharacter>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static RequiredLevelCharacter CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelCharacter>();			
			var dao = new RequiredLevelCharacter();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static RequiredLevelCharacter OneOrThrow(RequiredLevelCharacterCollection c)
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
