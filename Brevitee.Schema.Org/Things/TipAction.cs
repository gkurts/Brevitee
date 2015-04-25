using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of giving money voluntarily to a beneficiary in recognition of services rendered.</summary>
	public class TipAction: TradeAction
	{
		///<summary>A sub property of participant. The participant who is at the receiving end of the action.</summary>
		public ThisOrThat<Organization , Person , Audience> Recipient {get; set;}
	}
}
