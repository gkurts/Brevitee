using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Specification
{
	internal class FeatureContext
	{
		public FeatureContext()
		{
			this.Features = new Queue<Feature>();
		}
		public Queue<Feature> Features { get; set; }
	}
}
