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
	[Brevitee.Data.Table("SecondaryObject", "RepoTests")]
	public partial class SecondaryObject: Dao
	{
		public SecondaryObject():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public SecondaryObject(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator SecondaryObject(DataRow data)
		{
			return new SecondaryObject(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("SecondaryObjectTernaryObject_SecondaryObjectId", new SecondaryObjectTernaryObjectCollection(Database.GetQuery<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject>((c) => c.SecondaryObjectId == this.Id), this, "SecondaryObjectId"));				﻿
            this.ChildCollections.Add("SecondaryObject_SecondaryObjectTernaryObject_TernaryObject",  new XrefDaoCollection<SecondaryObjectTernaryObject, TernaryObject>(this, false));
							
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

﻿	// property:Created, columnName:Created	
	[Brevitee.Data.Column(Name="Created", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? Created
	{
		get
		{
			return GetDateTimeValue("Created");
		}
		set
		{
			SetValue("Created", value);
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



﻿	// start MainId -> MainId
	[Brevitee.Data.ForeignKey(
        Table="SecondaryObject",
		Name="MainId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="MainObject",
		Suffix="1")]
	public long? MainId
	{
		get
		{
			return GetLongValue("MainId");
		}
		set
		{
			SetValue("MainId", value);
		}
	}

	MainObject _mainObjectOfMainId;
	public MainObject MainObjectOfMainId
	{
		get
		{
			if(_mainObjectOfMainId == null)
			{
				_mainObjectOfMainId = Brevitee.Data.Repositories.Tests.MainObject.OneWhere(c => c.KeyColumn == this.MainId, this.Database);
			}
			return _mainObjectOfMainId;
		}
	}
	
				
﻿
	[Exclude]	
	public SecondaryObjectTernaryObjectCollection SecondaryObjectTernaryObjectsBySecondaryObjectId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("SecondaryObjectTernaryObject_SecondaryObjectId"))
			{
				SetChildren();
			}

			var c = (SecondaryObjectTernaryObjectCollection)this.ChildCollections["SecondaryObjectTernaryObject_SecondaryObjectId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			
﻿
		// Xref       
        public XrefDaoCollection<SecondaryObjectTernaryObject, TernaryObject> TernaryObjects
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("SecondaryObject_SecondaryObjectTernaryObject_TernaryObject"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<SecondaryObjectTernaryObject, TernaryObject>)this.ChildCollections["SecondaryObject_SecondaryObjectTernaryObject_TernaryObject"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
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
				var colFilter = new SecondaryObjectColumns();
				return (colFilter.KeyColumn == IdValue);
			}			
		}

		/// <summary>
		/// Return every record in the SecondaryObject table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SecondaryObjectCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<SecondaryObject>();
			Database db = database ?? Db.For<SecondaryObject>();
			var results = new SecondaryObjectCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static SecondaryObject GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static SecondaryObject GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SecondaryObject GetByUuid(string uuid, Database database = null)
		{
			return OneWhere(c => c.Uuid == uuid, database);
		}

		public static SecondaryObjectCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SecondaryObjectCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SecondaryObjectColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SecondaryObjectColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SecondaryObjectCollection Where(Func<SecondaryObjectColumns, QueryFilter<SecondaryObjectColumns>> where, OrderBy<SecondaryObjectColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<SecondaryObject>();
			return new SecondaryObjectCollection(database.GetQuery<SecondaryObjectColumns, SecondaryObject>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SecondaryObjectCollection Where(WhereDelegate<SecondaryObjectColumns> where, Database database = null)
		{		
			database = database ?? Db.For<SecondaryObject>();
			var results = new SecondaryObjectCollection(database, database.GetQuery<SecondaryObjectColumns, SecondaryObject>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectCollection Where(WhereDelegate<SecondaryObjectColumns> where, OrderBy<SecondaryObjectColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<SecondaryObject>();
			var results = new SecondaryObjectCollection(database, database.GetQuery<SecondaryObjectColumns, SecondaryObject>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SecondaryObjectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SecondaryObjectCollection Where(QiQuery where, Database database = null)
		{
			var results = new SecondaryObjectCollection(database, Select<SecondaryObjectColumns>.From<SecondaryObject>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static SecondaryObject GetOneWhere(QueryFilter where, Database database = null)
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
		public static SecondaryObject OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SecondaryObjectColumns> whereDelegate = (c) => where;
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
		public static SecondaryObject GetOneWhere(WhereDelegate<SecondaryObjectColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SecondaryObjectColumns c = new SecondaryObjectColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single SecondaryObject instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObject OneWhere(WhereDelegate<SecondaryObjectColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SecondaryObjectColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SecondaryObject OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObject FirstOneWhere(WhereDelegate<SecondaryObjectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObject FirstOneWhere(WhereDelegate<SecondaryObjectColumns> where, OrderBy<SecondaryObjectColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObject FirstOneWhere(QueryFilter where, OrderBy<SecondaryObjectColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SecondaryObjectColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectCollection Top(int count, WhereDelegate<SecondaryObjectColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SecondaryObjectCollection Top(int count, WhereDelegate<SecondaryObjectColumns> where, OrderBy<SecondaryObjectColumns> orderBy, Database database = null)
		{
			SecondaryObjectColumns c = new SecondaryObjectColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<SecondaryObject>();
			QuerySet query = GetQuerySet(db); 
			query.Top<SecondaryObject>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SecondaryObjectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SecondaryObjectCollection>(0);
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
		public static SecondaryObjectCollection Top(int count, QueryFilter where, OrderBy<SecondaryObjectColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObject>();
			QuerySet query = GetQuerySet(db);
			query.Top<SecondaryObject>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SecondaryObjectColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SecondaryObjectCollection>(0);
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
		public static SecondaryObjectCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObject>();
			QuerySet query = GetQuerySet(db);
			query.Top<SecondaryObject>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SecondaryObjectCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SecondaryObjectColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SecondaryObjectColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SecondaryObjectColumns> where, Database database = null)
		{
			SecondaryObjectColumns c = new SecondaryObjectColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<SecondaryObject>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<SecondaryObject>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static SecondaryObject CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<SecondaryObject>();			
			var dao = new SecondaryObject();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static SecondaryObject OneOrThrow(SecondaryObjectCollection c)
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
