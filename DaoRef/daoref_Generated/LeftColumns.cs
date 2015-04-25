using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.DaoRef
{
    public class LeftColumns: QueryFilter<LeftColumns>, IFilterToken
    {
        public LeftColumns() { }
        public LeftColumns(string columnName)
            : base(columnName)
        { }
		
		public LeftColumns KeyColumn
		{
			get
			{
				return new LeftColumns("Id");
			}
		}	
				
﻿        public LeftColumns Id
        {
            get
            {
                return new LeftColumns("Id");
            }
        }
﻿        public LeftColumns Uuid
        {
            get
            {
                return new LeftColumns("Uuid");
            }
        }
﻿        public LeftColumns Name
        {
            get
            {
                return new LeftColumns("Name");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(Left);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}