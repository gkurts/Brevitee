using System;

namespace Brevitee.Schema.Org
{
	///<summary>The geographic coordinates of a place or event.</summary>
	public class GeoCoordinates: StructuredValue
	{
		///<summary>The elevation of a location.</summary>
		public ThisOrThat<Text , Number> Elevation {get; set;}
		///<summary>The latitude of a location. For example 37.42242.</summary>
		public ThisOrThat<Text , Number> Latitude {get; set;}
		///<summary>The longitude of a location. For example -122.08585.</summary>
		public ThisOrThat<Text , Number> Longitude {get; set;}
	}
}
