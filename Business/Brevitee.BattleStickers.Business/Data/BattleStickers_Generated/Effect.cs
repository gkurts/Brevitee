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
	[Brevitee.Data.Table("Effect", "BattleStickers")]
	public partial class Effect: Dao
	{
		public Effect():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Effect(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Effect(DataRow data)
		{
			return new Effect(data);
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

﻿	// property:Attribute, columnName:Attribute	
	[Brevitee.Data.Column(Name="Attribute", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Attribute
	{
		get
		{
			return GetStringValue("Attribute");
		}
		set
		{
			SetValue("Attribute", value);
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



﻿	// start EquipmentId -> EquipmentId
	[Brevitee.Data.ForeignKey(
        Table="Effect",
		Name="EquipmentId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Equipment",
		Suffix="1")]
	public long? EquipmentId
	{
		get
		{
			return GetLongValue("EquipmentId");
		}
		set
		{
			SetValue("EquipmentId", value);
		}
	}

	Equipment _equipmentOfEquipmentId;
	public Equipment EquipmentOfEquipmentId
	{
		get
		{
			if(_equipmentOfEquipmentId == null)
			{
				_equipmentOfEquipmentId = Brevitee.BattleStickers.Services.Data.Equipment.OneWhere(c => c.KeyColumn == this.EquipmentId);
			}
			return _equipmentOfEquipmentId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new EffectColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Effect table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static EffectCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Effect>();
			Database db = database ?? Db.For<Effect>();
			var results = new EffectCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Effect GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Effect GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static EffectCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static EffectCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<EffectColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a EffectColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EffectCollection Where(Func<EffectColumns, QueryFilter<EffectColumns>> where, OrderBy<EffectColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Effect>();
			return new EffectCollection(database.GetQuery<EffectColumns, Effect>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EffectCollection Where(WhereDelegate<EffectColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Effect>();
			var results = new EffectCollection(database, database.GetQuery<EffectColumns, Effect>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EffectCollection Where(WhereDelegate<EffectColumns> where, OrderBy<EffectColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Effect>();
			var results = new EffectCollection(database, database.GetQuery<EffectColumns, Effect>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EffectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EffectCollection Where(QiQuery where, Database database = null)
		{
			var results = new EffectCollection(database, Select<EffectColumns>.From<Effect>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Effect GetOneWhere(QueryFilter where, Database database = null)
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
		public static Effect OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<EffectColumns> whereDelegate = (c) => where;
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
		public static Effect GetOneWhere(WhereDelegate<EffectColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				EffectColumns c = new EffectColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Effect instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Effect OneWhere(WhereDelegate<EffectColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EffectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Effect OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Effect FirstOneWhere(WhereDelegate<EffectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Effect FirstOneWhere(WhereDelegate<EffectColumns> where, OrderBy<EffectColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Effect FirstOneWhere(QueryFilter where, OrderBy<EffectColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<EffectColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EffectCollection Top(int count, WhereDelegate<EffectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EffectCollection Top(int count, WhereDelegate<EffectColumns> where, OrderBy<EffectColumns> orderBy, Database database = null)
		{
			EffectColumns c = new EffectColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Effect>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Effect>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<EffectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EffectCollection>(0);
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
		public static EffectCollection Top(int count, QueryFilter where, OrderBy<EffectColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Effect>();
			QuerySet query = GetQuerySet(db);
			query.Top<Effect>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<EffectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EffectCollection>(0);
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
		public static EffectCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Effect>();
			QuerySet query = GetQuerySet(db);
			query.Top<Effect>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<EffectCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EffectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EffectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<EffectColumns> where, Database database = null)
		{
			EffectColumns c = new EffectColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Effect>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Effect>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Effect CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Effect>();			
			var dao = new Effect();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Effect OneOrThrow(EffectCollection c)
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
