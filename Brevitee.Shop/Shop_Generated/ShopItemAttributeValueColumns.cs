using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopItemAttributeValueColumns: QueryFilter<ShopItemAttributeValueColumns>, IFilterToken
    {
        public ShopItemAttributeValueColumns() { }
        public ShopItemAttributeValueColumns(string columnName)
            : base(columnName)
        { }
		
		public ShopItemAttributeValueColumns KeyColumn
		{
			get
			{
				return new ShopItemAttributeValueColumns("Id");
			}
		}	
				
﻿        public ShopItemAttributeValueColumns Id
        {
            get
            {
                return new ShopItemAttributeValueColumns("Id");
            }
        }
﻿        public ShopItemAttributeValueColumns Uuid
        {
            get
            {
                return new ShopItemAttributeValueColumns("Uuid");
            }
        }
﻿        public ShopItemAttributeValueColumns Value
        {
            get
            {
                return new ShopItemAttributeValueColumns("Value");
            }
        }

﻿        public ShopItemAttributeValueColumns ShopItemAttributeId
        {
            get
            {
                return new ShopItemAttributeValueColumns("ShopItemAttributeId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ShopItemAttributeValue);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}