using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of being defeated in a competitive activity.</summary>
	public class LoseAction: AchieveAction
	{
		///<summary>A sub property of participant. The winner of the action.</summary>
		public Person Winner {get; set;}
	}
}
