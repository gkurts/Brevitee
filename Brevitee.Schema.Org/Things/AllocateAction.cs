using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of organizing tasks/objects/events by associating resources to it.</summary>
	public class AllocateAction: OrganizeAction
	{
		///<summary>A goal towards an action is taken. Can be concrete or abstract.</summary>
		public ThisOrThat<Thing , MedicalDevicePurpose> Purpose {get; set;}
	}
}
