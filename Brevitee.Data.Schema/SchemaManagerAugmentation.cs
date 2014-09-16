using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Schema
{
    /// <summary>
    /// Augments the behavior of a SchemaManager.
    /// </summary>
    public abstract class SchemaManagerAugmentation
    {
        public abstract void Execute(string tableName, SchemaManager manager);
    }
}
