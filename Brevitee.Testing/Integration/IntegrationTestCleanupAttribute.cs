using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Integration
{
	[AttributeUsage(AttributeTargets.Method)]
	public class IntegrationTestCleanupAttribute: Attribute
	{
	}
}
