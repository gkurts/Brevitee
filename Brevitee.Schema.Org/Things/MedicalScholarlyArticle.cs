using System;

namespace Brevitee.Schema.Org
{
	///<summary>A scholarly article in the medical domain.</summary>
	public class MedicalScholarlyArticle: ScholarlyArticle
	{
		///<summary>The type of the medical article, taken from the US NLM MeSH publication type catalog.</summary>
		public Text PublicationType {get; set;}
	}
}
