using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace Brevitee.Data.MySql
{
	public class MySqlConnectionStringResolver: IConnectionStringResolver
	{
		public MySqlConnectionStringResolver(string serverName, string databaseName, MySqlCredentials credentials = null)
		{
			this.ServerName = serverName;
			this.DatabaseName = databaseName;
			this.Credentials = credentials;
			this.TrustedConnection = credentials == null;
		}

		public string ServerName { get; set; }
		public string DatabaseName { get; set; }

		public bool TrustedConnection { get; set; }

		public MySqlCredentials Credentials { get; set; }

		#region IConnectionStringResolver Members

		public ConnectionStringSettings Resolve(string connectionName)
		{
			ConnectionStringSettings s = new ConnectionStringSettings();
			s.Name = connectionName;
			s.ProviderName = typeof(SqlClientFactory).AssemblyQualifiedName;

			DbConnectionStringBuilder connectionStringBuilder = SqlClientFactory.Instance.CreateConnectionStringBuilder();
			connectionStringBuilder.Add("Data Source", ServerName);
			connectionStringBuilder.Add("Initial Catalog", DatabaseName);
			if (TrustedConnection)
			{
				connectionStringBuilder.Add("Integrated Security", "SSPI");
			}
			else
			{
				connectionStringBuilder.Add("User ID", Credentials.UserName);
				connectionStringBuilder.Add("Password", Credentials.Password);
			}

			s.ConnectionString = connectionStringBuilder.ConnectionString;

			return s;
		}

		#endregion
	}
}
