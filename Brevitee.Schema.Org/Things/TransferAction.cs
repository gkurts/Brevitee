using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of transferring/moving (abstract or concrete) animate or inanimate objects from one place to another.</summary>
	public class TransferAction: MoveAction
	{
		///<summary>A sub property of location. The original location of the object or the agent before the action.</summary>
		public ThisOrThat<Number , Place> FromLocation {get; set;}
		///<summary>A sub property of location. The final location of the object or the agent after the action.</summary>
		public ThisOrThat<Number , Place> ToLocation {get; set;}
	}
}
