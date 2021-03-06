using System;

namespace Brevitee.Schema.Org
{
	///<summary>An airport.</summary>
	public class Airport: CivicStructure
	{
		///<summary>IATA identifier for an airline or airport</summary>
		public Text IataCode {get; set;}
		///<summary>IACO identifier for an airport.</summary>
		public Text IcaoCode {get; set;}
	}
}
