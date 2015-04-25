using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Incubation;
using System.Data.Common;
using System.Data.SqlClient;
using Brevitee.Data;

namespace Brevitee.Data.MySql
{
	public class MySqlDatabase: Database, IHasConnectionStringResolver
	{
		public MySqlDatabase(string serverName, string databaseName, MySqlCredentials credentials = null)
			: this(serverName, databaseName, databaseName, credentials)
		{ }

		public MySqlDatabase(string serverName, string databaseName, string connectionName, MySqlCredentials credentials = null)
			: base()
		{
			this.ConnectionStringResolver = new MySqlConnectionStringResolver(serverName, databaseName, credentials);

			this.ConnectionName = connectionName;
			this.ServiceProvider = new Incubator();
			this.ServiceProvider.Set<DbProviderFactory>(SqlClientFactory.Instance);
			MySqlRegistrar.Register(this);
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
				if (string.IsNullOrEmpty(_connectionString))
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
	}
}
