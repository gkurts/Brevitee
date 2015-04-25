using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Logging;
using Brevitee.ServiceProxy;

namespace Brevitee.Server
{
	public class RpcResponder: HttpMethodResponder
	{
		public RpcResponder(BreviteeConf conf, ILogger logger = null)
			: base(conf, logger)
		{ }

		protected override bool Post(IHttpContext context)
		{
			throw new NotImplementedException();
		}

		protected override bool Get(IHttpContext context)
		{
			throw new NotImplementedException();
		}

		protected override bool Put(IHttpContext context)
		{
			throw new NotImplementedException();
		}

		protected override bool Delete(IHttpContext context)
		{
			throw new NotImplementedException();
		}
	}
}
