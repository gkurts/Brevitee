using System;

namespace Brevitee.Schema.Org
{
	///<summary>An entry point, within some Web-based protocol.</summary>
	public class EntryPoint: Intangible
	{
		///<summary>An application that can complete the request.</summary>
		public SoftwareApplication Application {get; set;}
		///<summary>The supported content type(s) for an EntryPoint response.</summary>
		public Text ContentType {get; set;}
		///<summary>The supported encoding type(s) for an EntryPoint request.</summary>
		public Text EncodingType {get; set;}
		///<summary>An HTTP method that specifies the appropriate HTTP method for a request to an HTTP EntryPoint. Values are capitalized strings as used in HTTP.</summary>
		public Text HttpMethod {get; set;}
		///<summary>An url template (RFC6570) that will be used to construct the target of the execution of the action.</summary>
		public Text UrlTemplate {get; set;}
	}
}
