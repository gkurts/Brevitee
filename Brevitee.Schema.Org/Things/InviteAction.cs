using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of asking someone to attend an event. Reciprocal of RsvpAction.</summary>
	public class InviteAction: CommunicateAction
	{
		///<summary>Upcoming or past event associated with this place or organization. Supersedes events.</summary>
		public Event Event {get; set;}
	}
}
