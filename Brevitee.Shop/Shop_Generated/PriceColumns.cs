using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class PriceColumns: QueryFilter<PriceColumns>, IFilterToken
    {
        public PriceColumns() { }
        public PriceColumns(string columnName)
            : base(columnName)
        { }
		
		public PriceColumns KeyColumn
		{
			get
			{
				return new PriceColumns("Id");
			}
		}	
				
﻿        public PriceColumns Id
        {
            get
            {
                return new PriceColumns("Id");
            }
        }
﻿        public PriceColumns Uuid
        {
            get
            {
                return new PriceColumns("Uuid");
            }
        }
﻿        public PriceColumns Value
        {
            get
            {
                return new PriceColumns("Value");
            }
        }

﻿        public PriceColumns ShopItemId
        {
            get
            {
                return new PriceColumns("ShopItemId");
            }
        }
﻿        public PriceColumns CurrencyId
        {
            get
            {
                return new PriceColumns("CurrencyId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(Price);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}