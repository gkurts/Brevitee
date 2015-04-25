using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Logging.Data
{
    public class EventCollection: DaoCollection<EventColumns, Event>
    { 
		public EventCollection(){}
		public EventCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public EventCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public EventCollection(Query<EventColumns, Event> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public EventCollection(Database db, Query<EventColumns, Event> q, bool load) : base(db, q, load) { }
		public EventCollection(Query<EventColumns, Event> q, bool load) : base(q, load) { }
    }
}