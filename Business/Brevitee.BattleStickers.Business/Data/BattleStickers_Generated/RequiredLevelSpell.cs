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
	[Brevitee.Data.Table("RequiredLevelSpell", "BattleStickers")]
	public partial class RequiredLevelSpell: Dao
	{
		public RequiredLevelSpell():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public RequiredLevelSpell(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator RequiredLevelSpell(DataRow data)
		{
			return new RequiredLevelSpell(data);
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
        Table="RequiredLevelSpell",
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
	
﻿	// start SpellId -> SpellId
	[Brevitee.Data.ForeignKey(
        Table="RequiredLevelSpell",
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
			var colFilter = new RequiredLevelSpellColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the RequiredLevelSpell table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static RequiredLevelSpellCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<RequiredLevelSpell>();
			Database db = database ?? Db.For<RequiredLevelSpell>();
			var results = new RequiredLevelSpellCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static RequiredLevelSpell GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static RequiredLevelSpell GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static RequiredLevelSpellCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static RequiredLevelSpellCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<RequiredLevelSpellColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a RequiredLevelSpellColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelSpellCollection Where(Func<RequiredLevelSpellColumns, QueryFilter<RequiredLevelSpellColumns>> where, OrderBy<RequiredLevelSpellColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<RequiredLevelSpell>();
			return new RequiredLevelSpellCollection(database.GetQuery<RequiredLevelSpellColumns, RequiredLevelSpell>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static RequiredLevelSpellCollection Where(WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevelSpell>();
			var results = new RequiredLevelSpellCollection(database, database.GetQuery<RequiredLevelSpellColumns, RequiredLevelSpell>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpellCollection Where(WhereDelegate<RequiredLevelSpellColumns> where, OrderBy<RequiredLevelSpellColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<RequiredLevelSpell>();
			var results = new RequiredLevelSpellCollection(database, database.GetQuery<RequiredLevelSpellColumns, RequiredLevelSpell>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelSpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevelSpellCollection Where(QiQuery where, Database database = null)
		{
			var results = new RequiredLevelSpellCollection(database, Select<RequiredLevelSpellColumns>.From<RequiredLevelSpell>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static RequiredLevelSpell GetOneWhere(QueryFilter where, Database database = null)
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
		public static RequiredLevelSpell OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<RequiredLevelSpellColumns> whereDelegate = (c) => where;
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
		public static RequiredLevelSpell GetOneWhere(WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				RequiredLevelSpellColumns c = new RequiredLevelSpellColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single RequiredLevelSpell instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpell OneWhere(WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<RequiredLevelSpellColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static RequiredLevelSpell OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpell FirstOneWhere(WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpell FirstOneWhere(WhereDelegate<RequiredLevelSpellColumns> where, OrderBy<RequiredLevelSpellColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpell FirstOneWhere(QueryFilter where, OrderBy<RequiredLevelSpellColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<RequiredLevelSpellColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpellCollection Top(int count, WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static RequiredLevelSpellCollection Top(int count, WhereDelegate<RequiredLevelSpellColumns> where, OrderBy<RequiredLevelSpellColumns> orderBy, Database database = null)
		{
			RequiredLevelSpellColumns c = new RequiredLevelSpellColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<RequiredLevelSpell>();
			QuerySet query = GetQuerySet(db); 
			query.Top<RequiredLevelSpell>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelSpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelSpellCollection>(0);
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
		public static RequiredLevelSpellCollection Top(int count, QueryFilter where, OrderBy<RequiredLevelSpellColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelSpell>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevelSpell>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<RequiredLevelSpellColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<RequiredLevelSpellCollection>(0);
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
		public static RequiredLevelSpellCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelSpell>();
			QuerySet query = GetQuerySet(db);
			query.Top<RequiredLevelSpell>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<RequiredLevelSpellCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a RequiredLevelSpellColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between RequiredLevelSpellColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<RequiredLevelSpellColumns> where, Database database = null)
		{
			RequiredLevelSpellColumns c = new RequiredLevelSpellColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<RequiredLevelSpell>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<RequiredLevelSpell>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static RequiredLevelSpell CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<RequiredLevelSpell>();			
			var dao = new RequiredLevelSpell();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static RequiredLevelSpell OneOrThrow(RequiredLevelSpellCollection c)
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
