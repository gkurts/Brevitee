using System;

namespace Brevitee.Schema.Org
{
	///<summary>The act of giving money to a seller in exchange for goods or services rendered. An agent buys an object, product, or service from a seller for a price. Reciprocal of SellAction.</summary>
	public class BuyAction: TradeAction
	{
		///<summary>An entity which offers (sells / leases / lends / loans) the services / goods.  A seller may also be a provider. Supersedes merchant, vendor.</summary>
		public ThisOrThat<Organization , Person> Seller {get; set;}
		///<summary>The warranty promise(s) included in the offer.</summary>
		public WarrantyPromise WarrantyPromise {get; set;}
	}
}
