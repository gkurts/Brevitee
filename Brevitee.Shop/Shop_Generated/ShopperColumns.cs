using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopperColumns: QueryFilter<ShopperColumns>, IFilterToken
    {
        public ShopperColumns() { }
        public ShopperColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopperColumns KeyColumn
		{
			get
			{
				return new ShopperColumns("Id");
			}
		}	
				
﻿        public ShopperColumns Id
        {
            get
            {
                return new ShopperColumns("Id");
            }
        }
﻿        public ShopperColumns Uuid
        {
            get
            {
                return new ShopperColumns("Uuid");
            }
        }
﻿        public ShopperColumns Name
        {
            get
            {
                return new ShopperColumns("Name");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(Shopper);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}