using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Distributed
{
    public interface IDistributedRepository
    {
        void Create(CreateOperation value);
        T Retrieve<T>(RetrieveOperation value);
        void Update(UpdateOperation value);
        void Delete(DeleteOperation value);
        IEnumerable<T> Query<T>(QueryOperation query);

		ReplicationResult RecieveReplica(Operation operation);
    }
}
