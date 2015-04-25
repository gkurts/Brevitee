using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of physically/electronically dispatching an object for transfer from an origin to a destination.Related actions:ReceiveAction: The reciprocal of SendAction.GiveAction: Unlike GiveAction, SendAction does not imply the transfer of ownership (e.g. I can send you my laptop, but I'm not necessarily giving it to you).</summary>
	public class SendAction: ReceiveAction
	{
		///<summary>A sub property of instrument. The method of delivery</summary>
		public DeliveryMethod DeliveryMethod {get; set;}
		///<summary>A sub property of participant. The participant who is at the receiving end of the action.</summary>
		public ThisOrThat<Audience , Person , Organization> Recipient {get; set;}
	}
}
