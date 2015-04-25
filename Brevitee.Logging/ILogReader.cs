using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Logging
{
	public interface ILogReader
	{
		ILogger Logger { get; set; }
		List<LogEntry> GetLogEntries(DateTime from, DateTime to);
	}
}
