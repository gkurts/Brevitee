using System;

namespace Brevitee.Schema.Org
{
	///<summary>A reservation for a taxi.</summary>
	public class TaxiReservation: Reservation
	{
		///<summary>Number of people the reservation should accommodate.</summary>
		public ThisOrThat<Number , QuantitativeValue> PartySize {get; set;}
		///<summary>Where a taxi will pick up a passenger or a rental car can be picked up.</summary>
		public Place PickupLocation {get; set;}
		///<summary>When a taxi will pickup a passenger or a rental car can be picked up.</summary>
		public DateTime PickupTime {get; set;}
	}
}
