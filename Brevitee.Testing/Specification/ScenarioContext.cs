using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Specification
{
	public class ScenarioContext
	{
		public ScenarioContext()
		{
			this.Scenarios = new Queue<Scenario>();
		}
		public Queue<Scenario> Scenarios { get; set; }
	}
}
