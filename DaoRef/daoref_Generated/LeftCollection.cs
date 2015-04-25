using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.DaoRef
{
    public class LeftCollection: DaoCollection<LeftColumns, Left>
    { 
		public LeftCollection(){}
		public LeftCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public LeftCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public LeftCollection(Query<LeftColumns, Left> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public LeftCollection(Database db, Query<LeftColumns, Left> q, bool load) : base(db, q, load) { }
		public LeftCollection(Query<LeftColumns, Left> q, bool load) : base(q, load) { }
    }
}