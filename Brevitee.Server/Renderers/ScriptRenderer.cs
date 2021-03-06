using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Brevitee.Web;
using Brevitee.Html;
using Brevitee.Server;
using Brevitee.ServiceProxy;
using System.Reflection;

namespace Brevitee.Server.Renderers
{
    public class ScriptRenderer: ContentRenderer
    {
        Dictionary<string, byte[]> _cache;
        Dictionary<string, byte[]> _minCache;
        public ScriptRenderer(ExecutionRequest request, ContentResponder content)
            : base(request, content, "application/javascript", Extensions)
        {
            this._cache = new Dictionary<string, byte[]>();
            this._minCache = new Dictionary<string,byte[]>();
            string path = request.Request.Url.AbsolutePath;

            if (!request.WasExecuted)
            {
                request.Execute();
            }

            if (request.Success && request.Result is BreviteeApplicationManagerResult)
            {
                request.Result = ((BreviteeApplicationManagerResult)request.Result).Data;
            }

            HandlePrependAndPostpend();

            string script = request.Result as string;
            if (script == null)
            {
                string type = "null";
                
                if (request.Result != null)
                {
                    type = request.Result.GetType().Name;
                    request.Result = script;
                }

                script = ";\r\nalert('expected a script but was ({0}) instead');"._Format(type);
            }
            
            content.SetCacheAndGetBytes(_cache, _minCache, path, script);            

            SetResult();
        }

        static string[] _extensions = new string[] { ".js", ".jsonp", ".min" };
        public static string[] Extensions
        {
            get
            {
                return _extensions;
            }
        }

        private void SetResult()
        {
            string path = ExecutionRequest.Request.Url.AbsolutePath;
            if (!string.IsNullOrEmpty(ExecutionRequest.Ext) && ExecutionRequest.Ext.Equals(".min"))
            {
                ExecutionRequest.Result = _minCache[path];
            }
            else
            {
                ExecutionRequest.Result = _cache[path];
            }
        }

        protected virtual void HandlePrependAndPostpend()
        {
            string ext = ExecutionRequest.Ext;
            // if ext is jsonp
            if (!string.IsNullOrEmpty(ext) && ext.ToLowerInvariant().Equals(".jsonp"))
            {
                HandleJsonp();
            }
            else if (ExecutionRequest.HasCallback)
            {
                Postpend("\r\n;{0}"._Format(ExecutionRequest.Callback));
            }
        }

        protected virtual void HandleJsonp()
        {
            string callBack = ExecutionRequest.HasCallback ? ExecutionRequest.Callback : "alert";
            Prepend("{0}('"._Format(callBack));
            Postpend("');\r\n");
        }

        protected virtual void Prepend(string prepend)
        {
            StringBuilder newResult = new StringBuilder();
            newResult.Append(prepend);
            newResult.Append(ExecutionRequest.Result);
            
            ExecutionRequest.Result = newResult.ToString();
        }

        protected virtual void Postpend(string postpend)
        {
            StringBuilder newResult = new StringBuilder();
            newResult.Append(ExecutionRequest.Result);
            newResult.Append(postpend);

            ExecutionRequest.Result = newResult.ToString();
        }

        public override void Render(object toRender, Stream output)
        {
            Expect.AreSame(ExecutionRequest.Result, toRender, "Attempt to render unexpected value");
            byte[] data = toRender as byte[];
            if (data == null)
            {
                string renderString = toRender as string;
                data = Encoding.UTF8.GetBytes(renderString);
            }

            output.Write(data, 0, data.Length);
        }
    }
}
