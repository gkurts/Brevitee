using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Repository.Data
{
	[Serializable]
	public class TestPass: RepoData
	{
		public long TestExecutionId { get; set; }
		public virtual TestExecution TestExecution { get; set; }
	}
}
