// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Logging.Data
{
	// schema = DaoLogger2
	// connection Name = DaoLogger2
	[Serializable]
	[Brevitee.Data.Table("Event", "DaoLogger2")]
	public partial class Event: Dao
	{
		public Event():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Event(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Event(DataRow data)
		{
			return new Event(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("EventParam_EventId", new EventParamCollection(Database.GetQuery<EventParamColumns, EventParam>((c) => c.EventId == this.Id), this, "EventId"));				﻿
            this.ChildCollections.Add("Event_EventParam_Param",  new XrefDaoCollection<EventParam, Param>(this, false));
							
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

﻿	// property:Time, columnName:Time	
	[Brevitee.Data.Column(Name="Time", DbDataType="DateTime", MaxLength="8", AllowNull=false)]
	public DateTime? Time
	{
		get
		{
			return GetDateTimeValue("Time");
		}
		set
		{
			SetValue("Time", value);
		}
	}

﻿	// property:Severity, columnName:Severity	
	[Brevitee.Data.Column(Name="Severity", DbDataType="Int", MaxLength="10", AllowNull=true)]
	public int? Severity
	{
		get
		{
			return GetIntValue("Severity");
		}
		set
		{
			SetValue("Severity", value);
		}
	}

﻿	// property:EventId, columnName:EventId	
	[Brevitee.Data.Column(Name="EventId", DbDataType="Int", MaxLength="10", AllowNull=true)]
	public int? EventId
	{
		get
		{
			return GetIntValue("EventId");
		}
		set
		{
			SetValue("EventId", value);
		}
	}



﻿	// start SignatureId -> SignatureId
	[Brevitee.Data.ForeignKey(
        Table="Event",
		Name="SignatureId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Signature",
		Suffix="1")]
	public long? SignatureId
	{
		get
		{
			return GetLongValue("SignatureId");
		}
		set
		{
			SetValue("SignatureId", value);
		}
	}

	Signature _signatureOfSignatureId;
	public Signature SignatureOfSignatureId
	{
		get
		{
			if(_signatureOfSignatureId == null)
			{
				_signatureOfSignatureId = Brevitee.Logging.Data.Signature.OneWhere(c => c.KeyColumn == this.SignatureId);
			}
			return _signatureOfSignatureId;
		}
	}
	
﻿	// start ComputerNameId -> ComputerNameId
	[Brevitee.Data.ForeignKey(
        Table="Event",
		Name="ComputerNameId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="ComputerName",
		Suffix="2")]
	public long? ComputerNameId
	{
		get
		{
			return GetLongValue("ComputerNameId");
		}
		set
		{
			SetValue("ComputerNameId", value);
		}
	}

	ComputerName _computerNameOfComputerNameId;
	public ComputerName ComputerNameOfComputerNameId
	{
		get
		{
			if(_computerNameOfComputerNameId == null)
			{
				_computerNameOfComputerNameId = Brevitee.Logging.Data.ComputerName.OneWhere(c => c.KeyColumn == this.ComputerNameId);
			}
			return _computerNameOfComputerNameId;
		}
	}
	
﻿	// start CategoryNameId -> CategoryNameId
	[Brevitee.Data.ForeignKey(
        Table="Event",
		Name="CategoryNameId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="CategoryName",
		Suffix="3")]
	public long? CategoryNameId
	{
		get
		{
			return GetLongValue("CategoryNameId");
		}
		set
		{
			SetValue("CategoryNameId", value);
		}
	}

	CategoryName _categoryNameOfCategoryNameId;
	public CategoryName CategoryNameOfCategoryNameId
	{
		get
		{
			if(_categoryNameOfCategoryNameId == null)
			{
				_categoryNameOfCategoryNameId = Brevitee.Logging.Data.CategoryName.OneWhere(c => c.KeyColumn == this.CategoryNameId);
			}
			return _categoryNameOfCategoryNameId;
		}
	}
	
﻿	// start SourceNameId -> SourceNameId
	[Brevitee.Data.ForeignKey(
        Table="Event",
		Name="SourceNameId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="SourceName",
		Suffix="4")]
	public long? SourceNameId
	{
		get
		{
			return GetLongValue("SourceNameId");
		}
		set
		{
			SetValue("SourceNameId", value);
		}
	}

	SourceName _sourceNameOfSourceNameId;
	public SourceName SourceNameOfSourceNameId
	{
		get
		{
			if(_sourceNameOfSourceNameId == null)
			{
				_sourceNameOfSourceNameId = Brevitee.Logging.Data.SourceName.OneWhere(c => c.KeyColumn == this.SourceNameId);
			}
			return _sourceNameOfSourceNameId;
		}
	}
	
﻿	// start UserNameId -> UserNameId
	[Brevitee.Data.ForeignKey(
        Table="Event",
		Name="UserNameId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="UserName",
		Suffix="5")]
	public long? UserNameId
	{
		get
		{
			return GetLongValue("UserNameId");
		}
		set
		{
			SetValue("UserNameId", value);
		}
	}

	UserName _userNameOfUserNameId;
	public UserName UserNameOfUserNameId
	{
		get
		{
			if(_userNameOfUserNameId == null)
			{
				_userNameOfUserNameId = Brevitee.Logging.Data.UserName.OneWhere(c => c.KeyColumn == this.UserNameId);
			}
			return _userNameOfUserNameId;
		}
	}
	
				
﻿
	[Exclude]	
	public EventParamCollection EventParamsByEventId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("EventParam_EventId"))
			{
				SetChildren();
			}

			var c = (EventParamCollection)this.ChildCollections["EventParam_EventId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			
﻿
		// Xref       
        public XrefDaoCollection<EventParam, Param> Params
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Event_EventParam_Param"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<EventParam, Param>)this.ChildCollections["Event_EventParam_Param"];
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
			var colFilter = new EventColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Event table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static EventCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Event>();
			Database db = database ?? Db.For<Event>();
			var results = new EventCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Event GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Event GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static EventCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static EventCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<EventColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a EventColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EventCollection Where(Func<EventColumns, QueryFilter<EventColumns>> where, OrderBy<EventColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Event>();
			return new EventCollection(database.GetQuery<EventColumns, Event>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EventCollection Where(WhereDelegate<EventColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Event>();
			var results = new EventCollection(database, database.GetQuery<EventColumns, Event>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EventCollection Where(WhereDelegate<EventColumns> where, OrderBy<EventColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Event>();
			var results = new EventCollection(database, database.GetQuery<EventColumns, Event>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EventColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EventCollection Where(QiQuery where, Database database = null)
		{
			var results = new EventCollection(database, Select<EventColumns>.From<Event>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Event GetOneWhere(QueryFilter where, Database database = null)
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
		public static Event OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<EventColumns> whereDelegate = (c) => where;
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
		public static Event GetOneWhere(WhereDelegate<EventColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				EventColumns c = new EventColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Event instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Event OneWhere(WhereDelegate<EventColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EventColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Event OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Event FirstOneWhere(WhereDelegate<EventColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Event FirstOneWhere(WhereDelegate<EventColumns> where, OrderBy<EventColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Event FirstOneWhere(QueryFilter where, OrderBy<EventColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<EventColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EventCollection Top(int count, WhereDelegate<EventColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EventCollection Top(int count, WhereDelegate<EventColumns> where, OrderBy<EventColumns> orderBy, Database database = null)
		{
			EventColumns c = new EventColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Event>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Event>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<EventColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EventCollection>(0);
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
		public static EventCollection Top(int count, QueryFilter where, OrderBy<EventColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Event>();
			QuerySet query = GetQuerySet(db);
			query.Top<Event>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<EventColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EventCollection>(0);
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
		public static EventCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Event>();
			QuerySet query = GetQuerySet(db);
			query.Top<Event>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<EventCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EventColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EventColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<EventColumns> where, Database database = null)
		{
			EventColumns c = new EventColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Event>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Event>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Event CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Event>();			
			var dao = new Event();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Event OneOrThrow(EventCollection c)
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
