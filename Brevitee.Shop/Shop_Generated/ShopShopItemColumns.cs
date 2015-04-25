using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopShopItemColumns: QueryFilter<ShopShopItemColumns>, IFilterToken
    {
        public ShopShopItemColumns() { }
        public ShopShopItemColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopShopItemColumns KeyColumn
		{
			get
			{
				return new ShopShopItemColumns("Id");
			}
		}	
				
﻿        public ShopShopItemColumns Id
        {
            get
            {
                return new ShopShopItemColumns("Id");
            }
        }

﻿        public ShopShopItemColumns ShopId
        {
            get
            {
                return new ShopShopItemColumns("ShopId");
            }
        }
﻿        public ShopShopItemColumns ShopItemId
        {
            get
            {
                return new ShopShopItemColumns("ShopItemId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShopShopItem);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}