using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Logging.Data
{
    public class ParamCollection: DaoCollection<ParamColumns, Param>
    { 
		public ParamCollection(){}
		public ParamCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public ParamCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public ParamCollection(Query<ParamColumns, Param> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public ParamCollection(Database db, Query<ParamColumns, Param> q, bool load) : base(db, q, load) { }
		public ParamCollection(Query<ParamColumns, Param> q, bool load) : base(q, load) { }
    }
}