using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using Brevitee.CommandLine;
using Brevitee.Testing;
using Brevitee.Data;
using Brevitee.Data.Oracle;
using Brevitee.Javascript;
using Brevitee.Javascript.Sql;
using Brevitee.Configuration;

namespace Brevitee.Data.Tests
{
	[Serializable]
	public class ConsoleActions: CommandLineTestInterface
	{
		[ConsoleAction]
		public void TestOracleSqlProvider()
		{
			string serverName= "niledev4.bluenile.com";
			OracleSqlProvider db = new OracleSqlProvider();
			OracleCredentials creds = new OracleCredentials { UserId = "APP_BLUENILE_V2", Password = "appdev4" };
			OracleDatabase oracle = new OracleDatabase();
			oracle.ConnectionStringResolver = new OracleConnectionStringResolver { ServerName = serverName, Port = "1521", InstanceName = "niledev4", Credentials = creds };
			db.Database = oracle;

			RunTestQuery(db);
		}

		[ConsoleAction]
		public void TestConfiguredOracleSqlProvider()
		{
			OracleSqlProvider db = new OracleSqlProvider();
			DefaultConfigurer configurer = new DefaultConfigurer();
			configurer.Configure(db);

			RunTestQuery(db);
		}

		[ConsoleAction]
		public void OutputOracleSqlProviderFullName()
		{
			Out(typeof(OracleSqlProvider).AssemblyQualifiedName);
		}

		private static void RunTestQuery(OracleSqlProvider db)
		{
			SqlResponse response = db.Execute("SELECT * FROM diamond WHERE ROWNUM <= 100");
			Expect.IsTrue(response.Count == 100);

			foreach (object result in response.Results)
			{
				OutLineFormat("{0}\r\n", result.PropertiesToString());
			}
		}
	}
}
