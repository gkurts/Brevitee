using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopItemShopItemAttributeColumns: QueryFilter<ShopItemShopItemAttributeColumns>, IFilterToken
    {
        public ShopItemShopItemAttributeColumns() { }
        public ShopItemShopItemAttributeColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopItemShopItemAttributeColumns KeyColumn
		{
			get
			{
				return new ShopItemShopItemAttributeColumns("Id");
			}
		}	
				
﻿        public ShopItemShopItemAttributeColumns Id
        {
            get
            {
                return new ShopItemShopItemAttributeColumns("Id");
            }
        }

﻿        public ShopItemShopItemAttributeColumns ShopItemId
        {
            get
            {
                return new ShopItemShopItemAttributeColumns("ShopItemId");
            }
        }
﻿        public ShopItemShopItemAttributeColumns ShopItemAttributeId
        {
            get
            {
                return new ShopItemShopItemAttributeColumns("ShopItemAttributeId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShopItemShopItemAttribute);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}