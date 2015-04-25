using System;

namespace Brevitee.Schema.Org
{
	///<summary>An educational organization.</summary>
	public class EducationalOrganization: Organization
	{
		///<summary>Alumni of educational organization. Inverse property: alumniOf.</summary>
		public Person Alumni {get; set;}
	}
}
