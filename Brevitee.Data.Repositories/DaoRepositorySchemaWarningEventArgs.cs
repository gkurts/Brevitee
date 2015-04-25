using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	public class DaoRepositorySchemaWarningEventArgs: EventArgs
	{
		public DaoRepositorySchemaWarningEventArgs() { }
		public string ClassName { get; set; }
		public string PropertyName { get; set; }
		public string PropertyType { get; set; }
	}
}
