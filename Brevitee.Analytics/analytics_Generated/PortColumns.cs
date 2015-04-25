using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Analytics
{
    public class PortColumns: QueryFilter<PortColumns>, IFilterToken
    {
        public PortColumns() { }
        public PortColumns(string columnName)
            : base(columnName)
        { }
		
		public PortColumns KeyColumn
		{
			get
			{
				return new PortColumns("Id");
			}
		}	
				
﻿        public PortColumns Id
        {
            get
            {
                return new PortColumns("Id");
            }
        }
﻿        public PortColumns Uuid
        {
            get
            {
                return new PortColumns("Uuid");
            }
        }
﻿        public PortColumns Value
        {
            get
            {
                return new PortColumns("Value");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(Port);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}