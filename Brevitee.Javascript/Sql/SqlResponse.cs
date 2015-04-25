using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Javascript.Sql
{
	public class SqlResponse
	{
		public SqlResponse() { }
		public int Count { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }

		public object[] Results { get; set; }
	}
}
