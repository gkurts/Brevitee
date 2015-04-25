using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Data;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace Brevitee.Data
{
    public class OracleDatabaseInitializer: DefaultDatabaseInitializer
    {
        public OracleDatabaseInitializer()
        {
        }

        public OracleDatabaseInitializer(params string[] ignoreConnectionNames)
        {
            this.Ignore(ignoreConnectionNames);
        }

        public OracleDatabaseInitializer(params Type[] ignoreConnectionsForTypes)
        {
            this.Ignore(ignoreConnectionsForTypes);
        }

        public override Database GetDatabase(ConnectionStringSettings conn, DbProviderFactory factory)
        {
            Database db = base.GetDatabase(conn, factory);
            OracleRegistrar.Register(db.ServiceProvider);
            return db;
        }
    }
}
