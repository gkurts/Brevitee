using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class CurrencyCountryColumns: QueryFilter<CurrencyCountryColumns>, IFilterToken
    {
        public CurrencyCountryColumns() { }
        public CurrencyCountryColumns(string columnName)
            : base(columnName)
        { }
		
		public CurrencyCountryColumns KeyColumn
		{
			get
			{
				return new CurrencyCountryColumns("Id");
			}
		}	
				
﻿        public CurrencyCountryColumns Id
        {
            get
            {
                return new CurrencyCountryColumns("Id");
            }
        }
﻿        public CurrencyCountryColumns Uuid
        {
            get
            {
                return new CurrencyCountryColumns("Uuid");
            }
        }
﻿        public CurrencyCountryColumns Name
        {
            get
            {
                return new CurrencyCountryColumns("Name");
            }
        }

﻿        public CurrencyCountryColumns CurrencyId
        {
            get
            {
                return new CurrencyCountryColumns("CurrencyId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(CurrencyCountry);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}