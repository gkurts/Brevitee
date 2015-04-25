using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.ServiceProxy;

namespace Brevitee.Testing.Repository
{
	public class DefineSuiteResponse: RequestResponse
	{
		public CreateStatus Status { get; set; }
	}
}
