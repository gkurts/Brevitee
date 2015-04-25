using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Repository.Data
{
	[Serializable]
	public class SuiteDefinition: RepoData
	{
		public SuiteDefinition()
		{
		}
		public string Title { get; set; }
		public virtual TestDefinition[] TestDefinitions { get; set; }
	}
}
