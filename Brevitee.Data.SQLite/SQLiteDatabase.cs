using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Incubation;
using System.IO;
using System.Data.SQLite;
using System.Data.Common;

namespace Brevitee.Data.SQLite
{
	public class SQLiteDatabase: Database, IHasConnectionStringResolver
	{
		/// <summary>
		/// Instantiate a new SQLiteDatabase instance where the database
		/// file will be placed into the specified directoryPath using the
		/// specified connectionName as the file name
		/// </summary>
		/// <param name="directoryPath"></param>
		/// <param name="connectionName"></param>
		public SQLiteDatabase(string directoryPath, string connectionName):base()
		{
			DirectoryInfo directory = new DirectoryInfo(directoryPath);
			if (!directory.Exists)
			{
				directory.Create();
			}
			this.ConnectionStringResolver = new SQLiteConnectionStringResolver
			{
				Directory = directory				
			};
			
			this.ConnectionName = connectionName;
			this.ServiceProvider = new Incubator();
			this.ServiceProvider.Set<DbProviderFactory>(SQLiteFactory.Instance);
			SQLiteRegistrar.Register(this);
		}

		public IConnectionStringResolver ConnectionStringResolver
		{
			get;
			set;
		}

		string _connectionString;
		public override string ConnectionString
		{
			get
			{
				if(string.IsNullOrEmpty(_connectionString))
				{
					_connectionString = ConnectionStringResolver.Resolve(ConnectionName).ConnectionString;
				}

				return _connectionString;
			}
			set
			{
				_connectionString = value;
			}
		}

		FileInfo _databaseFile;
		public FileInfo DatabaseFile
		{
			get
			{
				if(_databaseFile == null)
				{
					ConnectionStringResolver.IsInstanceOfType<SQLiteConnectionStringResolver>("ConnectionStringResolver was not of the expected SQLiteConnectionStringResolver type");
					_databaseFile = new FileInfo(((SQLiteConnectionStringResolver)ConnectionStringResolver).GetDatabaseFilePath(ConnectionName));
				}

				return _databaseFile;
			}
		}
	}
}
