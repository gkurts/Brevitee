using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Analytics
{
    public class FragmentCollection: DaoCollection<FragmentColumns, Fragment>
    { 
		public FragmentCollection(){}
		public FragmentCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public FragmentCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public FragmentCollection(Query<FragmentColumns, Fragment> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public FragmentCollection(Database db, Query<FragmentColumns, Fragment> q, bool load) : base(db, q, load) { }
		public FragmentCollection(Query<FragmentColumns, Fragment> q, bool load) : base(q, load) { }
    }
}