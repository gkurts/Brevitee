using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Logging.Data
{
    public class EventParamCollection: DaoCollection<EventParamColumns, EventParam>
    { 
		public EventParamCollection(){}
		public EventParamCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public EventParamCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public EventParamCollection(Query<EventParamColumns, EventParam> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public EventParamCollection(Database db, Query<EventParamColumns, EventParam> q, bool load) : base(db, q, load) { }
		public EventParamCollection(Query<EventParamColumns, EventParam> q, bool load) : base(q, load) { }
    }
}