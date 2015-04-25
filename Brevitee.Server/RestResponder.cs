using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Brevitee;
using Brevitee.ServiceProxy;
using Brevitee.Logging;
using Brevitee.Data.Repositories;
using Brevitee.Server.Renderers;
using Brevitee.Yaml;
using System.IO;

namespace Brevitee.Server
{
	public class RestResponder: HttpMethodResponder
	{
		RouteCollection _routeCollection;
		public RestResponder(BreviteeConf conf, IRepository repository, ILogger logger = null)
			: base(conf, logger)
		{
			RouteCollection routes = new RouteCollection();			
			// ** Create / POST (data in request body)**
			// /{Type}.{ext}
			routes.MapRoute(
					name: "POST",
					url: "{Type}.{ext}"
				);			
			// ** Retrieve / GET **
			// /{Type}/{Id}.{ext}
			// /{Type}/{Id}/{ChildListProperty}.{ext}
			// /{Type}.{ext}?prop1=val1&prop2=val2
			// /{Type}.{ext}?query=<qi-query>			
			routes.MapRoute(
					name: "GET",
					url: "{Type}/{Id}.{ext}"
				);
			routes.MapRoute(
					name: "GET_CHILD_LIST",
					url: "{Type}/{Id}/{ChildListProperty}.{ext}"
				);
			routes.MapRoute(
					name: "GET_SEARCH",
					url: "{Type}.{ext}?{Query}"
				);
			// ** Update / PUT (data in request body)**
			// /{Type}/{Id}
			routes.MapRoute(
					name: "PUT",
					url: "{Type}/{Id}"
				);			
			// ** Delete / DELETE
			// /{Type}/{Id}
			routes.MapRoute(
					name: "DELETE",
					url: "{Type}/{Id}"
				);

			this._routeCollection = routes;
			this.Renderer = new SmartRenderer(logger);
		}

		public RouteCollection Routes
		{
			get
			{
				return _routeCollection;
			}
		}

		public IRepository Repository { get; set; }

		// ** Create / POST (data in request body)**
		// /{Type}.{ext}
		protected override bool Post(IHttpContext context)
		{
			IRequest request = context.Request;
			IResponse response = context.Response;
			
			RouteData routeData = _routeCollection.GetRouteData(new HttpContextWrapper(context));			
			string typeName = (string)routeData.DataTokens["Type"];

			Type type = Repository.StorableTypes.FirstOrDefault(t => t.Name.ToLowerInvariant().Equals(typeName.ToLowerInvariant()));
			bool result = false;
			if (type != null)
			{
				string fileExtension = (string)routeData.DataTokens["ext"];
				if (Deserializers.ContainsKey(fileExtension))
				{
					string postBody = ReadInputBody(request);
					object value = Deserializers[fileExtension](postBody, type);
					Repository.Create(value);
					Renderer.Render(new RestResponse { Success = true, Data = value }, response.OutputStream);
					result = true;
				}
			}
			return result;
		}

		// ** Retrieve / GET **
		// /{Type}/{Id}.{ext}
		// /{Type}/{Id}/{ChildListProperty}.{ext}
		// /{Type}.{ext}?{Query}
		protected override bool Get(IHttpContext context)
		{
			IRequest request = context.Request;
			IResponse response = context.Response;
			
			RouteData routeData = _routeCollection.GetRouteData(new HttpContextWrapper(context));
			string typeName = (string)routeData.DataTokens["Type"];
			long id = (long)routeData.DataTokens["Id"];
			string fileExtension = (string)routeData.DataTokens["ext"];
			string childListProperty = (string)routeData.DataTokens["ChildListProperty"];
			string query = (string)routeData.DataTokens["Query"];

			Type type = Repository.StorableTypes.FirstOrDefault(t => t.Name.ToLowerInvariant().Equals(typeName.ToLowerInvariant()));
			bool result = false;
			if (type != null) // /, {Type}
			{			
			}
			return result;
		}

		protected override bool Put(IHttpContext context)
		{
			throw new NotImplementedException();
		}

		protected override bool Delete(IHttpContext context)
		{
			throw new NotImplementedException();
		}
		public SmartRenderer Renderer
		{
			get;
			private set;
		}

		Dictionary<string, Func<string, Type, object>> _deserializers;
		object _deserializerLock = new object();
		protected Dictionary<string, Func<string, Type, object>> Deserializers
		{
			get
			{
				return _deserializerLock.DoubleCheckLock(ref _deserializers, () =>
				{
					_deserializers.Add(".json", (s, t) =>
					{
						return s.FromJson(t);
					});
					_deserializers.Add(".xml", (s, t) =>
					{
						return s.FromXml(t);
					});
					Func<string, Type, object> yaml = (s, t) =>
					{
						return s.FromYaml(t);
					};
					_deserializers.Add(".yml", yaml);
					_deserializers.Add(".yaml", yaml);
					return _deserializers;
				});
			}
		}

		Dictionary<string, Func<string, object>> _serializers;
		object _serializerLock = new object();
		protected Dictionary<string, Func<string, object>> Serializers
		{
			get
			{
				return _serializerLock.DoubleCheckLock(ref _serializers, () =>
				{
					_serializers.Add(".json", (o) =>
					{
						return o.ToJson();
					});
					_serializers.Add(".xml", (o) =>
					{
						return o.ToXml();
					});
					Func<string, object> yaml = (o) =>
					{
						return o.ToYaml();
					};
					_serializers.Add(".yml", yaml);
					_serializers.Add(".yaml", yaml);
					return _serializers;
				});
			}
		}

		private string ReadInputBody(IRequest request)
		{
			string result = string.Empty;
			using (StreamReader sr = new StreamReader(request.InputStream))
			{
				result = sr.ReadToEnd();
			}
			return result;
		}

	}
}
