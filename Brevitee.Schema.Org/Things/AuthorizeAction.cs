using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of granting permission to an object.</summary>
	public class AuthorizeAction: AllocateAction
	{
		///<summary>A sub property of participant. The participant who is at the receiving end of the action.</summary>
		public ThisOrThat<Audience , Person , Organization> Recipient {get; set;}
	}
}
