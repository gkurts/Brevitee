// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Analytics
{
	// schema = Analytics
	// connection Name = Analytics
	[Serializable]
	[Brevitee.Data.Table("Url", "Analytics")]
	public partial class Url: Dao
	{
		public Url():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Url(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Url(DataRow data)
		{
			return new Url(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("Image_UrlId", new ImageCollection(Database.GetQuery<ImageColumns, Image>((c) => c.UrlId == this.Id), this, "UrlId"));	﻿
            this.ChildCollections.Add("UrlTag_UrlId", new UrlTagCollection(Database.GetQuery<UrlTagColumns, UrlTag>((c) => c.UrlId == this.Id), this, "UrlId"));				﻿
            this.ChildCollections.Add("Url_UrlTag_Tag",  new XrefDaoCollection<UrlTag, Tag>(this, false));
							
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



﻿	// start ProtocolId -> ProtocolId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="ProtocolId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Protocol",
		Suffix="1")]
	public long? ProtocolId
	{
		get
		{
			return GetLongValue("ProtocolId");
		}
		set
		{
			SetValue("ProtocolId", value);
		}
	}

	Protocol _protocolOfProtocolId;
	public Protocol ProtocolOfProtocolId
	{
		get
		{
			if(_protocolOfProtocolId == null)
			{
				_protocolOfProtocolId = Brevitee.Analytics.Protocol.OneWhere(c => c.KeyColumn == this.ProtocolId);
			}
			return _protocolOfProtocolId;
		}
	}
	
﻿	// start DomainId -> DomainId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="DomainId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Domain",
		Suffix="2")]
	public long? DomainId
	{
		get
		{
			return GetLongValue("DomainId");
		}
		set
		{
			SetValue("DomainId", value);
		}
	}

	Domain _domainOfDomainId;
	public Domain DomainOfDomainId
	{
		get
		{
			if(_domainOfDomainId == null)
			{
				_domainOfDomainId = Brevitee.Analytics.Domain.OneWhere(c => c.KeyColumn == this.DomainId);
			}
			return _domainOfDomainId;
		}
	}
	
﻿	// start PortId -> PortId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="PortId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Port",
		Suffix="3")]
	public long? PortId
	{
		get
		{
			return GetLongValue("PortId");
		}
		set
		{
			SetValue("PortId", value);
		}
	}

	Port _portOfPortId;
	public Port PortOfPortId
	{
		get
		{
			if(_portOfPortId == null)
			{
				_portOfPortId = Brevitee.Analytics.Port.OneWhere(c => c.KeyColumn == this.PortId);
			}
			return _portOfPortId;
		}
	}
	
﻿	// start PathId -> PathId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="PathId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Path",
		Suffix="4")]
	public long? PathId
	{
		get
		{
			return GetLongValue("PathId");
		}
		set
		{
			SetValue("PathId", value);
		}
	}

	Path _pathOfPathId;
	public Path PathOfPathId
	{
		get
		{
			if(_pathOfPathId == null)
			{
				_pathOfPathId = Brevitee.Analytics.Path.OneWhere(c => c.KeyColumn == this.PathId);
			}
			return _pathOfPathId;
		}
	}
	
﻿	// start QueryStringId -> QueryStringId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="QueryStringId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="QueryString",
		Suffix="5")]
	public long? QueryStringId
	{
		get
		{
			return GetLongValue("QueryStringId");
		}
		set
		{
			SetValue("QueryStringId", value);
		}
	}

	QueryString _queryStringOfQueryStringId;
	public QueryString QueryStringOfQueryStringId
	{
		get
		{
			if(_queryStringOfQueryStringId == null)
			{
				_queryStringOfQueryStringId = Brevitee.Analytics.QueryString.OneWhere(c => c.KeyColumn == this.QueryStringId);
			}
			return _queryStringOfQueryStringId;
		}
	}
	
﻿	// start FragmentId -> FragmentId
	[Brevitee.Data.ForeignKey(
        Table="Url",
		Name="FragmentId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Fragment",
		Suffix="6")]
	public long? FragmentId
	{
		get
		{
			return GetLongValue("FragmentId");
		}
		set
		{
			SetValue("FragmentId", value);
		}
	}

	Fragment _fragmentOfFragmentId;
	public Fragment FragmentOfFragmentId
	{
		get
		{
			if(_fragmentOfFragmentId == null)
			{
				_fragmentOfFragmentId = Brevitee.Analytics.Fragment.OneWhere(c => c.KeyColumn == this.FragmentId);
			}
			return _fragmentOfFragmentId;
		}
	}
	
				
﻿
	[Exclude]	
	public ImageCollection ImagesByUrlId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Image_UrlId"))
			{
				SetChildren();
			}

			var c = (ImageCollection)this.ChildCollections["Image_UrlId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public UrlTagCollection UrlTagsByUrlId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("UrlTag_UrlId"))
			{
				SetChildren();
			}

			var c = (UrlTagCollection)this.ChildCollections["UrlTag_UrlId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			
﻿
		// Xref       
        public XrefDaoCollection<UrlTag, Tag> Tags
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Url_UrlTag_Tag"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<UrlTag, Tag>)this.ChildCollections["Url_UrlTag_Tag"];
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
			var colFilter = new UrlColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Url table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static UrlCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Url>();
			Database db = database ?? Db.For<Url>();
			var results = new UrlCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Url GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Url GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static UrlCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static UrlCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<UrlColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a UrlColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static UrlCollection Where(Func<UrlColumns, QueryFilter<UrlColumns>> where, OrderBy<UrlColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Url>();
			return new UrlCollection(database.GetQuery<UrlColumns, Url>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static UrlCollection Where(WhereDelegate<UrlColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Url>();
			var results = new UrlCollection(database, database.GetQuery<UrlColumns, Url>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static UrlCollection Where(WhereDelegate<UrlColumns> where, OrderBy<UrlColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Url>();
			var results = new UrlCollection(database, database.GetQuery<UrlColumns, Url>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<UrlColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static UrlCollection Where(QiQuery where, Database database = null)
		{
			var results = new UrlCollection(database, Select<UrlColumns>.From<Url>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Url GetOneWhere(QueryFilter where, Database database = null)
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
		public static Url OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<UrlColumns> whereDelegate = (c) => where;
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
		public static Url GetOneWhere(WhereDelegate<UrlColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				UrlColumns c = new UrlColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Url instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Url OneWhere(WhereDelegate<UrlColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<UrlColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Url OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Url FirstOneWhere(WhereDelegate<UrlColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Url FirstOneWhere(WhereDelegate<UrlColumns> where, OrderBy<UrlColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Url FirstOneWhere(QueryFilter where, OrderBy<UrlColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<UrlColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static UrlCollection Top(int count, WhereDelegate<UrlColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static UrlCollection Top(int count, WhereDelegate<UrlColumns> where, OrderBy<UrlColumns> orderBy, Database database = null)
		{
			UrlColumns c = new UrlColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Url>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Url>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<UrlColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<UrlCollection>(0);
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
		public static UrlCollection Top(int count, QueryFilter where, OrderBy<UrlColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Url>();
			QuerySet query = GetQuerySet(db);
			query.Top<Url>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<UrlColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<UrlCollection>(0);
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
		public static UrlCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Url>();
			QuerySet query = GetQuerySet(db);
			query.Top<Url>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<UrlCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a UrlColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between UrlColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<UrlColumns> where, Database database = null)
		{
			UrlColumns c = new UrlColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Url>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Url>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Url CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Url>();			
			var dao = new Url();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Url OneOrThrow(UrlCollection c)
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
