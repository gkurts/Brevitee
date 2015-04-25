using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Management
{
	public class WebBook
	{
		public WebBook() { }

		public string Name { get; set; }

		public List<WebBookPage> Pages { get; set; }
	}
}
