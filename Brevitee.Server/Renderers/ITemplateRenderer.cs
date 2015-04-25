using System;
using Brevitee.ServiceProxy;
namespace Brevitee.Server.Renderers
{
	public interface ITemplateRenderer
	{
		void SetContentType(IResponse response);
		string CompiledCommonTemplates { get; }
		string CompiledLayoutTemplates { get; }
		string CompiledTemplates { get; }
		Brevitee.Server.ContentResponder ContentResponder { get; set; }
		void Render(object toRender, System.IO.Stream output);
		void Render(string templateName, object toRender, System.IO.Stream output);
		void RenderLayout(Brevitee.Server.LayoutModel toRender, System.IO.Stream output);
	}
}
