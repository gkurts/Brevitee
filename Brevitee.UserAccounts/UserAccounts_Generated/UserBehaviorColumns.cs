using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.UserAccounts.Data
{
    public class UserBehaviorColumns: QueryFilter<UserBehaviorColumns>, IFilterToken
    {
        public UserBehaviorColumns() { }
        public UserBehaviorColumns(string columnName)
            : base(columnName)
        { }
		
		public UserBehaviorColumns KeyColumn
		{
			get
			{
				return new UserBehaviorColumns("Id");
			}
		}	
				
﻿        public UserBehaviorColumns Id
        {
            get
            {
                return new UserBehaviorColumns("Id");
            }
        }
﻿        public UserBehaviorColumns Uuid
        {
            get
            {
                return new UserBehaviorColumns("Uuid");
            }
        }
﻿        public UserBehaviorColumns DateTime
        {
            get
            {
                return new UserBehaviorColumns("DateTime");
            }
        }
﻿        public UserBehaviorColumns Selector
        {
            get
            {
                return new UserBehaviorColumns("Selector");
            }
        }
﻿        public UserBehaviorColumns EventName
        {
            get
            {
                return new UserBehaviorColumns("EventName");
            }
        }
﻿        public UserBehaviorColumns Data
        {
            get
            {
                return new UserBehaviorColumns("Data");
            }
        }
﻿        public UserBehaviorColumns Url
        {
            get
            {
                return new UserBehaviorColumns("Url");
            }
        }

﻿        public UserBehaviorColumns SessionId
        {
            get
            {
                return new UserBehaviorColumns("SessionId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(UserBehavior);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}