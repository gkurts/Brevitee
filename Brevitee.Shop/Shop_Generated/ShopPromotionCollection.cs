using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShopPromotionCollection: DaoCollection<ShopPromotionColumns, ShopPromotion>
    { 
		public ShopPromotionCollection(){}
		public ShopPromotionCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public ShopPromotionCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public ShopPromotionCollection(Query<ShopPromotionColumns, ShopPromotion> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public ShopPromotionCollection(Database db, Query<ShopPromotionColumns, ShopPromotion> q, bool load) : base(db, q, load) { }
		public ShopPromotionCollection(Query<ShopPromotionColumns, ShopPromotion> q, bool load) : base(q, load) { }
    }
}