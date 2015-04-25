using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using Brevitee.Data.Oracle;

namespace Brevitee.Data.Oracle
{
	public interface IPLSqlStringBuilder
	{
		OracleParameter IdParameter { get; set; }
		bool ReturnsId { get; set; }
	}
}
