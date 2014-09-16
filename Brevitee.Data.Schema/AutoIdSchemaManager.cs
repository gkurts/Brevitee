using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Schema
{
    /// <summary>
    /// A schema manager that will automatically add a
    /// Uuid column to every table when generating a 
    /// schema and related Data Access Objects from a *.db.js
    /// file
    /// </summary>
    public class AutoIdSchemaManager: SchemaManager
    {
        public AutoIdSchemaManager():base()
        {
            this.PreColumnAugmentations.Add(new AddIdKeyColumnAugmentation());            
        }
    }
}
