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
	[Brevitee.Data.Table("StickerizableListStickerizable", "Stickerize")]
	public partial class StickerizableListStickerizable: Dao
	{
		public StickerizableListStickerizable():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public StickerizableListStickerizable(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator StickerizableListStickerizable(DataRow data)
		{
			return new StickerizableListStickerizable(data);
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



﻿	// start StickerizableListId -> StickerizableListId
	[Brevitee.Data.ForeignKey(
        Table="StickerizableListStickerizable",
		Name="StickerizableListId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=false, 
		ReferencedKey="Id",
		ReferencedTable="StickerizableList",
		Suffix="1")]
	public long? StickerizableListId
	{
		get
		{
			return GetLongValue("StickerizableListId");
		}
		set
		{
			SetValue("StickerizableListId", value);
		}
	}

	StickerizableList _stickerizableListOfStickerizableListId;
	public StickerizableList StickerizableListOfStickerizableListId
	{
		get
		{
			if(_stickerizableListOfStickerizableListId == null)
			{
				_stickerizableListOfStickerizableListId = Brevitee.Stickerize.Business.Data.StickerizableList.OneWhere(c => c.KeyColumn == this.StickerizableListId);
			}
			return _stickerizableListOfStickerizableListId;
		}
	}
	
﻿	// start StickerizableId -> StickerizableId
	[Brevitee.Data.ForeignKey(
        Table="StickerizableListStickerizable",
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
			var colFilter = new StickerizableListStickerizableColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the StickerizableListStickerizable table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static StickerizableListStickerizableCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<StickerizableListStickerizable>();
			Database db = database ?? Db.For<StickerizableListStickerizable>();
			var results = new StickerizableListStickerizableCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static StickerizableListStickerizable GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static StickerizableListStickerizable GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static StickerizableListStickerizableCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static StickerizableListStickerizableCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<StickerizableListStickerizableColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizableListStickerizableCollection Where(Func<StickerizableListStickerizableColumns, QueryFilter<StickerizableListStickerizableColumns>> where, OrderBy<StickerizableListStickerizableColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<StickerizableListStickerizable>();
			return new StickerizableListStickerizableCollection(database.GetQuery<StickerizableListStickerizableColumns, StickerizableListStickerizable>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizableListStickerizableCollection Where(WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
		{		
			database = database ?? Db.For<StickerizableListStickerizable>();
			var results = new StickerizableListStickerizableCollection(database, database.GetQuery<StickerizableListStickerizableColumns, StickerizableListStickerizable>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizableCollection Where(WhereDelegate<StickerizableListStickerizableColumns> where, OrderBy<StickerizableListStickerizableColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<StickerizableListStickerizable>();
			var results = new StickerizableListStickerizableCollection(database, database.GetQuery<StickerizableListStickerizableColumns, StickerizableListStickerizable>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizableListStickerizableColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizableListStickerizableCollection Where(QiQuery where, Database database = null)
		{
			var results = new StickerizableListStickerizableCollection(database, Select<StickerizableListStickerizableColumns>.From<StickerizableListStickerizable>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static StickerizableListStickerizable GetOneWhere(QueryFilter where, Database database = null)
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
		public static StickerizableListStickerizable OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<StickerizableListStickerizableColumns> whereDelegate = (c) => where;
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
		public static StickerizableListStickerizable GetOneWhere(WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				StickerizableListStickerizableColumns c = new StickerizableListStickerizableColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single StickerizableListStickerizable instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizable OneWhere(WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizableListStickerizableColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizableListStickerizable OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizable FirstOneWhere(WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizable FirstOneWhere(WhereDelegate<StickerizableListStickerizableColumns> where, OrderBy<StickerizableListStickerizableColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizable FirstOneWhere(QueryFilter where, OrderBy<StickerizableListStickerizableColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<StickerizableListStickerizableColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizableCollection Top(int count, WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizableListStickerizableCollection Top(int count, WhereDelegate<StickerizableListStickerizableColumns> where, OrderBy<StickerizableListStickerizableColumns> orderBy, Database database = null)
		{
			StickerizableListStickerizableColumns c = new StickerizableListStickerizableColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<StickerizableListStickerizable>();
			QuerySet query = GetQuerySet(db); 
			query.Top<StickerizableListStickerizable>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<StickerizableListStickerizableColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizableListStickerizableCollection>(0);
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
		public static StickerizableListStickerizableCollection Top(int count, QueryFilter where, OrderBy<StickerizableListStickerizableColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<StickerizableListStickerizable>();
			QuerySet query = GetQuerySet(db);
			query.Top<StickerizableListStickerizable>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<StickerizableListStickerizableColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizableListStickerizableCollection>(0);
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
		public static StickerizableListStickerizableCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<StickerizableListStickerizable>();
			QuerySet query = GetQuerySet(db);
			query.Top<StickerizableListStickerizable>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<StickerizableListStickerizableCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizableListStickerizableColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizableListStickerizableColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<StickerizableListStickerizableColumns> where, Database database = null)
		{
			StickerizableListStickerizableColumns c = new StickerizableListStickerizableColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<StickerizableListStickerizable>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<StickerizableListStickerizable>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static StickerizableListStickerizable CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<StickerizableListStickerizable>();			
			var dao = new StickerizableListStickerizable();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static StickerizableListStickerizable OneOrThrow(StickerizableListStickerizableCollection c)
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
