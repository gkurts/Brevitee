using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee
{
	public class DynamicTypeRecursionLimitReachedException: Exception
	{
		public DynamicTypeRecursionLimitReachedException(int limit)
			: base("The DynamicTypeInfo.RecursionLimit ({0})was reached"._Format(limit))
		{ }
	}
}
