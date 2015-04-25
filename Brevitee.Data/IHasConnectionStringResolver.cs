using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data
{
	public interface IHasConnectionStringResolver
	{
		IConnectionStringResolver ConnectionStringResolver { get; set; }
	}
}
