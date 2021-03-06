using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Data.Repositories.Tests
{
    public class MainObjectCollection: DaoCollection<MainObjectColumns, MainObject>
    { 
		public MainObjectCollection(){}
		public MainObjectCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public MainObjectCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public MainObjectCollection(Query<MainObjectColumns, MainObject> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public MainObjectCollection(Database db, Query<MainObjectColumns, MainObject> q, bool load) : base(db, q, load) { }
		public MainObjectCollection(Query<MainObjectColumns, MainObject> q, bool load) : base(q, load) { }
    }
}