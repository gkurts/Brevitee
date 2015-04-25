using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Brevitee.Data;

namespace Brevitee.BattleStickers.Services.Data
{
    public class WeaponCollection: DaoCollection<WeaponColumns, Weapon>
    { 
		public WeaponCollection(){}
		public WeaponCollection(Database db, DataTable table, Dao dao = null, string rc = null) : base(db, table, dao, rc) { }
		public WeaponCollection(DataTable table, Dao dao = null, string rc = null) : base(table, dao, rc) { }
		public WeaponCollection(Query<WeaponColumns, Weapon> q, Dao dao = null, string rc = null) : base(q, dao, rc) { }
		public WeaponCollection(Database db, Query<WeaponColumns, Weapon> q, bool load) : base(db, q, load) { }
		public WeaponCollection(Query<WeaponColumns, Weapon> q, bool load) : base(q, load) { }
    }
}