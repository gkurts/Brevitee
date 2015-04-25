using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Testing.Specification
{

	[AttributeUsage(AttributeTargets.Method)]
	public class SpecAttribute: UnitTest
	{
	}
}
