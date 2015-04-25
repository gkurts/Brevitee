using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Exegete
{
    public class LanguageCollection: DaoCollection<LanguageColumns, Language>
    { 
		public LanguageCollection(){}
		public LanguageCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public LanguageCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public LanguageCollection(Query<LanguageColumns, Language> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public LanguageCollection(Database db, Query<LanguageColumns, Language> q, bool load) : base(db, q, load) { }
		public LanguageCollection(Query<LanguageColumns, Language> q, bool load) : base(q, load) { }
    }
}