using System;

namespace Brevitee.Schema.Org
{
	///<summary>An organization such as a school, NGO, corporation, club, etc.</summary>
	public class Organization: Thing
	{
		///<summary>Physical address of the item.</summary>
		public PostalAddress Address {get; set;}
		///<summary>The overall rating, based on a collection of reviews or ratings, of the item.</summary>
		public AggregateRating AggregateRating {get; set;}
		///<summary>The brand(s) associated with a product or service, or the brand(s) maintained by an organization or business person.</summary>
		public ThisOrThat<Organization , Brand> Brand {get; set;}
		///<summary>A contact point for a person or organization. Supersedes contactPoints.</summary>
		public ContactPoint ContactPoint {get; set;}
		///<summary>A relationship between an organization and a department of that organization, also described as an organization (allowing different urls, logos, opening hours). For example: a store with a pharmacy, or a bakery with a cafe.</summary>
		public Organization Department {get; set;}
		///<summary>The date that this organization was dissolved.</summary>
		public Date DissolutionDate {get; set;}
		///<summary>The Dun & Bradstreet DUNS number for identifying an organization or business person.</summary>
		public Text Duns {get; set;}
		///<summary>Email address.</summary>
		public Text Email {get; set;}
		///<summary>Someone working for this organization. Supersedes employees.</summary>
		public Person Employee {get; set;}
		///<summary>Upcoming or past event associated with this place or organization. Supersedes events.</summary>
		public Event Event {get; set;}
		///<summary>The fax number.</summary>
		public Text FaxNumber {get; set;}
		///<summary>A person who founded this organization. Supersedes founders.</summary>
		public Person Founder {get; set;}
		///<summary>The date that this organization was founded.</summary>
		public Date FoundingDate {get; set;}
		///<summary>The Global Location Number (GLN, sometimes also referred to as International Location Number or ILN) of the respective organization, person, or place. The GLN is a 13-digit number used to identify parties and physical locations.</summary>
		public Text GlobalLocationNumber {get; set;}
		///<summary>Points-of-Sales operated by the organization or person.</summary>
		public Place HasPOS {get; set;}
		///<summary>A count of a specific user interactions with this item—for example, 20 UserLikes, 5 UserComments, or 300 UserDownloads. The user interaction type should be one of the sub types of UserInteraction.</summary>
		public Text InteractionCount {get; set;}
		///<summary>The International Standard of Industrial Classification of All Economic Activities (ISIC), Revision 4 code for a particular organization, business person, or place.</summary>
		public Text IsicV4 {get; set;}
		///<summary>The official name of the organization, e.g. the registered company name.</summary>
		public Text LegalName {get; set;}
		///<summary>The location of the event, organization or action.</summary>
		public ThisOrThat<Place , PostalAddress> Location {get; set;}
		///<summary>A logo associated with an organization.</summary>
		public ThisOrThat<URL , ImageObject> Logo {get; set;}
		///<summary>A pointer to products or services offered by the organization or person.</summary>
		public Offer MakesOffer {get; set;}
		///<summary>A member of an Organization or a ProgramMembership. Organizations can be members of organizations; ProgramMembership is typically for individuals. Supersedes members, musicGroupMember. Inverse property: memberOf.</summary>
		public ThisOrThat<Organization , Person> Member {get; set;}
		///<summary>An Organization (or ProgramMembership) to which this Person or Organization belongs. Inverse property: member.</summary>
		public ThisOrThat<Organization , ProgramMembership> MemberOf {get; set;}
		///<summary>The North American Industry Classification System (NAICS) code for a particular organization or business person.</summary>
		public Text Naics {get; set;}
		///<summary>Products owned by the organization or person.</summary>
		public ThisOrThat<Product , OwnershipInfo> Owns {get; set;}
		///<summary>A review of the item. Supersedes reviews.</summary>
		public Review Review {get; set;}
		///<summary>A pointer to products or services sought by the organization or person (demand).</summary>
		public Demand Seeks {get; set;}
		///<summary>A relationship between two organizations where the first includes the second, e.g., as a subsidiary. See also: the more specific 'department' property.</summary>
		public Organization SubOrganization {get; set;}
		///<summary>The Tax / Fiscal ID of the organization or person, e.g. the TIN in the US or the CIF/NIF in Spain.</summary>
		public Text TaxID {get; set;}
		///<summary>The telephone number.</summary>
		public Text Telephone {get; set;}
		///<summary>The Value-added Tax ID of the organization or person.</summary>
		public Text VatID {get; set;}
	}
}
