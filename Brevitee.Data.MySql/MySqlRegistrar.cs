using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Incubation;
using Brevitee;
using Brevitee.Data;

namespace Brevitee.Data
{
    public static class MySqlRegistrar
    {
        static MySqlRegistrar()
        {
            
        }

        /// <summary>
		/// Register the MySql implementation of IParameterBuilder, SchemaWriter and QuerySet for the 
        /// database associated with the specified connectionName.
        /// </summary>
        public static void Register(string connectionName)
        {
            Register(Db.For(connectionName).ServiceProvider);
        }

        /// <summary>
		/// Register the MySql implementation of IParameterBuilder, SchemaWriter and QuerySet for the 
        /// database associated with the specified type.
        /// </summary>
        public static void Register(Type daoType)
        {
            Register(Db.For(daoType).ServiceProvider);
        }

        /// <summary>
		/// Register the MySql implementation of IParameterBuilder, SchemaWriter and QuerySet for the 
        /// database associated with the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>() where T: Dao
        {
            Register(Db.For<T>().ServiceProvider);
        }

        public static void Register(Database database)
        {
            Register(database.ServiceProvider);
        }

        /// <summary>
        /// Registser the MySql implementation of IParameterBuilder, SchemaWriter and QuerySet  
        /// into the specified incubator
        /// </summary>
        /// <param name="incubator"></param>
        public static void Register(Incubator incubator)
        {
            MySqlParameterBuilder b = new MySqlParameterBuilder();
            incubator.Set<IParameterBuilder>(b);

			incubator.Set<SqlStringBuilder>(() => new MySqlSqlStringBuilder());
            incubator.Set<SchemaWriter>(() => new MySqlSqlStringBuilder());
            incubator.Set<QuerySet>(() => new MySqlQuerySet());
        }
    }
}
