using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of returning to the origin that which was previously received (concrete objects) or taken (ownership).</summary>
	public class ReturnAction: TransferAction
	{
		///<summary>A sub property of participant. The participant who is at the receiving end of the action.</summary>
		public ThisOrThat<Audience , Person , Organization> Recipient {get; set;}
	}
}
