using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.UserAccounts.Data
{
    public class SettingCollection: DaoCollection<SettingColumns, Setting>
    { 
		public SettingCollection(){}
		public SettingCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public SettingCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public SettingCollection(Query<SettingColumns, Setting> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public SettingCollection(Database db, Query<SettingColumns, Setting> q, bool load) : base(db, q, load) { }
		public SettingCollection(Query<SettingColumns, Setting> q, bool load) : base(q, load) { }
    }
}