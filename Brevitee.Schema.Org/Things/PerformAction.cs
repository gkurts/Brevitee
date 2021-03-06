using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of participating in performance arts.</summary>
	public class PerformAction: PlayAction
	{
		///<summary>A sub property of location. The entertainment business where the action occurred.</summary>
		public EntertainmentBusiness EntertainmentBusiness {get; set;}
	}
}
