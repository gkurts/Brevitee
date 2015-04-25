using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Repository.Data
{
	[Serializable]
	public class TestExecution: RepoData
	{
		public long TestDefinitionId { get; set; }
		public virtual TestDefinition TestDefinition { get; set; }

		public virtual TestFailure[] TestFailures { get; set; }
		public virtual TestPass[] TestPasses { get; set; }

		public long TestSummaryId { get; set; }
		public virtual TestSummary[] Summary { get; set; }
	}
}
