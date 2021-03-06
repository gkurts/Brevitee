using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class PromotionCollection: DaoCollection<PromotionColumns, Promotion>
    { 
		public PromotionCollection(){}
		public PromotionCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public PromotionCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public PromotionCollection(Query<PromotionColumns, Promotion> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public PromotionCollection(Database db, Query<PromotionColumns, Promotion> q, bool load) : base(db, q, load) { }
		public PromotionCollection(Query<PromotionColumns, Promotion> q, bool load) : base(q, load) { }
    }
}