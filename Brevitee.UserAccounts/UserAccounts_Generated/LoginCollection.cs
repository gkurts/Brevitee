using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.UserAccounts.Data
{
    public class LoginCollection: DaoCollection<LoginColumns, Login>
    { 
		public LoginCollection(){}
		public LoginCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public LoginCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public LoginCollection(Query<LoginColumns, Login> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public LoginCollection(Database db, Query<LoginColumns, Login> q, bool load) : base(db, q, load) { }
		public LoginCollection(Query<LoginColumns, Login> q, bool load) : base(q, load) { }
    }
}