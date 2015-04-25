using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Repository.Data
{
	[Serializable]
	public class TestSummary : RepoData
	{
		public long TestExecutionId { get; set; }
		public virtual TestExecution TestExecution { get; set; }
		public int SuiteCount { get; set; }
		public int TestCount { get; set; }
		public int PassedCount { get; set; }
		public int FailedCount { get; set; }
	}
}
