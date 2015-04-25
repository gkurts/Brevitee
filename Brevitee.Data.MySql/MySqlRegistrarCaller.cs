using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Incubation;

namespace Brevitee.Data
{
    public class MySqlRegistrarCaller: IRegistrarCaller
    {
        public void Register(Database database)
        {
            MySqlRegistrar.Register(database);
        }

        public void Register(string connectionName)
        {
            MySqlRegistrar.Register(connectionName);
        }

        public void Register(Type daoType)
        {
            MySqlRegistrar.Register(daoType);
        }

        public void Register<T>() where T : Dao
        {
            MySqlRegistrar.Register<T>();
        }

        public void Register(Incubator incubator)
        {
            MySqlRegistrar.Register(incubator);
        }
    }
}
