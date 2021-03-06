using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class PromotionColumns: QueryFilter<PromotionColumns>, IFilterToken
    {
        public PromotionColumns() { }
        public PromotionColumns(string columnName)
            : base(columnName)
        { }
		
		public PromotionColumns KeyColumn
		{
			get
			{
				return new PromotionColumns("Id");
			}
		}	
				
﻿        public PromotionColumns Id
        {
            get
            {
                return new PromotionColumns("Id");
            }
        }
﻿        public PromotionColumns Uuid
        {
            get
            {
                return new PromotionColumns("Uuid");
            }
        }
﻿        public PromotionColumns Name
        {
            get
            {
                return new PromotionColumns("Name");
            }
        }
﻿        public PromotionColumns ValidFrom
        {
            get
            {
                return new PromotionColumns("ValidFrom");
            }
        }
﻿        public PromotionColumns ValidTo
        {
            get
            {
                return new PromotionColumns("ValidTo");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(Promotion);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}