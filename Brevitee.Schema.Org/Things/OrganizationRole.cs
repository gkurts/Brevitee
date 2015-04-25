using System;

namespace Brevitee.Schema.Org
{
	///<summary>A subclass of Role used to describe roles within organizations.</summary>
	public class OrganizationRole: Role
	{
		///<summary>A position played, performed or filled by a person or organization, as part of an organization. For example, an athlete in a SportsTeam might play in the position named 'Quarterback'.</summary>
		public ThisOrThat<URL , Text> NamedPosition {get; set;}
	}
}
