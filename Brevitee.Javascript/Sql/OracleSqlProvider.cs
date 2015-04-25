using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data;
using Brevitee.Data.Oracle;
using Brevitee.Configuration;

namespace Brevitee.Javascript.Sql
{
	public class OracleSqlProvider: SqlProvider
	{
		public OracleSqlProvider()
		{
		}

		public string OracleUserId { get; set; }
		public string OraclePassword { get; set; }
		public string OracleServerName { get; set; }
		public string OraclePort { get; set; }
		public string OracleInstanceName { get; set; }

		protected override void Initialize()
		{
			OracleDatabase database = new OracleDatabase();
			OracleCredentials creds = new OracleCredentials { UserId = OracleUserId, Password = OraclePassword };
			OracleConnectionStringResolver conn = new OracleConnectionStringResolver { ServerName = OracleServerName, InstanceName = OracleInstanceName, Port = OraclePort, Credentials = creds };
			database.ConnectionStringResolver = conn;
			Database = database;
		}

		#region IConfigurable Members

		public override void Configure(IConfigurer configurer)
		{
			configurer.Configure(this);
			this.CheckRequiredProperties();
		}

		public override void Configure(object configuration)
		{
			this.CopyProperties(configuration);
			this.CheckRequiredProperties();
		}

		#endregion

		#region IHasRequiredProperties Members

		public override string[] RequiredProperties
		{
			get
			{
				return new string[] { "OracleUserId", "OraclePassword", "OracleServerName", "OraclePort", "OracleInstanceName" };
			}
		}

		#endregion
	}
}
