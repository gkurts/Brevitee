using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data;
using Brevitee.Web;
using Brevitee.Logging;
using Brevitee.ServiceProxy;

namespace Brevitee.Server
{
	public abstract class HttpMethodResponder : ResponderBase
	{
		public HttpMethodResponder(BreviteeConf conf)
			: base(conf)
		{
			this.BreviteeConf = conf;
		}
		public HttpMethodResponder(BreviteeConf conf, ILogger logger)
			: this(conf)
		{
			this.Logger = logger;
		}

		public override bool TryRespond(IHttpContext context)
		{
			bool responded = false;
			string httpMethod = context.Request.HttpMethod.ToUpperInvariant();
			if (HttpMethodHandlers.ContainsKey(httpMethod))
			{
				responded = HttpMethodHandlers[httpMethod](context);
			}

			return responded;
		}

		protected abstract bool Post(IHttpContext context);

		protected abstract bool Get(IHttpContext context);		
		
		protected abstract bool Put(IHttpContext context);

		protected abstract bool Delete(IHttpContext context);


		protected virtual bool Connect(IHttpContext context)
		{
			return false;
		}
		protected virtual bool Head(IHttpContext context)
		{
			return false;
		}
		protected virtual bool Options(IHttpContext context)
		{
			return false;
		}
		protected virtual bool Trace(IHttpContext context)
		{
			return false;
		}

		Dictionary<string, Func<IHttpContext, bool>> _httpMethodHandlers;
		object _httpMethodHandlersLock = new object();
		protected Dictionary<string, Func<IHttpContext, bool>> HttpMethodHandlers
		{
			get
			{
				return _httpMethodHandlersLock.DoubleCheckLock(ref _httpMethodHandlers, () =>
				{
					return new Dictionary<string, Func<IHttpContext, bool>>
					{
						{"POST", Post},
						{"GET", Get},
						{"PUT", Put},
						{"DELETE", Delete},
						{"CONNECT", Connect},
						{"HEAD", Head},
						{"OPTIONS", Options},
						{"TRACE", Trace}
					};
				});
			}
		}

	}
}
