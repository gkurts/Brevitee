using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Automation.Data
{
    public class DeferredJobCollection: DaoCollection<DeferredJobColumns, DeferredJob>
    { 
		public DeferredJobCollection(){}
		public DeferredJobCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public DeferredJobCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public DeferredJobCollection(Query<DeferredJobColumns, DeferredJob> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public DeferredJobCollection(Database db, Query<DeferredJobColumns, DeferredJob> q, bool load) : base(db, q, load) { }
		public DeferredJobCollection(Query<DeferredJobColumns, DeferredJob> q, bool load) : base(q, load) { }
    }
}