using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Data;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace Brevitee.Data.MsSql
{
    public class MsSqlDatabaseInitializer: DefaultDatabaseInitializer
    {
        public MsSqlDatabaseInitializer()
        {
        }

        public MsSqlDatabaseInitializer(params string[] ignoreConnectionNames)
        {
            this.Ignore(ignoreConnectionNames);
        }

        public MsSqlDatabaseInitializer(params Type[] ignoreConnectionsForTypes)
        {
            this.Ignore(ignoreConnectionsForTypes);
        }

        public override Database GetDatabase(ConnectionStringSettings conn, DbProviderFactory factory)
        {
            Database db = base.GetDatabase(conn, factory);
            MsSqlRegistrar.Register(db.ServiceProvider);
            return db;
        }
    }
}
