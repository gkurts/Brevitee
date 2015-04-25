using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Shop
{
    public class ShoppingCartItemCollection: DaoCollection<ShoppingCartItemColumns, ShoppingCartItem>
    { 
		public ShoppingCartItemCollection(){}
		public ShoppingCartItemCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public ShoppingCartItemCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public ShoppingCartItemCollection(Query<ShoppingCartItemColumns, ShoppingCartItem> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public ShoppingCartItemCollection(Database db, Query<ShoppingCartItemColumns, ShoppingCartItem> q, bool load) : base(db, q, load) { }
		public ShoppingCartItemCollection(Query<ShoppingCartItemColumns, ShoppingCartItem> q, bool load) : base(q, load) { }
    }
}