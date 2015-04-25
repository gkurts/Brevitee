using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Logging
{
	public abstract class DaoLoggerLogReaderBase : ILogReader
	{

		public ILogger Logger
		{
			get;
			set;
		}

		public IDaoLogger DaoLogger
		{
			get
			{
				return (IDaoLogger)Logger;
			}
		}

		public abstract List<LogEntry> GetLogEntries(DateTime from, DateTime to);
	}
}
