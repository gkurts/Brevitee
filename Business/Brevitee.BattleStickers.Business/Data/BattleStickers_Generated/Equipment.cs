// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.BattleStickers.Services.Data
{
	// schema = BattleStickers
	// connection Name = BattleStickers
	[Serializable]
	[Brevitee.Data.Table("Equipment", "BattleStickers")]
	public partial class Equipment: Dao
	{
		public Equipment():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public Equipment(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator Equipment(DataRow data)
		{
			return new Equipment(data);
		}

		private void SetChildren()
		{
﻿
            this.ChildCollections.Add("Effect_EquipmentId", new EffectCollection(Database.GetQuery<EffectColumns, Effect>((c) => c.EquipmentId == this.Id), this, "EquipmentId"));	﻿
            this.ChildCollections.Add("PlayerEquipment_EquipmentId", new PlayerEquipmentCollection(Database.GetQuery<PlayerEquipmentColumns, PlayerEquipment>((c) => c.EquipmentId == this.Id), this, "EquipmentId"));	﻿
            this.ChildCollections.Add("PlayerOneEquipment_EquipmentId", new PlayerOneEquipmentCollection(Database.GetQuery<PlayerOneEquipmentColumns, PlayerOneEquipment>((c) => c.EquipmentId == this.Id), this, "EquipmentId"));	﻿
            this.ChildCollections.Add("PlayerTwoEquipment_EquipmentId", new PlayerTwoEquipmentCollection(Database.GetQuery<PlayerTwoEquipmentColumns, PlayerTwoEquipment>((c) => c.EquipmentId == this.Id), this, "EquipmentId"));							﻿
            this.ChildCollections.Add("Equipment_PlayerEquipment_Player",  new XrefDaoCollection<PlayerEquipment, Player>(this, false));
				﻿
            this.ChildCollections.Add("Equipment_PlayerOneEquipment_PlayerOne",  new XrefDaoCollection<PlayerOneEquipment, PlayerOne>(this, false));
				﻿
            this.ChildCollections.Add("Equipment_PlayerTwoEquipment_PlayerTwo",  new XrefDaoCollection<PlayerTwoEquipment, PlayerTwo>(this, false));
				
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

﻿	// property:Element, columnName:Element	
	[Brevitee.Data.Column(Name="Element", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string Element
	{
		get
		{
			return GetStringValue("Element");
		}
		set
		{
			SetValue("Element", value);
		}
	}



				
﻿
	[Exclude]	
	public EffectCollection EffectsByEquipmentId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("Effect_EquipmentId"))
			{
				SetChildren();
			}

			var c = (EffectCollection)this.ChildCollections["Effect_EquipmentId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerEquipmentCollection PlayerEquipmentsByEquipmentId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerEquipment_EquipmentId"))
			{
				SetChildren();
			}

			var c = (PlayerEquipmentCollection)this.ChildCollections["PlayerEquipment_EquipmentId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerOneEquipmentCollection PlayerOneEquipmentsByEquipmentId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerOneEquipment_EquipmentId"))
			{
				SetChildren();
			}

			var c = (PlayerOneEquipmentCollection)this.ChildCollections["PlayerOneEquipment_EquipmentId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
	﻿
	[Exclude]	
	public PlayerTwoEquipmentCollection PlayerTwoEquipmentsByEquipmentId
	{
		get
		{
			if (this.IsNew)
			{
				throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
			}

			if(!this.ChildCollections.ContainsKey("PlayerTwoEquipment_EquipmentId"))
			{
				SetChildren();
			}

			var c = (PlayerTwoEquipmentCollection)this.ChildCollections["PlayerTwoEquipment_EquipmentId"];
			if(!c.Loaded)
			{
				c.Load(Database);
			}
			return c;
		}
	}
			

﻿
		// Xref       
        public XrefDaoCollection<PlayerEquipment, Player> Players
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Equipment_PlayerEquipment_Player"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerEquipment, Player>)this.ChildCollections["Equipment_PlayerEquipment_Player"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerOneEquipment, PlayerOne> PlayerOnes
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Equipment_PlayerOneEquipment_PlayerOne"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerOneEquipment, PlayerOne>)this.ChildCollections["Equipment_PlayerOneEquipment_PlayerOne"];
				if(!xref.Loaded)
				{
					xref.Load(Database);
				}

				return xref;
            }
        }﻿
		// Xref       
        public XrefDaoCollection<PlayerTwoEquipment, PlayerTwo> PlayerTwos
        {
            get
            {			
				if (this.IsNew)
				{
					throw new InvalidOperationException("The current instance of type({0}) hasn't been saved and will have no child collections, call Save() or Save(Database) first."._Format(this.GetType().Name));
				}

				if(!this.ChildCollections.ContainsKey("Equipment_PlayerTwoEquipment_PlayerTwo"))
				{
					SetChildren();
				}

				var xref = (XrefDaoCollection<PlayerTwoEquipment, PlayerTwo>)this.ChildCollections["Equipment_PlayerTwoEquipment_PlayerTwo"];
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
			var colFilter = new EquipmentColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the Equipment table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static EquipmentCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<Equipment>();
			Database db = database ?? Db.For<Equipment>();
			var results = new EquipmentCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static Equipment GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static Equipment GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static EquipmentCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static EquipmentCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<EquipmentColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a EquipmentColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EquipmentCollection Where(Func<EquipmentColumns, QueryFilter<EquipmentColumns>> where, OrderBy<EquipmentColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<Equipment>();
			return new EquipmentCollection(database.GetQuery<EquipmentColumns, Equipment>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static EquipmentCollection Where(WhereDelegate<EquipmentColumns> where, Database database = null)
		{		
			database = database ?? Db.For<Equipment>();
			var results = new EquipmentCollection(database, database.GetQuery<EquipmentColumns, Equipment>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EquipmentCollection Where(WhereDelegate<EquipmentColumns> where, OrderBy<EquipmentColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<Equipment>();
			var results = new EquipmentCollection(database, database.GetQuery<EquipmentColumns, Equipment>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EquipmentColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static EquipmentCollection Where(QiQuery where, Database database = null)
		{
			var results = new EquipmentCollection(database, Select<EquipmentColumns>.From<Equipment>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static Equipment GetOneWhere(QueryFilter where, Database database = null)
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
		public static Equipment OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<EquipmentColumns> whereDelegate = (c) => where;
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
		public static Equipment GetOneWhere(WhereDelegate<EquipmentColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				EquipmentColumns c = new EquipmentColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single Equipment instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Equipment OneWhere(WhereDelegate<EquipmentColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<EquipmentColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static Equipment OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Equipment FirstOneWhere(WhereDelegate<EquipmentColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Equipment FirstOneWhere(WhereDelegate<EquipmentColumns> where, OrderBy<EquipmentColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static Equipment FirstOneWhere(QueryFilter where, OrderBy<EquipmentColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<EquipmentColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static EquipmentCollection Top(int count, WhereDelegate<EquipmentColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static EquipmentCollection Top(int count, WhereDelegate<EquipmentColumns> where, OrderBy<EquipmentColumns> orderBy, Database database = null)
		{
			EquipmentColumns c = new EquipmentColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<Equipment>();
			QuerySet query = GetQuerySet(db); 
			query.Top<Equipment>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<EquipmentColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EquipmentCollection>(0);
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
		public static EquipmentCollection Top(int count, QueryFilter where, OrderBy<EquipmentColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<Equipment>();
			QuerySet query = GetQuerySet(db);
			query.Top<Equipment>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<EquipmentColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<EquipmentCollection>(0);
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
		public static EquipmentCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<Equipment>();
			QuerySet query = GetQuerySet(db);
			query.Top<Equipment>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<EquipmentCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a EquipmentColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between EquipmentColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<EquipmentColumns> where, Database database = null)
		{
			EquipmentColumns c = new EquipmentColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<Equipment>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<Equipment>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static Equipment CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<Equipment>();			
			var dao = new Equipment();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static Equipment OneOrThrow(EquipmentCollection c)
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
