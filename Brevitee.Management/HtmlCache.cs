using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Caching;

namespace Brevitee.Management
{
	public class HtmlCache: TextFileCache
	{
		public HtmlCache()
		{
			this.FileExtension = ".html";
		}
	}
}
