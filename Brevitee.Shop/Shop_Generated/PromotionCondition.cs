// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Shop
{
	// schema = Shop
	// connection Name = Shop
	[Serializable]
	[Brevitee.Data.Table("PromotionCondition", "Shop")]
	public partial class PromotionCondition: Dao
	{
		public PromotionCondition():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public PromotionCondition(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator PromotionCondition(DataRow data)
		{
			return new PromotionCondition(data);
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

﻿	// property:Description, columnName:Description	
	[Brevitee.Data.Column(Name="Description", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Description
	{
		get
		{
			return GetStringValue("Description");
		}
		set
		{
			SetValue("Description", value);
		}
	}

﻿	// property:Value, columnName:Value	
	[Brevitee.Data.Column(Name="Value", DbDataType="VarBinary", MaxLength="8000", AllowNull=false)]
	public byte[] Value
	{
		get
		{
			return GetByteValue("Value");
		}
		set
		{
			SetValue("Value", value);
		}
	}



﻿	// start PromotionId -> PromotionId
	[Brevitee.Data.ForeignKey(
        Table="PromotionCondition",
		Name="PromotionId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Promotion",
		Suffix="1")]
	public long? PromotionId
	{
		get
		{
			return GetLongValue("PromotionId");
		}
		set
		{
			SetValue("PromotionId", value);
		}
	}

	Promotion _promotionOfPromotionId;
	public Promotion PromotionOfPromotionId
	{
		get
		{
			if(_promotionOfPromotionId == null)
			{
				_promotionOfPromotionId = Brevitee.Shop.Promotion.OneWhere(c => c.KeyColumn == this.PromotionId);
			}
			return _promotionOfPromotionId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new PromotionConditionColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the PromotionCondition table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static PromotionConditionCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<PromotionCondition>();
			Database db = database ?? Db.For<PromotionCondition>();
			var results = new PromotionConditionCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static PromotionCondition GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static PromotionCondition GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static PromotionConditionCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static PromotionConditionCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<PromotionConditionColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a PromotionConditionColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionConditionCollection Where(Func<PromotionConditionColumns, QueryFilter<PromotionConditionColumns>> where, OrderBy<PromotionConditionColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<PromotionCondition>();
			return new PromotionConditionCollection(database.GetQuery<PromotionConditionColumns, PromotionCondition>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static PromotionConditionCollection Where(WhereDelegate<PromotionConditionColumns> where, Database database = null)
		{		
			database = database ?? Db.For<PromotionCondition>();
			var results = new PromotionConditionCollection(database, database.GetQuery<PromotionConditionColumns, PromotionCondition>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionConditionCollection Where(WhereDelegate<PromotionConditionColumns> where, OrderBy<PromotionConditionColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<PromotionCondition>();
			var results = new PromotionConditionCollection(database, database.GetQuery<PromotionConditionColumns, PromotionCondition>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionConditionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PromotionConditionCollection Where(QiQuery where, Database database = null)
		{
			var results = new PromotionConditionCollection(database, Select<PromotionConditionColumns>.From<PromotionCondition>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static PromotionCondition GetOneWhere(QueryFilter where, Database database = null)
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
		public static PromotionCondition OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<PromotionConditionColumns> whereDelegate = (c) => where;
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
		public static PromotionCondition GetOneWhere(WhereDelegate<PromotionConditionColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				PromotionConditionColumns c = new PromotionConditionColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single PromotionCondition instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCondition OneWhere(WhereDelegate<PromotionConditionColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<PromotionConditionColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static PromotionCondition OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCondition FirstOneWhere(WhereDelegate<PromotionConditionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCondition FirstOneWhere(WhereDelegate<PromotionConditionColumns> where, OrderBy<PromotionConditionColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionCondition FirstOneWhere(QueryFilter where, OrderBy<PromotionConditionColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<PromotionConditionColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static PromotionConditionCollection Top(int count, WhereDelegate<PromotionConditionColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static PromotionConditionCollection Top(int count, WhereDelegate<PromotionConditionColumns> where, OrderBy<PromotionConditionColumns> orderBy, Database database = null)
		{
			PromotionConditionColumns c = new PromotionConditionColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<PromotionCondition>();
			QuerySet query = GetQuerySet(db); 
			query.Top<PromotionCondition>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<PromotionConditionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionConditionCollection>(0);
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
		public static PromotionConditionCollection Top(int count, QueryFilter where, OrderBy<PromotionConditionColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCondition>();
			QuerySet query = GetQuerySet(db);
			query.Top<PromotionCondition>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<PromotionConditionColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<PromotionConditionCollection>(0);
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
		public static PromotionConditionCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCondition>();
			QuerySet query = GetQuerySet(db);
			query.Top<PromotionCondition>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<PromotionConditionCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a PromotionConditionColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between PromotionConditionColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<PromotionConditionColumns> where, Database database = null)
		{
			PromotionConditionColumns c = new PromotionConditionColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<PromotionCondition>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<PromotionCondition>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static PromotionCondition CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<PromotionCondition>();			
			var dao = new PromotionCondition();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static PromotionCondition OneOrThrow(PromotionConditionCollection c)
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
