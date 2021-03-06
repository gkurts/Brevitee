using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Exegete
{
    public class TranslationCollection: DaoCollection<TranslationColumns, Translation>
    { 
		public TranslationCollection(){}
		public TranslationCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public TranslationCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public TranslationCollection(Query<TranslationColumns, Translation> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public TranslationCollection(Database db, Query<TranslationColumns, Translation> q, bool load) : base(db, q, load) { }
		public TranslationCollection(Query<TranslationColumns, Translation> q, bool load) : base(q, load) { }
    }
}