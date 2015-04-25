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
	[Brevitee.Data.Table("Stickerizee", "Stickerize")]
	public partial class Stickerizee: Dao
	{
		public Stickerizee():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Stickerizee(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Stickerizee(DataRow data)
		{
			return new Stickerizee(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("Stickerization_StickerizeeId", new StickerizationCollection(Database.GetQuery<StickerizationColumns, Stickerization>((c) => c.StickerizeeId == this.Id), this, "StickerizeeId"));	﻿
            this.ChildCollections.Add("StickerizerStickerizee_StickerizeeId", new StickerizerStickerizeeCollection(Database.GetQuery<StickerizerStickerizeeColumns, StickerizerStickerizee>((c) => c.StickerizeeId == this.Id), this, "StickerizeeId"));							﻿
            this.ChildCollections.Add("Stickerizee_StickerizerStickerizee_Stickerizer",  new XrefDaoCollection<StickerizerStickerizee, Stickerizer>(this, false));
				
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

﻿	// property:DisplayName, columnName:DisplayName	
	[Brevitee.Data.Column(Name="DisplayName", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string DisplayName
	{
		get
		{
			return GetStringValue("DisplayName");
		}
		set
		{
			SetValue("DisplayName", value);
		}
	}

﻿	// property:Gender, columnName:Gender	
	[Brevitee.Data.Column(Name="Gender", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Gender
	{
		get
		{
			return GetStringValue("Gender");
		}
		set
		{
			SetValue("Gender", value);
		}
	}

﻿	// property:UserName, columnName:UserName	
	[Brevitee.Data.Column(Name="UserName", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string UserName
	{
		get
		{
			return GetStringValue("UserName");
		}
		set
		{
			SetValue("UserName", value);
		}
	}



﻿	// start ImageId -> ImageId
	[Brevitee.Data.ForeignKey(
        Table="Stickerizee",
		Name="ImageId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Image",
		Suffix="1")]
	public long? ImageId
	{
		get
		{
			return GetLongValue("ImageId");
		}
		set
		{
			SetValue("ImageId", value);
		}
	}

	Image _imageOfImageId;
	public Image ImageOfImageId
	{
		get
		{
			if(_imageOfImageId == null)
			{
				_imageOfImageId = Brevitee.Stickerize.Business.Data.Image.OneWhere(c => c.KeyColumn == this.ImageId);
			}
			return _imageOfImageId;
		}
	}
	
				
﻿
	[Exclude]	
	public StickerizationCollection StickerizationsByStickerizeeId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Stickerization_StickerizeeId"))
			{
				SetChildren();
			}

			var c = (StickerizationCollection)this.ChildCollections["Stickerization_StickerizeeId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public StickerizerStickerizeeCollection StickerizerStickerizeesByStickerizeeId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("StickerizerStickerizee_StickerizeeId"))
			{
				SetChildren();
			}

			var c = (StickerizerStickerizeeCollection)this.ChildCollections["StickerizerStickerizee_StickerizeeId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<StickerizerStickerizee, Stickerizer> Stickerizers
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Stickerizee_StickerizerStickerizee_Stickerizer"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<StickerizerStickerizee, Stickerizer>)this.ChildCollections["Stickerizee_StickerizerStickerizee_Stickerizer"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new StickerizeeColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Stickerizee table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static StickerizeeCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Stickerizee>();
			Database db = database ?? Db.For<Stickerizee>();
			var results = new StickerizeeCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Stickerizee GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Stickerizee GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static StickerizeeCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static StickerizeeCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<StickerizeeColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a StickerizeeColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizeeCollection Where(Func<StickerizeeColumns, QueryFilter<StickerizeeColumns>> where, OrderBy<StickerizeeColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Stickerizee>();
			return new StickerizeeCollection(database.GetQuery<StickerizeeColumns, Stickerizee>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static StickerizeeCollection Where(WhereDelegate<StickerizeeColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Stickerizee>();
			var results = new StickerizeeCollection(database, database.GetQuery<StickerizeeColumns, Stickerizee>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizeeCollection Where(WhereDelegate<StickerizeeColumns> where, OrderBy<StickerizeeColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Stickerizee>();
			var results = new StickerizeeCollection(database, database.GetQuery<StickerizeeColumns, Stickerizee>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizeeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static StickerizeeCollection Where(QiQuery where, Database database = null)
		{
			var results = new StickerizeeCollection(database, Select<StickerizeeColumns>.From<Stickerizee>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Stickerizee GetOneWhere(QueryFilter where, Database database = null)
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
		public static Stickerizee OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<StickerizeeColumns> whereDelegate = (c) => where;
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
		public static Stickerizee GetOneWhere(WhereDelegate<StickerizeeColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				StickerizeeColumns c = new StickerizeeColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Stickerizee instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerizee OneWhere(WhereDelegate<StickerizeeColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<StickerizeeColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Stickerizee OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerizee FirstOneWhere(WhereDelegate<StickerizeeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerizee FirstOneWhere(WhereDelegate<StickerizeeColumns> where, OrderBy<StickerizeeColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Stickerizee FirstOneWhere(QueryFilter where, OrderBy<StickerizeeColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<StickerizeeColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static StickerizeeCollection Top(int count, WhereDelegate<StickerizeeColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static StickerizeeCollection Top(int count, WhereDelegate<StickerizeeColumns> where, OrderBy<StickerizeeColumns> orderBy, Database database = null)
		{
			StickerizeeColumns c = new StickerizeeColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Stickerizee>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Stickerizee>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<StickerizeeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizeeCollection>(0);
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
		public static StickerizeeCollection Top(int count, QueryFilter where, OrderBy<StickerizeeColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Stickerizee>();
			QuerySet query = GetQuerySet(db);
			query.Top<Stickerizee>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<StickerizeeColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<StickerizeeCollection>(0);
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
		public static StickerizeeCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Stickerizee>();
			QuerySet query = GetQuerySet(db);
			query.Top<Stickerizee>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<StickerizeeCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a StickerizeeColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between StickerizeeColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<StickerizeeColumns> where, Database database = null)
		{
			StickerizeeColumns c = new StickerizeeColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Stickerizee>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Stickerizee>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Stickerizee CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Stickerizee>();			
			var dao = new Stickerizee();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Stickerizee OneOrThrow(StickerizeeCollection c)
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
