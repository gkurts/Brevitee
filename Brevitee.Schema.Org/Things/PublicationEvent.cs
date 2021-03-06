using System;

namespace Brevitee.Schema.Org
{
	///<summary>A PublicationEvent corresponds indifferently to the event of publication for a CreativeWork of any type e.g. a broadcast event, an on-demand event, a book/journal publication via a variety of delivery media.</summary>
	public class PublicationEvent: Event
	{
		///<summary>A flag to signal that the publication is accessible for free.</summary>
		public Boolean Free {get; set;}
		///<summary>A broadcast service associated with the publication event.</summary>
		public BroadcastService PublishedOn {get; set;}
	}
}
