using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.DaoRef
{
    public class RightCollection: DaoCollection<RightColumns, Right>
    { 
		public RightCollection(){}
		public RightCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public RightCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public RightCollection(Query<RightColumns, Right> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public RightCollection(Database db, Query<RightColumns, Right> q, bool load) : base(db, q, load) { }
		public RightCollection(Query<RightColumns, Right> q, bool load) : base(q, load) { }
    }
}