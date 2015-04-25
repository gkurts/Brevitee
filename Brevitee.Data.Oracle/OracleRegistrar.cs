using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Incubation;
using System.Data.OracleClient;
using Brevitee.Data;
using Brevitee;
using System.Reflection;
using System.IO;

namespace Brevitee.Data
{
	public static class OracleRegistrar
    {
        public static void OutputAssemblyQualifiedName()
        {
            Console.WriteLine(OracleAssemblyQualifiedName());
        }

        public static string OracleAssemblyQualifiedName()
        {
            return OracleClientFactory.Instance.GetType().AssemblyQualifiedName;
        }

        /// <summary>
        /// Register the Oracle components with the ServiceProvider 
        /// of the specified database.  This Register method will
        /// not call SetInitializerAndConnectionStringResolver
        /// like the other Register methods do.
        /// </summary>
        /// <param name="database"></param>
        public static void Register(Database database)
        {
            Register(database.ServiceProvider);
        }

        /// <summary>
        /// Registers Oracle as the handler for the specified connection name.
        /// This dao handler will register apropriate DatabaseInitializer and
        /// ConnectionStringResolver.  This behavior is different compared to the
        /// SqlClientRegistrar's Register method.
        /// </summary>
        /// <param name="connectionName"></param>
        public static void Register(string connectionName)
        {
            Register(Db.For(connectionName).ServiceProvider);
        }

        public static void Register(Type daoType)
        {
            Register(Db.For(daoType).ServiceProvider);
        }

        public static void Register<T>() where T : Dao
        {
            Register(Db.For<T>().ServiceProvider);
        }

        public static void Register(Incubator incubator)
        {
            incubator.Set<IParameterBuilder>(() => new OracleParameterBuilder());
            incubator.Set<SqlStringBuilder>(() => new OracleSqlStringBuilder());
            incubator.Set<SchemaWriter>(() => new OracleSqlStringBuilder());
            incubator.Set<QuerySet>(() => new OracleQuerySet());
        }
    }
}
