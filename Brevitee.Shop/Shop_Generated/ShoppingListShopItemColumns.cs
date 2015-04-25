using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShoppingListShopItemColumns: QueryFilter<ShoppingListShopItemColumns>, IFilterToken
    {
        public ShoppingListShopItemColumns() { }
        public ShoppingListShopItemColumns(string columnName)
            : base(columnName)
        { }
		
		public ShoppingListShopItemColumns KeyColumn
		{
			get
			{
				return new ShoppingListShopItemColumns("Id");
			}
		}	
				
﻿        public ShoppingListShopItemColumns Id
        {
            get
            {
                return new ShoppingListShopItemColumns("Id");
            }
        }

﻿        public ShoppingListShopItemColumns ShoppingListId
        {
            get
            {
                return new ShoppingListShopItemColumns("ShoppingListId");
            }
        }
﻿        public ShoppingListShopItemColumns ShopItemId
        {
            get
            {
                return new ShoppingListShopItemColumns("ShopItemId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShoppingListShopItem);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}