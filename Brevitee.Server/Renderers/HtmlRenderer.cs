using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Brevitee.Web;
using Brevitee.Html;
using Brevitee.Server;
using Brevitee.ServiceProxy;
using System.Reflection;

namespace Brevitee.Server.Renderers
{
    public class HtmlRenderer: ContentRenderer
    {
        public HtmlRenderer(ExecutionRequest request, ContentResponder contentResponder)
            : base(request, contentResponder, "text/html", ".htm", ".html")
        {
            this.AppName = AppConf.AppNameFromUri(request.Request.Url);
            this.ContentResponder = contentResponder;
            this.ExecutionRequest = request;
        }

        public string AppName { get; set; }

        HttpArgs _args;
        protected internal HttpArgs HttpArgs
        {
            get
            {
                if (_args == null)
                {
                    _args = new HttpArgs(ExecutionRequest.Request.Url.Query);
                }
                return _args;
            }
        }

        public string GetTemplateName(object toRender)
        {
            HttpArgs args = HttpArgs;//new HttpArgs(ExecutionRequest.Request.Url.Query);
            string result;
            args.Has("view", out result);
            if (string.IsNullOrEmpty(result))
            {
                string prefix = string.Empty;
                if (toRender != null)
                {
                    Type typeToRender = toRender.GetType();
                    prefix = "{0}_"._Format(typeToRender.Name);
                    AppDustRenderer dustRenderer = ContentResponder.AppContentResponders[AppName].AppDustRenderer;
                    dustRenderer.EnsureDefaultTemplate(typeToRender);
                }
                AppContentResponder appContentResponder = ContentResponder.AppContentResponders[AppName];
                string domAppName = AppConf.DomApplicationIdFromAppName(appContentResponder.AppConf.Name);

                result = "{0}.{1}default"._Format(domAppName, prefix);
            }

            return result;
        }
        /// <summary>
        /// Render the response to the output stream of ExecutionRequest.Response
        /// </summary>
        public void Render()
        {
            Render(ExecutionRequest.Result, ExecutionRequest.Response.OutputStream);
        }

        public override void Render(object toRender, Stream output)
        {
            AppContentResponder appContentResponder = ContentResponder.AppContentResponders[AppName];
            AppDustRenderer dustRenderer = appContentResponder.AppDustRenderer;
            string templateName = GetTemplateName(toRender);
            string templates = dustRenderer.CompiledTemplates;            
            string result = DustScript.Render(templates, templateName, toRender);

            string layout;
            byte[] data;
            if (HttpArgs.Has("layout", out layout))
            {
                string absolutePath = ExecutionRequest.Request.Url.AbsolutePath;
                string extension = Path.GetExtension(absolutePath);
                string path = absolutePath.Truncate(extension.Length);
                LayoutModel layoutModel = appContentResponder.GetLayoutModelForPath(path);
                layoutModel.LayoutName = layout;
                layoutModel.PageContent = result;
                MemoryStream ms = new MemoryStream();
                appContentResponder.CommonTemplateRenderer.RenderLayout(layoutModel, ms);
                ms.Seek(0, SeekOrigin.Begin);
                data = ms.GetBuffer();
            }
            else
            {
                data = Encoding.UTF8.GetBytes(result);
            }
            output.Write(data, 0, data.Length);
        }

       
    }
}
