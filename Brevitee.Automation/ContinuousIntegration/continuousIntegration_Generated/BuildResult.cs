// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Automation.ContinuousIntegration.Data
{
	// schema = ContinuousIntegration
	// connection Name = ContinuousIntegration
	[Serializable]
	[Brevitee.Data.Table("BuildResult", "ContinuousIntegration")]
	public partial class BuildResult: Dao
	{
		public BuildResult():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public BuildResult(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator BuildResult(DataRow data)
		{
			return new BuildResult(data);
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

﻿	// property:Success, columnName:Success	
	[Brevitee.Data.Column(Name="Success", DbDataType="Bit", MaxLength="1", AllowNull=false)]
	public bool? Success
	{
		get
		{
			return GetBooleanValue("Success");
		}
		set
		{
			SetValue("Success", value);
		}
	}

﻿	// property:Message, columnName:Message	
	[Brevitee.Data.Column(Name="Message", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Message
	{
		get
		{
			return GetStringValue("Message");
		}
		set
		{
			SetValue("Message", value);
		}
	}



﻿	// start BuildJobId -> BuildJobId
	[Brevitee.Data.ForeignKey(
        Table="BuildResult",
		Name="BuildJobId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="BuildJob",
		Suffix="1")]
	public long? BuildJobId
	{
		get
		{
			return GetLongValue("BuildJobId");
		}
		set
		{
			SetValue("BuildJobId", value);
		}
	}

	BuildJob _buildJobOfBuildJobId;
	public BuildJob BuildJobOfBuildJobId
	{
		get
		{
			if(_buildJobOfBuildJobId == null)
			{
				_buildJobOfBuildJobId = Brevitee.Automation.ContinuousIntegration.Data.BuildJob.OneWhere(c => c.KeyColumn == this.BuildJobId);
			}
			return _buildJobOfBuildJobId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new BuildResultColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the BuildResult table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static BuildResultCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<BuildResult>();
			Database db = database ?? Db.For<BuildResult>();
			var results = new BuildResultCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static BuildResult GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static BuildResult GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static BuildResultCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static BuildResultCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<BuildResultColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a BuildResultColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static BuildResultCollection Where(Func<BuildResultColumns, QueryFilter<BuildResultColumns>> where, OrderBy<BuildResultColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<BuildResult>();
			return new BuildResultCollection(database.GetQuery<BuildResultColumns, BuildResult>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static BuildResultCollection Where(WhereDelegate<BuildResultColumns> where, Database database = null)
		{		
			database = database ?? Db.For<BuildResult>();
			var results = new BuildResultCollection(database, database.GetQuery<BuildResultColumns, BuildResult>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static BuildResultCollection Where(WhereDelegate<BuildResultColumns> where, OrderBy<BuildResultColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<BuildResult>();
			var results = new BuildResultCollection(database, database.GetQuery<BuildResultColumns, BuildResult>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<BuildResultColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static BuildResultCollection Where(QiQuery where, Database database = null)
		{
			var results = new BuildResultCollection(database, Select<BuildResultColumns>.From<BuildResult>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static BuildResult GetOneWhere(QueryFilter where, Database database = null)
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
		public static BuildResult OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<BuildResultColumns> whereDelegate = (c) => where;
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
		public static BuildResult GetOneWhere(WhereDelegate<BuildResultColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				BuildResultColumns c = new BuildResultColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single BuildResult instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BuildResult OneWhere(WhereDelegate<BuildResultColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<BuildResultColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static BuildResult OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BuildResult FirstOneWhere(WhereDelegate<BuildResultColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BuildResult FirstOneWhere(WhereDelegate<BuildResultColumns> where, OrderBy<BuildResultColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BuildResult FirstOneWhere(QueryFilter where, OrderBy<BuildResultColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<BuildResultColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static BuildResultCollection Top(int count, WhereDelegate<BuildResultColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static BuildResultCollection Top(int count, WhereDelegate<BuildResultColumns> where, OrderBy<BuildResultColumns> orderBy, Database database = null)
		{
			BuildResultColumns c = new BuildResultColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<BuildResult>();
			QuerySet query = GetQuerySet(db); 
			query.Top<BuildResult>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<BuildResultColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<BuildResultCollection>(0);
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
		public static BuildResultCollection Top(int count, QueryFilter where, OrderBy<BuildResultColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<BuildResult>();
			QuerySet query = GetQuerySet(db);
			query.Top<BuildResult>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<BuildResultColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<BuildResultCollection>(0);
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
		public static BuildResultCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<BuildResult>();
			QuerySet query = GetQuerySet(db);
			query.Top<BuildResult>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<BuildResultCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a BuildResultColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between BuildResultColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<BuildResultColumns> where, Database database = null)
		{
			BuildResultColumns c = new BuildResultColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<BuildResult>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<BuildResult>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static BuildResult CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<BuildResult>();			
			var dao = new BuildResult();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static BuildResult OneOrThrow(BuildResultCollection c)
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