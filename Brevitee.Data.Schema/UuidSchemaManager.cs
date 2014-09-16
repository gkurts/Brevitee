using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Schema
{
    /// <summary>
    /// A schema manager that will automatically add an Id
    /// and Uuid column to every table when generating a 
    /// schema and related Data Access Objects from a *.db.js
    /// file
    /// </summary>
    public class UuidSchemaManager: AutoIdSchemaManager
    {
        public UuidSchemaManager()
            : base()
        {
            this.PreColumnAugmentations.Add(new AddColumnAugmentation { ColumnName = "Uuid", DataType = DataTypes.String, AllowNull = false });
        }
    }
}
