using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Repositories;
using Brevitee.Data;
using Brevitee;

namespace Brevitee.Distributed
{
	public class DistributedObjectReaderWriter: ObjectReaderWriter
	{
		public DistributedObjectReaderWriter(string rootDirectory)
			: base(rootDirectory)
		{ }
	}
}
