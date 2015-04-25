using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopPromotionColumns: QueryFilter<ShopPromotionColumns>, IFilterToken
    {
        public ShopPromotionColumns() { }
        public ShopPromotionColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopPromotionColumns KeyColumn
		{
			get
			{
				return new ShopPromotionColumns("Id");
			}
		}	
				
﻿        public ShopPromotionColumns Id
        {
            get
            {
                return new ShopPromotionColumns("Id");
            }
        }

﻿        public ShopPromotionColumns ShopId
        {
            get
            {
                return new ShopPromotionColumns("ShopId");
            }
        }
﻿        public ShopPromotionColumns PromotionId
        {
            get
            {
                return new ShopPromotionColumns("PromotionId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShopPromotion);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}