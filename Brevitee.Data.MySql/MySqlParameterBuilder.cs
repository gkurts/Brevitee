using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using Brevitee.Incubation;
using Brevitee;
using Brevitee.Data;
using Brevitee.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Brevitee.Data
{
    public class MySqlParameterBuilder: ParameterBuilder
    {
        public override DbParameter BuildParameter(IParameterInfo c)
        {
            return new MySqlParameter(string.Format("@{0}{1}", c.ColumnName, c.Number), c.Value);
        }
    }
}
