using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Brevitee.Yaml
{
	public class YamlEventArgs: EventArgs
	{
		public YamlEventArgs() { }
		public FileInfo[] Files { get; set; }

		public YamlFile CurrentFile { get; set; }
		public YamlSchema Schema { get; set; }

		public Exception Exception { get; set; }
	}
}
