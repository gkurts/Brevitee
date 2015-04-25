using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.CommandLine;
using Brevitee.Testing;
using Brevitee.Testing.Repository;
using Brevitee.Data.Oracle;
using Brevitee.Javascript.Sql;
using Brevitee.Javascript;

namespace Brevitee.Testing.Repository.Tests
{
	[Serializable]
	public class ConsoleActions: CommandLineTestInterface
	{
		[ConsoleAction]
		public void OutputHughAssemblyQualifiedName()
		{
			OutLine(typeof(TestRepositoryServer).AssemblyQualifiedName, ConsoleColor.Cyan);
		}

		[ConsoleAction]
		public void OutputOracleSqlProviderAssemblyQualifiedName()
		{
			OutLine(typeof(OracleSqlProvider).AssemblyQualifiedName, ConsoleColor.Cyan);
		}
	}
}
