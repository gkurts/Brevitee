using System;
using System.Collections.Generic;
using System.Text;
using Brevitee.Data;

namespace Brevitee.Exegete
{
    public class TranslationColumns: QueryFilter<TranslationColumns>, IFilterToken
    {
        public TranslationColumns() { }
        public TranslationColumns(string columnName)
            : base(columnName)
        { }
		
		public TranslationColumns KeyColumn
		{
			get
			{
				return new TranslationColumns("Id");
			}
		}	
				
﻿        public TranslationColumns Id
        {
            get
            {
                return new TranslationColumns("Id");
            }
        }
﻿        public TranslationColumns Uuid
        {
            get
            {
                return new TranslationColumns("Uuid");
            }
        }
﻿        public TranslationColumns TranslatorUuid
        {
            get
            {
                return new TranslationColumns("TranslatorUuid");
            }
        }
﻿        public TranslationColumns Value
        {
            get
            {
                return new TranslationColumns("Value");
            }
        }

﻿        public TranslationColumns TextId
        {
            get
            {
                return new TranslationColumns("TextId");
            }
        }
﻿        public TranslationColumns LanguageId
        {
            get
            {
                return new TranslationColumns("LanguageId");
            }
        }

		protected internal Type TableType
		{
			get
			{
				return typeof(Translation);
			}
		}

		public string Operator { get; set; }

        public override string ToString()
        {
            return base.ColumnName;
        }
	}
}