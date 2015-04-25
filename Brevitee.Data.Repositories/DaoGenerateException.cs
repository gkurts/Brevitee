using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	public class DaoGenerateException: Exception
	{
		public DaoGenerateException(string schemaName, Type[] types) : base(GetMessage(schemaName, types)) { }

		private static string GetMessage(string schemaName, Type[] types)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("Unable to Generate Dao Assembly for {0}.\r\nSpecified Types:\r\n", schemaName);
			foreach(Type type in types)
			{
				builder.AppendFormat("\t{0}\r\n", type.FullName);
			}

			return builder.ToString();
		}
	}
}
