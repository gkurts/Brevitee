using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopItemPromotionColumns: QueryFilter<ShopItemPromotionColumns>, IFilterToken
    {
        public ShopItemPromotionColumns() { }
        public ShopItemPromotionColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopItemPromotionColumns KeyColumn
		{
			get
			{
				return new ShopItemPromotionColumns("Id");
			}
		}	
				
﻿        public ShopItemPromotionColumns Id
        {
            get
            {
                return new ShopItemPromotionColumns("Id");
            }
        }

﻿        public ShopItemPromotionColumns ShopItemId
        {
            get
            {
                return new ShopItemPromotionColumns("ShopItemId");
            }
        }
﻿        public ShopItemPromotionColumns PromotionId
        {
            get
            {
                return new ShopItemPromotionColumns("PromotionId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShopItemPromotion);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}