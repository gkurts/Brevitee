using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.Logging.Data
{
    public class CategoryNameCollection: DaoCollection<CategoryNameColumns, CategoryName>
    { 
		public CategoryNameCollection(){}
		public CategoryNameCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public CategoryNameCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public CategoryNameCollection(Query<CategoryNameColumns, CategoryName> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public CategoryNameCollection(Database db, Query<CategoryNameColumns, CategoryName> q, bool load) : base(db, q, load) { }
		public CategoryNameCollection(Query<CategoryNameColumns, CategoryName> q, bool load) : base(q, load) { }
    }
}