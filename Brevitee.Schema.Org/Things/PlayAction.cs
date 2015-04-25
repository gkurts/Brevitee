using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of playing/exercising/training/performing for enjoyment, leisure, recreation, Competition or exercise.Related actions:ListenAction: Unlike ListenAction (which is under ConsumeAction), PlayAction refers to performing for an audience or at an event, rather than consuming music.WatchAction: Unlike WatchAction (which is under ConsumeAction), PlayAction refers to showing/displaying for an audience or at an event, rather than consuming visual content.</summary>
	public class PlayAction: Action
	{
		///<summary>The intended audience of the item, i.e. the group for whom the item was created.</summary>
		public Audience Audience {get; set;}
		///<summary>Upcoming or past event associated with this place or organization. Supersedes events.</summary>
		public Event Event {get; set;}
	}
}
