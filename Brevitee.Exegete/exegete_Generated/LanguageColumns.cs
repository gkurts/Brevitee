using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Exegete
{
    public class LanguageColumns: QueryFilter<LanguageColumns>, IFilterToken
    {
        public LanguageColumns() { }
        public LanguageColumns(string columnName)
            : base(columnName)
        { }
		
		public LanguageColumns KeyColumn
		{
			get
			{
				return new LanguageColumns("Id");
			}
		}	
				
﻿        public LanguageColumns Id
        {
            get
            {
                return new LanguageColumns("Id");
            }
        }
﻿        public LanguageColumns Uuid
        {
            get
            {
                return new LanguageColumns("Uuid");
            }
        }
﻿        public LanguageColumns EnglishName
        {
            get
            {
                return new LanguageColumns("EnglishName");
            }
        }
﻿        public LanguageColumns AllEnglishNames
        {
            get
            {
                return new LanguageColumns("AllEnglishNames");
            }
        }
﻿        public LanguageColumns AllFrenchNames
        {
            get
            {
                return new LanguageColumns("AllFrenchNames");
            }
        }
﻿        public LanguageColumns ISO6392
        {
            get
            {
                return new LanguageColumns("ISO639_2");
            }
        }
﻿        public LanguageColumns ISO6391
        {
            get
            {
                return new LanguageColumns("ISO639_1");
            }
        }


		protected internal Type TableType
		{
			get
			{
				return typeof(Language);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}