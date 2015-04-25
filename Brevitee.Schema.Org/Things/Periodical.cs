using System;

namespace Brevitee.Schema.Org
{
	///<summary>A publication in any medium issued in successive parts bearing numerical or chronological designations and intended, such as a magazine, scholarly journal, or newspaper to continue indefinitely.</summary>
	public class Periodical: CreativeWork
	{
		///<summary>The International Standard Serial Number (ISSN) that identifies this periodical. You can repeat this property to (for example) identify different formats of this periodical.</summary>
		public Text Issn {get; set;}
	}
}
