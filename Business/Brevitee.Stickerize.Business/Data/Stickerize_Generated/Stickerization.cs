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
	[Brevitee.Data.Table("Stickerization", "Stickerize")]
	public partial class Stickerization: Dao
	{
		public Stickerization():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Stickerization(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Stickerization(DataRow data)
		{
			return new Stickerization(data);
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

﻿	// property:ForDate, columnName:ForDate	
	[Brevitee.Data.Column(Name="ForDate", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? ForDate
	{
		get
		{
			return GetDateTimeValue("ForDate");
		}
		set
		{
			SetValue("ForDate", value);
		}
	}

﻿	// property:UndoneAt, columnName:UndoneAt	
	[Brevitee.Data.Column(Name="UndoneAt", DbDataType="DateTime", MaxLength="8", AllowNull=true)]
	public DateTime? UndoneAt
	{
		get
		{
			return GetDateTimeValue("UndoneAt");
		}
		set
		{
			SetValue("UndoneAt", value);
		}
	}

﻿	// property:IsUndone, columnName:IsUndone	
	[Brevitee.Data.Column(Name="IsUndone", DbDataType="Bit", MaxLength="1", AllowNull=true)]
	public bool? IsUndone
	{
		get
		{
			return GetBooleanValue("IsUndone");
		}
		set
		{
			SetValue("IsUndone", value);
		}
	}



﻿	// start StickerId -> StickerId
	[Brevitee.Data.ForeignKey(
        Table="Stickerization",
		Name="StickerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Sticker",
		Suffix="1")]
	public long? StickerId
	{
		get
		{
			return GetLongValue("StickerId");
		}
		set
		{
			SetValue("StickerId", value);
		}
	}

	Sticker _stickerOfStickerId;
	public Sticker StickerOfStickerId
	{
		get
		{
			if(_stickerOfStickerId == null)
			{
				_stickerOfStickerId = Brevitee.Stickerize.Business.Data.Sticker.OneWhere(c => c.KeyColumn == this.StickerId);
			}
			return _stickerOfStickerId;
		}
	}
	
﻿	// start StickerizerId -> StickerizerId
	[Brevitee.Data.ForeignKey(
        Table="Stickerization",
		Name="StickerizerId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizer",
		Suffix="2")]
	public long? StickerizerId
	{
		get
		{
			return GetLongValue("StickerizerId");
		}
		set
		{
			SetValue("StickerizerId", value);
		}
	}

	Stickerizer _stickerizerOfStickerizerId;
	public Stickerizer StickerizerOfStickerizerId
	{
		get
		{
			if(_stickerizerOfStickerizerId == null)
			{
				_stickerizerOfStickerizerId = Brevitee.Stickerize.Business.Data.Stickerizer.OneWhere(c => c.KeyColumn == this.StickerizerId);
			}
			return _stickerizerOfStickerizerId;
		}
	}
	
﻿	// start StickerizableId -> StickerizableId
	[Brevitee.Data.ForeignKey(
        Table="Stickerization",
		Name="StickerizableId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizable",
		Suffix="3")]
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
	
﻿	// start StickerizeeId -> StickerizeeId
	[Brevitee.Data.ForeignKey(
        Table="Stickerization",
		Name="StickerizeeId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Stickerizee",
		Suffix="4")]
	public long? StickerizeeId
	{
		get
		{
			return GetLongValue("StickerizeeId");
		}
		set
		{
			SetValue("StickerizeeId", value);
		}
	}

	Stickerizee _stickerizeeOfStickerizeeId;
	public Stickerizee StickerizeeOfStickerizeeId
	{
		get
		{
			if(_stickerizeeOfStickerizeeId == null)
			{
				_stickerizeeOfStickerizeeId = Brevitee.Stickerize.Business.Data.Stickerizee.OneWhere(c => c.KeyColumn == this.StickerizeeId);
			}
			return _stickerizeeOfStickerizeeId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new StickerizationColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Stickerization table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static StickerizationCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Stickerization>();
			Database db = database ?? Db.For<Stickerization>();
			var results = new StickerizationCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Stickerization GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Stickerization GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static StickerizationCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static StickerizationCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<StickerizationColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a StickerizationColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizationCollection Where(Func<StickerizationColumns, QueryFilter<StickerizationColumns>> where, OrderBy<StickerizationColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Stickerization>();
			return new StickerizationCollection(database.GetQuery<StickerizationColumns, Stickerization>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizationCollection Where(WhereDelegate<StickerizationColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Stickerization>();
			var results = new StickerizationCollection(database, database.GetQuery<StickerizationColumns, Stickerization>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizationCollection Where(WhereDelegate<StickerizationColumns> where, OrderBy<StickerizationColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Stickerization>();
			var results = new StickerizationCollection(database, database.GetQuery<StickerizationColumns, Stickerization>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizationColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizationCollection Where(QiQuery where, Database database = null)
		{
			var results = new StickerizationCollection(database, Select<StickerizationColumns>.From<Stickerization>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Stickerization GetOneWhere(QueryFilter where, Database database = null)
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
		public static Stickerization OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<StickerizationColumns> whereDelegate = (c) => where;
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
		public static Stickerization GetOneWhere(WhereDelegate<StickerizationColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				StickerizationColumns c = new StickerizationColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Stickerization instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerization OneWhere(WhereDelegate<StickerizationColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizationColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Stickerization OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerization FirstOneWhere(WhereDelegate<StickerizationColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerization FirstOneWhere(WhereDelegate<StickerizationColumns> where, OrderBy<StickerizationColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerization FirstOneWhere(QueryFilter where, OrderBy<StickerizationColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<StickerizationColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizationCollection Top(int count, WhereDelegate<StickerizationColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizationCollection Top(int count, WhereDelegate<StickerizationColumns> where, OrderBy<StickerizationColumns> orderBy, Database database = null)
		{
			StickerizationColumns c = new StickerizationColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Stickerization>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Stickerization>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<StickerizationColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizationCollection>(0);
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
		public static StickerizationCollection Top(int count, QueryFilter where, OrderBy<StickerizationColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Stickerization>();
			QuerySet query = GetQuerySet(db);
			query.Top<Stickerization>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<StickerizationColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizationCollection>(0);
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
		public static StickerizationCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Stickerization>();
			QuerySet query = GetQuerySet(db);
			query.Top<Stickerization>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<StickerizationCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizationColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizationColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<StickerizationColumns> where, Database database = null)
		{
			StickerizationColumns c = new StickerizationColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Stickerization>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Stickerization>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Stickerization CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Stickerization>();			
			var dao = new Stickerization();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Stickerization OneOrThrow(StickerizationCollection c)
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
