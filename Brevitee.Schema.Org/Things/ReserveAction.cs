using System;

namespace Brevitee.Schema.Org
{
	///<summary>Reserving a concrete object.Related actions:ScheduleAction: Unlike ScheduleAction, ReserveAction reserves concrete objects (e.g. a table, a hotel) towards a time slot / spatial allocation.</summary>
	public class ReserveAction: ScheduleAction
	{
		///<summary>The time the object is scheduled to.</summary>
		public DateTime ScheduledTime {get; set;}
	}
}
