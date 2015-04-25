using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Logging.Data
{
    public class SourceNameCollection: DaoCollection<SourceNameColumns, SourceName>
    { 
		public SourceNameCollection(){}
		public SourceNameCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public SourceNameCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public SourceNameCollection(Query<SourceNameColumns, SourceName> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public SourceNameCollection(Database db, Query<SourceNameColumns, SourceName> q, bool load) : base(db, q, load) { }
		public SourceNameCollection(Query<SourceNameColumns, SourceName> q, bool load) : base(q, load) { }
    }
}