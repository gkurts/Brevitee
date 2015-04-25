using System;

namespace Brevitee.Schema.Org
{
	///<summary>A set of characteristics belonging to businesses, e.g. who compose an item's target audience.</summary>
	public class BusinessAudience: Audience
	{
		///<summary>The size of business by number of employees.</summary>
		public QuantitativeValue NumberofEmployees {get; set;}
		///<summary>The size of the business in annual revenue.</summary>
		public QuantitativeValue YearlyRevenue {get; set;}
		///<summary>The age of the business.</summary>
		public QuantitativeValue YearsInOperation {get; set;}
	}
}
