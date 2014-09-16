using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.UserAccounts.Data
{
    public class PasswordResetCollection: DaoCollection<PasswordResetColumns, PasswordReset>
    { 
		public PasswordResetCollection(){}
		public PasswordResetCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public PasswordResetCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public PasswordResetCollection(Query<PasswordResetColumns, PasswordReset> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public PasswordResetCollection(Database db, Query<PasswordResetColumns, PasswordReset> q, bool load) : base(db, q, load) { }
		public PasswordResetCollection(Query<PasswordResetColumns, PasswordReset> q, bool load) : base(q, load) { }
    }
}