using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Brevitee;
using Brevitee.Logging;
using Brevitee.Testing;
using Brevitee.Incubation;
using Brevitee.DaoRef;
using Brevitee.CommandLine;
using Brevitee.Data.MsSql;
using Brevitee.Data.SQLite;
using Brevitee.Testing.Integration;

namespace Brevitee.Data.Integration.Tests
{
	[IntegrationTestContainer]
	public class DaoQueryTests : CommandLineTestInterface
	{
		static HashSet<Database> _testDatabases;
		public DaoQueryTests()
		{
		}

		[IntegrationTestSetup]
		public void Setup()
		{
			_testDatabases = Tools.Setup();
		}

		[IntegrationTestCleanup]
		public void CleanUp()
		{
			Tools.Cleanup(_testDatabases);
		}

		[IntegrationTest]
		public void InQueryTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				List<TestTable> tables = new List<TestTable>();
				8.Times(i =>
				{
					tables.Add(Tools.CreateTestTable(4.RandomLetters(), db));
				});

				Expect.AreEqual(8, tables.Count);
				List<long> ids = new List<long>(tables.Select(t => t.Id.Value).ToArray());
				TestTableCollection retrieved = TestTable.Where(c => c.Id.In(ids.ToArray()), db);
				Expect.AreEqual(tables.Count, retrieved.Count);
			});
		}

		[IntegrationTest]
		public void TopQueryTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string startsWith = 8.RandomLetters();
			string methodName = MethodBase.GetCurrentMethod().Name;
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				8.Times(i =>
				{
					Tools.CreateTestTable("{0}_{1}"._Format(startsWith, 6.RandomLetters()), db);
				});

				3.Times(i =>
				{
					Tools.CreateTestTable(5.RandomLetters(), db);
				});

				TestTableCollection top4 = TestTable.Top(4, c => c.Name.StartsWith(startsWith), db);
				Expect.AreEqual(4, top4.Count);
			});
		}

		[IntegrationTest]
		public void EndsWithTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			string endsWith = 7.RandomLetters();
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				3.Times(i =>
				{
					Tools.CreateTestTable("{0}{1}"._Format(4.RandomLetters(), endsWith), db);
				});

				5.Times(i =>
				{
					Tools.CreateTestTable(11.RandomLetters(), db);
				});

				TestTableCollection endsWithResults = TestTable.Where(c => c.Name.EndsWith(endsWith), db);
				Expect.AreEqual(3, endsWithResults.Count);

				TestTableCollection doesntEndWithResults = TestTable.Where(c => c.Name.DoesntEndWith(endsWith), db);
				Expect.IsTrue(doesntEndWithResults.Count > 0);
				doesntEndWithResults.Each(endsWithResults.ToList(), (ewr, tt) =>
				{
					Expect.IsFalse(ewr.Contains(tt));
				});
			});
		}

		[IntegrationTest]
		public void StartsWithTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			string startsWith = 7.RandomLetters();
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				3.Times(i =>
				{
					Tools.CreateTestTable("{0}{1}"._Format(startsWith, 4.RandomLetters()), db);
				});

				5.Times(i =>
				{
					Tools.CreateTestTable(11.RandomLetters(), db);
				});

				TestTableCollection startsWithResults = TestTable.Where(c => c.Name.StartsWith(startsWith), db);
				Expect.AreEqual(3, startsWithResults.Count);

				TestTableCollection doesntEndWithResults = TestTable.Where(c => c.Name.DoesntStartWith(startsWith), db);
				Expect.IsTrue(doesntEndWithResults.Count > 0);
				doesntEndWithResults.Each(startsWithResults.ToList(), (swr, tt) =>
				{
					Expect.IsFalse(swr.Contains(tt));
				});
			});
		}

		[IntegrationTest]
		public void ContainsTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			string contains = 7.RandomLetters();
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				3.Times(i =>
				{
					Tools.CreateTestTable("{0}{1}{2}"._Format(4.RandomLetters(), contains, 4.RandomLetters()), db);
				});

				5.Times(i =>
				{
					Tools.CreateTestTable(11.RandomLetters(), db);
				});

				TestTableCollection containsResults = TestTable.Where(c => c.Name.Contains(contains), db);
				Expect.AreEqual(3, containsResults.Count);

				TestTableCollection doesntContainResults = TestTable.Where(c => c.Name.DoesntContain(contains), db);
				Expect.IsTrue(doesntContainResults.Count > 0);
				doesntContainResults.Each(containsResults.ToList(), (cr, tt) =>
				{
					Expect.IsFalse(cr.Contains(tt));
				});
			});
		}

		[IntegrationTest]
		public void AndTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			string nameStartsWith = 4.RandomLetters();
			string descriptionStartsWith = 4.RandomLetters();
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				TestTable one = Tools.CreateTestTable("{0}_{1}"._Format(nameStartsWith, 4.RandomLetters()), "{0}_{1}"._Format(descriptionStartsWith, 4.RandomLetters()), db);
				TestTable two = Tools.CreateTestTable("{0}_{1}"._Format(nameStartsWith, 4.RandomLetters()), "{0}_{1}"._Format(descriptionStartsWith, 4.RandomLetters()), db);
				TestTable three = Tools.CreateTestTable(nameStartsWith, db);

				TestTableCollection results = TestTable.Where(c => c.Name.StartsWith(nameStartsWith).And(c.Description.StartsWith(descriptionStartsWith)), db);
				TestTableCollection results2 = TestTable.Where(c => c.Name.StartsWith(nameStartsWith) && c.Description.StartsWith(descriptionStartsWith), db);
				Expect.AreEqual(2, results.Count);
				Expect.AreEqual(2, results2.Count);
			});
		}

		[IntegrationTest]
		public void OrTest()
		{
			Expect.IsTrue(_testDatabases.Count > 0);
			string methodName = MethodBase.GetCurrentMethod().Name;
			string one = 4.RandomLetters();
			string two = 4.RandomLetters();
			_testDatabases.Each(db =>
			{
				OutLineFormat("{0}.{1}: {2}", ConsoleColor.DarkYellow, this.GetType().Name, methodName, db.GetType().Name);
				TestTable first = Tools.CreateTestTable("{0}_{1}"._Format(one, 4.RandomLetters()), db);
				TestTable second = Tools.CreateTestTable("{0}_{1}"._Format(two, 4.RandomLetters()), db);
				TestTable third = Tools.CreateTestTable(8.RandomLetters(), db);

				TestTableCollection results = TestTable.Where(c => c.Name.StartsWith(one).Or(c.Name.StartsWith(two)), db);
				Expect.AreEqual(2, results.Count);
				List<TestTable> list = results.ToList();
				Expect.IsTrue(list.Contains(first));
				Expect.IsTrue(list.Contains(second));
				Expect.IsFalse(list.Contains(third));

				results = TestTable.Where(c => c.Name.StartsWith(one) || c.Name.StartsWith(two), db);
				Expect.AreEqual(2, results.Count);
				list = results.ToList();
				Expect.IsTrue(list.Contains(first));
				Expect.IsTrue(list.Contains(second));
				Expect.IsFalse(list.Contains(third));
			});
		}
	}
}
