using System;

namespace Brevitee.Schema.Org
{
	///<summary>A brand is a name used by an organization or business person for labeling a product, product group, or similar.</summary>
	public class Brand: Intangible
	{
		///<summary>A logo associated with an organization.</summary>
		public ThisOrThat<URL , ImageObject> Logo {get; set;}
	}
}
