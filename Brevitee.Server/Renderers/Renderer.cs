using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Brevitee.ServiceProxy;

namespace Brevitee.Server.Renderers
{
    public abstract class Renderer: IRenderer
    {
        public Renderer(string contentType, params string[] extensions)
        {
            this.Extensions = extensions;
            this.ContentType = contentType;
            this.OutputStream = new MemoryStream();
        }

        public string[] Extensions
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public virtual void SetContentType(IResponse response)
        {
            response.ContentType = ContentType;
        }

        public Stream OutputStream { get; set; }


        public virtual void Render(object toRender)
        {
            Render(toRender, OutputStream);
        }

        public abstract void Render(object toRender, Stream output);

        /// <summary>
        /// Sets the content type then calls Render(request.Result, request.Response.OutputStream);
        /// </summary>
        /// <param name="request"></param>
        public virtual void Respond(ExecutionRequest request)
        {
            IResponse response = request.Response;
            object toRender = request.Result;
            SetContentType(response);
            Render(toRender, response.OutputStream);
        }
    }
}
