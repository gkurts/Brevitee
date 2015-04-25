using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee;
using Brevitee.Logging;
using Brevitee.Testing;
using Brevitee.Incubation;
using Brevitee.DaoRef;
using Brevitee.CommandLine;
using Brevitee.Data.MsSql;
using Brevitee.Data.SQLite;
using Brevitee.Data.Oracle;
using Brevitee.Testing.Integration;

namespace Brevitee.Data.Integration.Tests
{
	public static class Tools
	{
		/// <summary>
		/// Create a set of test databases
		/// </summary>
		/// <returns></returns>
		public static HashSet<Database> Setup()
		{
			HashSet<Database> testDatabases = new HashSet<Database>();
			MsSqlDatabase msDatabase = new MsSqlDatabase("192.168.0.59", "DaoRef", new MsSqlCredentials { UserName = "naizari", Password = "N41z4r1P455w0rd!" });
			SQLiteDatabase sqliteDatabase = new SQLiteDatabase(".\\DaoCrudTests", "DaoRef");
			OracleDatabase oracleDatabase = new OracleDatabase("chumsql1", "DaoRef", new OracleCredentials { UserId = "C##ORACLEUSER", Password = "oracleP455w0rd" });

			Db.TryEnsureSchema<TestTable>(msDatabase);
			testDatabases.Add(msDatabase);

			Db.TryEnsureSchema<TestTable>(sqliteDatabase);
			testDatabases.Add(sqliteDatabase);

			Db.TryEnsureSchema<TestTable>(oracleDatabase);
			testDatabases.Add(oracleDatabase);
			
			return testDatabases;
		}

		public static void Cleanup(HashSet<Database> testDatabases)
		{
			testDatabases.Each(db =>
			{
				SchemaWriter dropper = db.ServiceProvider.Get<SchemaWriter>();
				dropper.EnableDrop = true;
				dropper.DropAllTables<TestTable>();
				db.ExecuteSql(dropper);
			});
		}
		public static TestTable CreateTestTable(string name, Database db)
		{
			return CreateTestTable(name, string.Empty, db);
		}

		public static TestTable CreateTestTable(string name, string description, Database db)
		{
			TestTable table = new TestTable();
			table.Name = name;
			table.Description = description;
			table.Save(db);
			return table;
		}

		public static Left CreateLeft(string name, Database db)
		{
			Left left = new Left();
			left.Name = name;
			left.Save(db);

			return left;
		}

		public static Right CreateRight(string name, Database db)
		{
			Right right = new Right();
			right.Name = name;
			right.Save(db);

			return right;
		}
	}
}
