using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Brevitee.Data.Schema;
using Brevitee.Incubation;
using Brevitee;
using Brevitee.Data;

namespace Brevitee.Data
{
    public class MsSqlSqlStringBuilder: SchemaWriter
    {
        public static void Register(Incubator incubator)
        {
            MsSqlSqlStringBuilder builder = new MsSqlSqlStringBuilder();
            incubator.Set(typeof(SqlStringBuilder), builder);
            incubator.Set<SqlStringBuilder>(builder);
        }

		public override string GetColumnDefinition(ColumnAttribute column)
		{
			string max = string.Format("({0})", column.MaxLength);
			string type = column.DbDataType.ToLowerInvariant();

			if (type.Equals("bigint") ||
				type.Equals("int") ||
				type.Equals("datetime") ||
				type.Equals("bit"))
			{
				max = string.Empty;
			}
			else if (type.Equals("decimal"))
			{
				max = string.Format("({0}, 2)", column.MaxLength);
			}

			return string.Format("\"{0}\" {1}{2}{3}", column.Name, column.DbDataType, max, column.AllowNull ? "" : " NOT NULL");
		}
    }
}
