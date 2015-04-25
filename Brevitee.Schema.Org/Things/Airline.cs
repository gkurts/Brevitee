using System;

namespace Brevitee.Schema.Org
{
	///<summary>An organization that provides flights for passengers.</summary>
	public class Airline: Organization
	{
		///<summary>IATA identifier for an airline or airport</summary>
		public Text IataCode {get; set;}
	}
}
