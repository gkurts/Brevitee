using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Caching;
using System.IO;

namespace Brevitee.Management
{
	public class JsCache: TextFileCache
	{
		public JsCache()
		{
			this.FileExtension = ".js";
		}

	}
}
