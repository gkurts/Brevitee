using System;

namespace Brevitee.Schema.Org
{
	///<summary>A set of characteristics describing parents, who can be interested in viewing some content</summary>
	public class ParentAudience: PeopleAudience
	{
		///<summary>Maximal age of the child</summary>
		public Number ChildMaxAge {get; set;}
		///<summary>Minimal age of the child</summary>
		public Number ChildMinAge {get; set;}
	}
}
