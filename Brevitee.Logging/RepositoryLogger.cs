using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Repositories;

namespace Brevitee.Logging
{
	public class RepositoryLogger: Logger
	{
		public RepositoryLogger(IRepository repository)
		{
			this.Repository = repository;
		}

		public IRepository Repository { get; set; }
		public override void CommitLogEvent(LogEvent logEvent)
		{
			Repository.Create(logEvent);
		}
	}
}
