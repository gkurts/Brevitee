using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Data.Tests
{
    public class ListItemColumns: QueryFilter<ListItemColumns>, IFilterToken
    {
        public ListItemColumns() { }
        public ListItemColumns(string columnName)
            : base(columnName)
        { }
		
		public ListItemColumns KeyColumn
		{
			get
			{
				return new ListItemColumns("Id");
			}
		}	
				
﻿        public ListItemColumns Id
        {
            get
            {
                return new ListItemColumns("Id");
            }
        }

﻿        public ListItemColumns ListId
        {
            get
            {
                return new ListItemColumns("ListId");
            }
        }
﻿        public ListItemColumns ItemId
        {
            get
            {
                return new ListItemColumns("ItemId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(ListItem);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}