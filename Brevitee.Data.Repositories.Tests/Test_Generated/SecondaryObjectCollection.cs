using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Data.Repositories.Tests
{
    public class SecondaryObjectCollection: DaoCollection<SecondaryObjectColumns, SecondaryObject>
    { 
		public SecondaryObjectCollection(){}
		public SecondaryObjectCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public SecondaryObjectCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public SecondaryObjectCollection(Query<SecondaryObjectColumns, SecondaryObject> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public SecondaryObjectCollection(Database db, Query<SecondaryObjectColumns, SecondaryObject> q, bool load) : base(db, q, load) { }
		public SecondaryObjectCollection(Query<SecondaryObjectColumns, SecondaryObject> q, bool load) : base(q, load) { }
    }
}