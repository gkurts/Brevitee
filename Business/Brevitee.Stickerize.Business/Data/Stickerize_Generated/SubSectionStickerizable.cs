// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Stickerize.Business.Data
{
	// schema = Stickerize
	// connection Name = Stickerize
	[Serializable]
	[Brevitee.Data.Table("SubSectionStickerizable", "Stickerize")]
	public partial class SubSectionStickerizable: Dao
	{
		public SubSectionStickerizable():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public SubSectionStickerizable(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator SubSectionStickerizable(DataRow data)
		{
			return new SubSectionStickerizable(data);
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



﻿	// start SubSectionId -> SubSectionId
	[Brevitee.Data.ForeignKey(
        Table="SubSectionStickerizable",
		Name="SubSectionId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="SubSection",
		Suffix="1")]
	public long? SubSectionId
	{
		get
		{
			return GetLongValue("SubSectionId");
		}
		set
		{
			SetValue("SubSectionId", value);
		}
	}

	SubSection _subSectionOfSubSectionId;
	public SubSection SubSectionOfSubSectionId
	{
		get
		{
			if(_subSectionOfSubSectionId == null)
			{
				_subSectionOfSubSectionId = Brevitee.Stickerize.Business.Data.SubSection.OneWhere(c => c.KeyColumn == this.SubSectionId);
			}
			return _subSectionOfSubSectionId;
		}
	}
	
﻿	// start StickerizableId -> StickerizableId
	[Brevitee.Data.ForeignKey(
        Table="SubSectionStickerizable",
		Name="StickerizableId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizable",
		Suffix="2")]
	public long? StickerizableId
	{
		get
		{
			return GetLongValue("StickerizableId");
		}
		set
		{
			SetValue("StickerizableId", value);
		}
	}

	Stickerizable _stickerizableOfStickerizableId;
	public Stickerizable StickerizableOfStickerizableId
	{
		get
		{
			if(_stickerizableOfStickerizableId == null)
			{
				_stickerizableOfStickerizableId = Brevitee.Stickerize.Business.Data.Stickerizable.OneWhere(c => c.KeyColumn == this.StickerizableId);
			}
			return _stickerizableOfStickerizableId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new SubSectionStickerizableColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the SubSectionStickerizable table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static SubSectionStickerizableCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<SubSectionStickerizable>();
			Database db = database ?? Db.For<SubSectionStickerizable>();
			var results = new SubSectionStickerizableCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static SubSectionStickerizable GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static SubSectionStickerizable GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static SubSectionStickerizableCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static SubSectionStickerizableCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<SubSectionStickerizableColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a SubSectionStickerizableColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SubSectionStickerizableCollection Where(Func<SubSectionStickerizableColumns, QueryFilter<SubSectionStickerizableColumns>> where, OrderBy<SubSectionStickerizableColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<SubSectionStickerizable>();
			return new SubSectionStickerizableCollection(database.GetQuery<SubSectionStickerizableColumns, SubSectionStickerizable>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static SubSectionStickerizableCollection Where(WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
		{		
			database = database ?? Db.For<SubSectionStickerizable>();
			var results = new SubSectionStickerizableCollection(database, database.GetQuery<SubSectionStickerizableColumns, SubSectionStickerizable>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizableCollection Where(WhereDelegate<SubSectionStickerizableColumns> where, OrderBy<SubSectionStickerizableColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<SubSectionStickerizable>();
			var results = new SubSectionStickerizableCollection(database, database.GetQuery<SubSectionStickerizableColumns, SubSectionStickerizable>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SubSectionStickerizableColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SubSectionStickerizableCollection Where(QiQuery where, Database database = null)
		{
			var results = new SubSectionStickerizableCollection(database, Select<SubSectionStickerizableColumns>.From<SubSectionStickerizable>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static SubSectionStickerizable GetOneWhere(QueryFilter where, Database database = null)
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
		public static SubSectionStickerizable OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<SubSectionStickerizableColumns> whereDelegate = (c) => where;
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
		public static SubSectionStickerizable GetOneWhere(WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				SubSectionStickerizableColumns c = new SubSectionStickerizableColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single SubSectionStickerizable instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizable OneWhere(WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<SubSectionStickerizableColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static SubSectionStickerizable OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizable FirstOneWhere(WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizable FirstOneWhere(WhereDelegate<SubSectionStickerizableColumns> where, OrderBy<SubSectionStickerizableColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizable FirstOneWhere(QueryFilter where, OrderBy<SubSectionStickerizableColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<SubSectionStickerizableColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizableCollection Top(int count, WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static SubSectionStickerizableCollection Top(int count, WhereDelegate<SubSectionStickerizableColumns> where, OrderBy<SubSectionStickerizableColumns> orderBy, Database database = null)
		{
			SubSectionStickerizableColumns c = new SubSectionStickerizableColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<SubSectionStickerizable>();
			QuerySet query = GetQuerySet(db); 
			query.Top<SubSectionStickerizable>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<SubSectionStickerizableColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SubSectionStickerizableCollection>(0);
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
		public static SubSectionStickerizableCollection Top(int count, QueryFilter where, OrderBy<SubSectionStickerizableColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<SubSectionStickerizable>();
			QuerySet query = GetQuerySet(db);
			query.Top<SubSectionStickerizable>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<SubSectionStickerizableColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<SubSectionStickerizableCollection>(0);
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
		public static SubSectionStickerizableCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<SubSectionStickerizable>();
			QuerySet query = GetQuerySet(db);
			query.Top<SubSectionStickerizable>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<SubSectionStickerizableCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a SubSectionStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between SubSectionStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<SubSectionStickerizableColumns> where, Database database = null)
		{
			SubSectionStickerizableColumns c = new SubSectionStickerizableColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<SubSectionStickerizable>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<SubSectionStickerizable>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static SubSectionStickerizable CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<SubSectionStickerizable>();			
			var dao = new SubSectionStickerizable();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static SubSectionStickerizable OneOrThrow(SubSectionStickerizableCollection c)
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
