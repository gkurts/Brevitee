using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.Data;
using System.Data.Common;
using Brevitee.Incubation;
using System.Data.OracleClient;

namespace Brevitee.Data
{
	public class OracleParameterBuilder : ParameterBuilder
    {
        public override DbParameter BuildParameter(IParameterInfo c)
        {
            string parameterName = string.Format("{0}{1}", c.ColumnName, c.Number);
            OracleParameter result = new OracleParameter(parameterName, c.Value);
            
            return result;
        }

    }
}
