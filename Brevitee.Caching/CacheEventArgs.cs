using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Caching
{
	public class CacheEventArgs: EventArgs
	{
		public CacheEventArgs() { }

		public Cache Cache { get; set; }
		public CacheItem[] RemovedItems { get; set; }
	}
}
