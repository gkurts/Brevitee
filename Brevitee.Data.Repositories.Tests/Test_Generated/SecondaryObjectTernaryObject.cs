// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Data.Repositories.Tests
{
	// schema = RepoTests
	// connection Name = RepoTests
	[Serializable]
	[Brevitee.Data.Table("SecondaryObjectTernaryObject", "RepoTests")]
	public partial class SecondaryObjectTernaryObject: Dao
	{
		public SecondaryObjectTernaryObject():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public SecondaryObjectTernaryObject(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator SecondaryObjectTernaryObject(DataRow data)
		{
			return new SecondaryObjectTernaryObject(data);
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



﻿	// start SecondaryObjectId -> SecondaryObjectId
	[Brevitee.Data.ForeignKey(
        Table="SecondaryObjectTernaryObject",
		Name="SecondaryObjectId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="SecondaryObject",
		Suffix="1")]
	public long? SecondaryObjectId
	{
		get
		{
			return GetLongValue("SecondaryObjectId");
		}
		set
		{
			SetValue("SecondaryObjectId", value);
		}
	}

	SecondaryObject _secondaryObjectOfSecondaryObjectId;
	public SecondaryObject SecondaryObjectOfSecondaryObjectId
	{
		get
		{
			if(_secondaryObjectOfSecondaryObjectId == null)
			{
				_secondaryObjectOfSecondaryObjectId = Brevitee.Data.Repositories.Tests.SecondaryObject.OneWhere(c => c.KeyColumn == this.SecondaryObjectId, this.Database);
			}
			return _secondaryObjectOfSecondaryObjectId;
		}
	}
	
﻿	// start TernaryObjectId -> TernaryObjectId
	[Brevitee.Data.ForeignKey(
        Table="SecondaryObjectTernaryObject",
		Name="TernaryObjectId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="TernaryObject",
		Suffix="2")]
	public long? TernaryObjectId
	{
		get
		{
			return GetLongValue("TernaryObjectId");
		}
		set
		{
			SetValue("TernaryObjectId", value);
		}
	}

	TernaryObject _ternaryObjectOfTernaryObjectId;
	public TernaryObject TernaryObjectOfTernaryObjectId
	{
		get
		{
			if(_ternaryObjectOfTernaryObjectId == null)
			{
				_ternaryObjectOfTernaryObjectId = Brevitee.Data.Repositories.Tests.TernaryObject.OneWhere(c => c.KeyColumn == this.TernaryObjectId, this.Database);
			}
			return _ternaryObjectOfTernaryObjectId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			if(UniqueFilterProvider != null)
			{
				return UniqueFilterProvider();
			}
			else
			{
				var colFilter = new SecondaryObjectTernaryObjectColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the SecondaryObjectTernaryObject table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SecondaryObjectTernaryObjectCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<SecondaryObjectTernaryObject>();
			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();
			var results = new SecondaryObjectTernaryObjectCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static SecondaryObjectTernaryObject GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static SecondaryObjectTernaryObject GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SecondaryObjectTernaryObject GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => c.Uuid == uuid, database);
		}

		public static SecondaryObjectTernaryObjectCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SecondaryObjectTernaryObjectCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SecondaryObjectTernaryObjectColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SecondaryObjectTernaryObjectCollection Where(Func<SecondaryObjectTernaryObjectColumns, QueryFilter<SecondaryObjectTernaryObjectColumns>> where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<SecondaryObjectTernaryObject>();
			return new SecondaryObjectTernaryObjectCollection(database.GetQuery<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SecondaryObjectTernaryObjectCollection Where(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
		{		
			database = database ?? Db.For<SecondaryObjectTernaryObject>();
			var results = new SecondaryObjectTernaryObjectCollection(database, database.GetQuery<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObjectCollection Where(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<SecondaryObjectTernaryObject>();
			var results = new SecondaryObjectTernaryObjectCollection(database, database.GetQuery<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SecondaryObjectTernaryObjectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObjectCollection Where(QiQuery where, Database database = null)
		{
			var results = new SecondaryObjectTernaryObjectCollection(database, Select<SecondaryObjectTernaryObjectColumns>.From<SecondaryObjectTernaryObject>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static SecondaryObjectTernaryObject GetOneWhere(QueryFilter where, Database database = null)
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
		public static SecondaryObjectTernaryObject OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SecondaryObjectTernaryObjectColumns> whereDelegate = (c) => where;
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
		public static SecondaryObjectTernaryObject GetOneWhere(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SecondaryObjectTernaryObjectColumns c = new SecondaryObjectTernaryObjectColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single SecondaryObjectTernaryObject instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObject OneWhere(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SecondaryObjectTernaryObjectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObject OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObject FirstOneWhere(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObject FirstOneWhere(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObject FirstOneWhere(QueryFilter where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SecondaryObjectTernaryObjectColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObjectCollection Top(int count, WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectTernaryObjectCollection Top(int count, WhereDelegate<SecondaryObjectTernaryObjectColumns> where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy, Database database = null)
		{
			SecondaryObjectTernaryObjectColumns c = new SecondaryObjectTernaryObjectColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();
			QuerySet query = GetQuerySet(db); 
			query.Top<SecondaryObjectTernaryObject>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SecondaryObjectTernaryObjectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SecondaryObjectTernaryObjectCollection>(0);
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
		public static SecondaryObjectTernaryObjectCollection Top(int count, QueryFilter where, OrderBy<SecondaryObjectTernaryObjectColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();
			QuerySet query = GetQuerySet(db);
			query.Top<SecondaryObjectTernaryObject>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SecondaryObjectTernaryObjectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SecondaryObjectTernaryObjectCollection>(0);
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
		public static SecondaryObjectTernaryObjectCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();
			QuerySet query = GetQuerySet(db);
			query.Top<SecondaryObjectTernaryObject>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SecondaryObjectTernaryObjectCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectTernaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectTernaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SecondaryObjectTernaryObjectColumns> where, Database database = null)
		{
			SecondaryObjectTernaryObjectColumns c = new SecondaryObjectTernaryObjectColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<SecondaryObjectTernaryObject>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static SecondaryObjectTernaryObject CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObjectTernaryObject>();			
			var dao = new SecondaryObjectTernaryObject();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static SecondaryObjectTernaryObject OneOrThrow(SecondaryObjectTernaryObjectCollection c)
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
