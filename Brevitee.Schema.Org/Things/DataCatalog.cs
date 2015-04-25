using System;

namespace Brevitee.Schema.Org
{
	///<summary>A collection of datasets.</summary>
	public class DataCatalog: CreativeWork
	{
		///<summary>A dataset contained in a catalog.</summary>
		public Dataset Dataset {get; set;}
	}
}
