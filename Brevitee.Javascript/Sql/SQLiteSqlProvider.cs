using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data;
using Brevitee.Data.SQLite;
using Brevitee.Configuration;

namespace Brevitee.Javascript.Sql
{
	public class SQLiteSqlProvider: SqlProvider
	{
		public SQLiteSqlProvider() { }

		public string SQLiteDirectoryPath { get; set; }
		public string SQLiteFileName { get; set; }

		protected override void Initialize()
		{
			this.Database = new SQLiteDatabase(SQLiteDirectoryPath, SQLiteFileName);
		}

		public override void Configure(IConfigurer configurer)
		{
			configurer.Configure(this);
			this.CheckRequiredProperties();
		}

		public override void Configure(object configuration)
		{
			this.CopyProperties(configuration);
			this.CheckRequiredProperties();
		}

		public override string[] RequiredProperties
		{
			get { return new string[] { "SQLiteDirectoryPath", "SQLiteFileName" }; }
		}
	}
}
