using System;

namespace Brevitee.Schema.Org
{
	///<summary>Represents additional information about a relationship or property. For example a Role can be used to say that a 'member' role linking some SportsTeam to a player occurred during a particular time period. Or that a Person's 'actor' role in a Movie was for some particular characterName. Such properties can be attached to a Role entity, which is then associated with the main entities using ordinary properties like 'member' or 'actor'.    </summary>
	public class Role: Intangible
	{
		///<summary>The end date and time of the role, event or item (in ISO 8601 date format).</summary>
		public Date EndDate {get; set;}
		///<summary>The start date and time of the event, role or item (in ISO 8601 date format).</summary>
		public Date StartDate {get; set;}
	}
}
