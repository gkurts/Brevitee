using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data
{
	public class NullConnectionStringResolver: IConnectionStringResolver
	{
		public NullConnectionStringResolver() { }
		public NullConnectionStringResolver(Database database)
		{
			this.Database = database;
		}
		public Database Database { get; set; }
		#region IConnectionStringResolver Members

		public System.Configuration.ConnectionStringSettings Resolve(string connectionName)
		{
			string db = Database == null ? "null": Database.GetType().Name;
			throw new InvalidOperationException("No ConnectionStringResolver was specified: Database={0}, ConnectionName={1}"._Format(db, connectionName));
		}

		#endregion
	}
}
