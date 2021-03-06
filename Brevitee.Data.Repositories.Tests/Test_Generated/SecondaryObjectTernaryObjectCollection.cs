using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Data.Repositories.Tests
{
    public class SecondaryObjectTernaryObjectCollection: DaoCollection<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject>
    { 
		public SecondaryObjectTernaryObjectCollection(){}
		public SecondaryObjectTernaryObjectCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public SecondaryObjectTernaryObjectCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public SecondaryObjectTernaryObjectCollection(Query<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public SecondaryObjectTernaryObjectCollection(Database db, Query<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject> q, bool load) : base(db, q, load) { }
		public SecondaryObjectTernaryObjectCollection(Query<SecondaryObjectTernaryObjectColumns, SecondaryObjectTernaryObject> q, bool load) : base(q, load) { }
    }
}