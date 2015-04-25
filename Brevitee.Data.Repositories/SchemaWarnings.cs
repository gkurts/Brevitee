using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Schema;

namespace Brevitee.Data.Repositories
{
	public sealed class SchemaWarnings
	{
		public SchemaWarnings(KeyColumn[] missingKeyColumns, ForeignKeyColumn[] missingForeignKeyColumns) 
		{
			this.MissingKeyColumns = missingKeyColumns ?? new KeyColumn[] { };
			this.MissingForeignKeyColumns = missingForeignKeyColumns ?? new ForeignKeyColumn[] {};
		}

		public KeyColumn[] MissingKeyColumns { get; set; }
		public ForeignKeyColumn[] MissingForeignKeyColumns { get; set; }

	}
}
