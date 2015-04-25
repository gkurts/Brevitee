using System;

namespace Brevitee.Schema.Org
{
	///<summary>An agent leaves an event / group with participants/friends at a location.Related actions:JoinAction: The antagonym of LeaveAction.UnRegisterAction: Unlike UnRegisterAction, LeaveAction implies leaving a group/team of people rather than a service.</summary>
	public class LeaveAction: InteractAction
	{
		///<summary>Upcoming or past event associated with this place or organization. Supersedes events.</summary>
		public Event Event {get; set;}
	}
}
