using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Automation.ContinuousIntegration.Data
{
    public class BuildResultCollection: DaoCollection<BuildResultColumns, BuildResult>
    { 
		public BuildResultCollection(){}
		public BuildResultCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public BuildResultCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public BuildResultCollection(Query<BuildResultColumns, BuildResult> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public BuildResultCollection(Database db, Query<BuildResultColumns, BuildResult> q, bool load) : base(db, q, load) { }
		public BuildResultCollection(Query<BuildResultColumns, BuildResult> q, bool load) : base(q, load) { }
    }
}