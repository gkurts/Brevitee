using System;

namespace Brevitee.Schema.Org
{
	///<summary>An agent joins an event/group with participants/friends at a location.Related actions:RegisterAction: Unlike RegisterAction, JoinAction refers to joining a group/team of people.SubscribeAction: Unlike SubscribeAction, JoinAction does not imply that you'll be receiving updates.FollowAction: Unlike FollowAction, JoinAction does not imply that you'll be polling for updates.</summary>
	public class JoinAction: SubscribeAction
	{
		///<summary>Upcoming or past event associated with this place or organization. Supersedes events.</summary>
		public Event Event {get; set;}
	}
}
