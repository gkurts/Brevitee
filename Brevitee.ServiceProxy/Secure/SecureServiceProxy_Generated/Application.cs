// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.ServiceProxy.Secure
{
	// schema = SecureServiceProxy
	// connection Name = SecureServiceProxy
	[Serializable]
	[Brevitee.Data.Table("Application", "SecureServiceProxy")]
	public partial class Application: Dao
	{
		public Application():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Application(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Application(DataRow data)
		{
			return new Application(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("ApiKey_ApplicationId", new ApiKeyCollection(Database.GetQuery<ApiKeyColumns, ApiKey>((c) => c.ApplicationId == this.Id), this, "ApplicationId"));	﻿
            this.ChildCollections.Add("SecureSession_ApplicationId", new SecureSessionCollection(Database.GetQuery<SecureSessionColumns, SecureSession>((c) => c.ApplicationId == this.Id), this, "ApplicationId"));							
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



				
﻿
	[Exclude]	
	public ApiKeyCollection ApiKeysByApplicationId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("ApiKey_ApplicationId"))
			{
				SetChildren();
			}

			var c = (ApiKeyCollection)this.ChildCollections["ApiKey_ApplicationId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public SecureSessionCollection SecureSessionsByApplicationId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("SecureSession_ApplicationId"))
			{
				SetChildren();
			}

			var c = (SecureSessionCollection)this.ChildCollections["SecureSession_ApplicationId"];
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
			var colFilter = new ApplicationColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Application table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static ApplicationCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Application>();
			Database db = database ?? Db.For<Application>();
			var results = new ApplicationCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Application GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Application GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static ApplicationCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static ApplicationCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<ApplicationColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a ApplicationColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ApplicationCollection Where(Func<ApplicationColumns, QueryFilter<ApplicationColumns>> where, OrderBy<ApplicationColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Application>();
			return new ApplicationCollection(database.GetQuery<ApplicationColumns, Application>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static ApplicationCollection Where(WhereDelegate<ApplicationColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Application>();
			var results = new ApplicationCollection(database, database.GetQuery<ApplicationColumns, Application>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ApplicationCollection Where(WhereDelegate<ApplicationColumns> where, OrderBy<ApplicationColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Application>();
			var results = new ApplicationCollection(database, database.GetQuery<ApplicationColumns, Application>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ApplicationColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static ApplicationCollection Where(QiQuery where, Database database = null)
		{
			var results = new ApplicationCollection(database, Select<ApplicationColumns>.From<Application>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Application GetOneWhere(QueryFilter where, Database database = null)
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
		public static Application OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<ApplicationColumns> whereDelegate = (c) => where;
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
		public static Application GetOneWhere(WhereDelegate<ApplicationColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				ApplicationColumns c = new ApplicationColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Application instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Application OneWhere(WhereDelegate<ApplicationColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<ApplicationColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Application OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Application FirstOneWhere(WhereDelegate<ApplicationColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Application FirstOneWhere(WhereDelegate<ApplicationColumns> where, OrderBy<ApplicationColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Application FirstOneWhere(QueryFilter where, OrderBy<ApplicationColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<ApplicationColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static ApplicationCollection Top(int count, WhereDelegate<ApplicationColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static ApplicationCollection Top(int count, WhereDelegate<ApplicationColumns> where, OrderBy<ApplicationColumns> orderBy, Database database = null)
		{
			ApplicationColumns c = new ApplicationColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Application>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Application>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<ApplicationColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ApplicationCollection>(0);
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
		public static ApplicationCollection Top(int count, QueryFilter where, OrderBy<ApplicationColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Application>();
			QuerySet query = GetQuerySet(db);
			query.Top<Application>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<ApplicationColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<ApplicationCollection>(0);
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
		public static ApplicationCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Application>();
			QuerySet query = GetQuerySet(db);
			query.Top<Application>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<ApplicationCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a ApplicationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between ApplicationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<ApplicationColumns> where, Database database = null)
		{
			ApplicationColumns c = new ApplicationColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Application>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Application>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Application CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Application>();			
			var dao = new Application();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Application OneOrThrow(ApplicationCollection c)
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
