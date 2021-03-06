// Model is Table
using System;
using System.Data;
using System.Data.Common;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data.Qi;

namespace Brevitee.Encryption
{
	// schema = Encryption
	// connection Name = Encryption
	[Serializable]
	[Brevitee.Data.Table("VaultKey", "Encryption")]
	public partial class VaultKey: Dao
	{
		public VaultKey():base()
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public VaultKey(DataRow data): base(data)
		{
			this.SetKeyColumnName();
			this.SetChildren();
		}

		public static implicit operator VaultKey(DataRow data)
		{
			return new VaultKey(data);
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

﻿	// property:RsaKey, columnName:RsaKey	
	[Brevitee.Data.Column(Name="RsaKey", DbDataType="VarChar", MaxLength="4000", AllowNull=false)]
	public string RsaKey
	{
		get
		{
			return GetStringValue("RsaKey");
		}
		set
		{
			SetValue("RsaKey", value);
		}
	}

﻿	// property:Password, columnName:Password	
	[Brevitee.Data.Column(Name="Password", DbDataType="VarChar", MaxLength="4000", AllowNull=true)]
	public string Password
	{
		get
		{
			return GetStringValue("Password");
		}
		set
		{
			SetValue("Password", value);
		}
	}



﻿	// start VaultId -> VaultId
	[Brevitee.Data.ForeignKey(
        Table="VaultKey",
		Name="VaultId", 
		DbDataType="BigInt", 
		MaxLength="",
		AllowNull=true, 
		ReferencedKey="Id",
		ReferencedTable="Vault",
		Suffix="1")]
	public long? VaultId
	{
		get
		{
			return GetLongValue("VaultId");
		}
		set
		{
			SetValue("VaultId", value);
		}
	}

	Vault _vaultOfVaultId;
	public Vault VaultOfVaultId
	{
		get
		{
			if(_vaultOfVaultId == null)
			{
				_vaultOfVaultId = Brevitee.Encryption.Vault.OneWhere(c => c.KeyColumn == this.VaultId);
			}
			return _vaultOfVaultId;
		}
	}
	
				
		

		/// <summary>
		/// Gets a query filter that should uniquely identify
		/// the current instance.  The default implementation
		/// compares the Id/key field to the current instance's.
		/// </summary> 
		public override IQueryFilter GetUniqueFilter()
		{
			var colFilter = new VaultKeyColumns();
			return (colFilter.KeyColumn == IdValue);
		}
		/// <summary>
		/// Return every record in the VaultKey table.
		/// </summary>
		/// <param name="database">
		/// The database to load from or null
		/// </param>
		public static VaultKeyCollection LoadAll(Database database = null)
		{
			SqlStringBuilder sql = new SqlStringBuilder();
			sql.Select<VaultKey>();
			Database db = database ?? Db.For<VaultKey>();
			var results = new VaultKeyCollection(sql.GetDataTable(db));
			results.Database = db;
			return results;
		}

		public static VaultKey GetById(int id, Database database = null)
		{
			return GetById((long)id, database);
		}

		public static VaultKey GetById(long id, Database database = null)
		{
			return OneWhere(c => c.KeyColumn == id, database);
		}

		public static VaultKeyCollection Query(QueryFilter filter, Database database = null)
		{
			return Where(filter, database);
		}
				
		public static VaultKeyCollection Where(QueryFilter filter, Database database = null)
		{
			WhereDelegate<VaultKeyColumns> whereDelegate = (c) => filter;
			return Where(whereDelegate, database);
		}

		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A Func delegate that recieves a VaultKeyColumns 
		/// and returns a QueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static VaultKeyCollection Where(Func<VaultKeyColumns, QueryFilter<VaultKeyColumns>> where, OrderBy<VaultKeyColumns> orderBy = null, Database database = null)
		{
			database = database ?? Db.For<VaultKey>();
			return new VaultKeyCollection(database.GetQuery<VaultKeyColumns, VaultKey>(where, orderBy), true);
		}
		
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static VaultKeyCollection Where(WhereDelegate<VaultKeyColumns> where, Database database = null)
		{		
			database = database ?? Db.For<VaultKey>();
			var results = new VaultKeyCollection(database, database.GetQuery<VaultKeyColumns, VaultKey>(where), true);
			return results;
		}
		   
		/// <summary>
		/// Execute a query and return the results. 
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static VaultKeyCollection Where(WhereDelegate<VaultKeyColumns> where, OrderBy<VaultKeyColumns> orderBy = null, Database database = null)
		{		
			database = database ?? Db.For<VaultKey>();
			var results = new VaultKeyCollection(database, database.GetQuery<VaultKeyColumns, VaultKey>(where, orderBy), true);
			return results;
		}

		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<VaultKeyColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static VaultKeyCollection Where(QiQuery where, Database database = null)
		{
			var results = new VaultKeyCollection(database, Select<VaultKeyColumns>.From<VaultKey>().Where(where, database));
			return results;
		}
				
		/// <summary>
		/// Get one entry matching the specified filter.  If none exists 
		/// one will be created; success will depend on the nullability
		/// of the specified columns.
		/// </summary>
		public static VaultKey GetOneWhere(QueryFilter where, Database database = null)
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
		public static VaultKey OneWhere(QueryFilter where, Database database = null)
		{
			WhereDelegate<VaultKeyColumns> whereDelegate = (c) => where;
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
		public static VaultKey GetOneWhere(WhereDelegate<VaultKeyColumns> where, Database database = null)
		{
			var result = OneWhere(where, database);
			if(result == null)
			{
				VaultKeyColumns c = new VaultKeyColumns();
				IQueryFilter filter = where(c); 
				result = CreateFromFilter(filter, database);
			}

			return result;
		}

		/// <summary>
		/// Execute a query that should return only one result.  If more
		/// than one result is returned a MultipleEntriesFoundException will 
		/// be thrown.  This method is most commonly used to retrieve a
		/// single VaultKey instance by its Id/Key value
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static VaultKey OneWhere(WhereDelegate<VaultKeyColumns> where, Database database = null)
		{
			var result = Top(1, where, database);
			return OneOrThrow(result);
		}
					 
		/// <summary>
		/// This method is intended to respond to client side Qi queries.
		/// Use of this method from .Net should be avoided in favor of 
		/// one of the methods that take a delegate of type
		/// WhereDelegate<VaultKeyColumns>.
		/// </summary>
		/// <param name="where"></param>
		/// <param name="database"></param>
		public static VaultKey OneWhere(QiQuery where, Database database = null)
		{
			var results = Top(1, where, database);
			return OneOrThrow(results);
		}

		/// <summary>
		/// Execute a query and return the first result.  This method will issue a sql TOP clause so only the 
		/// specified number of values will be returned.
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static VaultKey FirstOneWhere(WhereDelegate<VaultKeyColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static VaultKey FirstOneWhere(WhereDelegate<VaultKeyColumns> where, OrderBy<VaultKeyColumns> orderBy, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static VaultKey FirstOneWhere(QueryFilter where, OrderBy<VaultKeyColumns> orderBy = null, Database database = null)
		{
			WhereDelegate<VaultKeyColumns> whereDelegate = (c) => where;
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
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="database"></param>
		public static VaultKeyCollection Top(int count, WhereDelegate<VaultKeyColumns> where, Database database = null)
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
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="orderBy">
		/// Specifies what column and direction to order the results by
		/// </param>
		/// <param name="database"></param>
		public static VaultKeyCollection Top(int count, WhereDelegate<VaultKeyColumns> where, OrderBy<VaultKeyColumns> orderBy, Database database = null)
		{
			VaultKeyColumns c = new VaultKeyColumns();
			IQueryFilter filter = where(c);         
			
			Database db = database ?? Db.For<VaultKey>();
			QuerySet query = GetQuerySet(db); 
			query.Top<VaultKey>(count);
			query.Where(filter);

			if(orderBy != null)
			{
				query.OrderBy<VaultKeyColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<VaultKeyCollection>(0);
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
		public static VaultKeyCollection Top(int count, QueryFilter where, OrderBy<VaultKeyColumns> orderBy = null, Database database = null)
		{
			Database db = database ?? Db.For<VaultKey>();
			QuerySet query = GetQuerySet(db);
			query.Top<VaultKey>(count);
			query.Where(where);

			if(orderBy != null)
			{
				query.OrderBy<VaultKeyColumns>(orderBy);
			}

			query.Execute(db);
			var results = query.Results.As<VaultKeyCollection>(0);
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
		public static VaultKeyCollection Top(int count, QiQuery where, Database database = null)
		{
			Database db = database ?? Db.For<VaultKey>();
			QuerySet query = GetQuerySet(db);
			query.Top<VaultKey>(count);
			query.Where(where);
			query.Execute(db);
			var results = query.Results.As<VaultKeyCollection>(0);
			results.Database = db;
			return results;
		}

		/// <summary>
		/// Execute a query and return the number of results
		/// </summary>
		/// <param name="where">A WhereDelegate that recieves a VaultKeyColumns 
		/// and returns a IQueryFilter which is the result of any comparisons
		/// between VaultKeyColumns and other values
		/// </param>
		/// <param name="db"></param>
		public static long Count(WhereDelegate<VaultKeyColumns> where, Database database = null)
		{
			VaultKeyColumns c = new VaultKeyColumns();
			IQueryFilter filter = where(c) ;

			Database db = database ?? Db.For<VaultKey>();
			QuerySet query = GetQuerySet(db);	 
			query.Count<VaultKey>();
			query.Where(filter);	  
			query.Execute(db);
			return query.Results.As<CountResult>(0).Value;
		}

		private static VaultKey CreateFromFilter(IQueryFilter filter, Database database = null)
		{
			Database db = database ?? Db.For<VaultKey>();			
			var dao = new VaultKey();
			filter.Parameters.Each(p=>
			{
				dao.Property(p.ColumnName, p.Value);
			});
			dao.Save(db);
			return dao;
		}
		
		private static VaultKey OneOrThrow(VaultKeyCollection c)
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
