using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Incubation;
using System.Data.Common;
using System.Data.SqlClient;

namespace Brevitee.Data.MsSql
{
	public class MsSqlDatabase: Database, IHasConnectionStringResolver
	{
		public MsSqlDatabase(string serverName, string databaseName, MsSqlCredentials credentials = null)
			: this(serverName, databaseName, databaseName, credentials)
		{ }

		public MsSqlDatabase(string serverName, string databaseName, string connectionName, MsSqlCredentials credentials = null)
			: base()
		{
			this.ConnectionStringResolver = new MsSqlConnectionStringResolver(serverName, databaseName, credentials);

			this.ConnectionName = connectionName;
			this.ServiceProvider = new Incubator();
			this.ServiceProvider.Set<DbProviderFactory>(SqlClientFactory.Instance);
			MsSqlRegistrar.Register(this);
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
