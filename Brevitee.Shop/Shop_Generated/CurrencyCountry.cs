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
	[Brevitee.Data.Table("CurrencyCountry", "Shop")]
	public partial class CurrencyCountry: Dao
	{
		public CurrencyCountry():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public CurrencyCountry(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator CurrencyCountry(DataRow data)
		{
			return new CurrencyCountry(data);
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

﻿	// property:Name, columnName:Name	
	[Brevitee.Data.Column(Name="Name", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Name
	{
		get
		{
			return GetStringValue("Name");
		}
		set
		{
			SetValue("Name", value);
		}
	}



﻿	// start CurrencyId -> CurrencyId
	[Brevitee.Data.ForeignKey(
        Table="CurrencyCountry",
		Name="CurrencyId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Currency",
		Suffix="1")]
	public long? CurrencyId
	{
		get
		{
			return GetLongValue("CurrencyId");
		}
		set
		{
			SetValue("CurrencyId", value);
		}
	}

	Currency _currencyOfCurrencyId;
	public Currency CurrencyOfCurrencyId
	{
		get
		{
			if(_currencyOfCurrencyId == null)
			{
				_currencyOfCurrencyId = Brevitee.Shop.Currency.OneWhere(c => c.KeyColumn == this.CurrencyId);
			}
			return _currencyOfCurrencyId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new CurrencyCountryColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the CurrencyCountry table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static CurrencyCountryCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<CurrencyCountry>();
			Database db = database ?? Db.For<CurrencyCountry>();
			var results = new CurrencyCountryCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static CurrencyCountry GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static CurrencyCountry GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static CurrencyCountryCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static CurrencyCountryCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<CurrencyCountryColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a CurrencyCountryColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CurrencyCountryCollection Where(Func<CurrencyCountryColumns, QueryFilter<CurrencyCountryColumns>> where, OrderBy<CurrencyCountryColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<CurrencyCountry>();
			return new CurrencyCountryCollection(database.GetQuery<CurrencyCountryColumns, CurrencyCountry>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static CurrencyCountryCollection Where(WhereDelegate<CurrencyCountryColumns> where, Database database = null)
		{		
			database = database ?? Db.For<CurrencyCountry>();
			var results = new CurrencyCountryCollection(database, database.GetQuery<CurrencyCountryColumns, CurrencyCountry>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountryCollection Where(WhereDelegate<CurrencyCountryColumns> where, OrderBy<CurrencyCountryColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<CurrencyCountry>();
			var results = new CurrencyCountryCollection(database, database.GetQuery<CurrencyCountryColumns, CurrencyCountry>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CurrencyCountryColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static CurrencyCountryCollection Where(QiQuery where, Database database = null)
		{
			var results = new CurrencyCountryCollection(database, Select<CurrencyCountryColumns>.From<CurrencyCountry>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static CurrencyCountry GetOneWhere(QueryFilter where, Database database = null)
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
		public static CurrencyCountry OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<CurrencyCountryColumns> whereDelegate = (c) => where;
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
		public static CurrencyCountry GetOneWhere(WhereDelegate<CurrencyCountryColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				CurrencyCountryColumns c = new CurrencyCountryColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single CurrencyCountry instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountry OneWhere(WhereDelegate<CurrencyCountryColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<CurrencyCountryColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static CurrencyCountry OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountry FirstOneWhere(WhereDelegate<CurrencyCountryColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountry FirstOneWhere(WhereDelegate<CurrencyCountryColumns> where, OrderBy<CurrencyCountryColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountry FirstOneWhere(QueryFilter where, OrderBy<CurrencyCountryColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<CurrencyCountryColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountryCollection Top(int count, WhereDelegate<CurrencyCountryColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static CurrencyCountryCollection Top(int count, WhereDelegate<CurrencyCountryColumns> where, OrderBy<CurrencyCountryColumns> orderBy, Database database = null)
		{
			CurrencyCountryColumns c = new CurrencyCountryColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<CurrencyCountry>();
			QuerySet query = GetQuerySet(db); 
			query.Top<CurrencyCountry>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<CurrencyCountryColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CurrencyCountryCollection>(0);
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
		public static CurrencyCountryCollection Top(int count, QueryFilter where, OrderBy<CurrencyCountryColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<CurrencyCountry>();
			QuerySet query = GetQuerySet(db);
			query.Top<CurrencyCountry>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<CurrencyCountryColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<CurrencyCountryCollection>(0);
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
		public static CurrencyCountryCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<CurrencyCountry>();
			QuerySet query = GetQuerySet(db);
			query.Top<CurrencyCountry>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<CurrencyCountryCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a CurrencyCountryColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between CurrencyCountryColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<CurrencyCountryColumns> where, Database database = null)
		{
			CurrencyCountryColumns c = new CurrencyCountryColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<CurrencyCountry>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<CurrencyCountry>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static CurrencyCountry CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<CurrencyCountry>();			
			var dao = new CurrencyCountry();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static CurrencyCountry OneOrThrow(CurrencyCountryCollection c)
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
