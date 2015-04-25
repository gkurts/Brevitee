using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Brevitee.Testing.Repository;
using Brevitee.CommandLine;
using Brevitee.Configuration;
using Brevitee.Logging;
using Brevitee.Testing.Repository.Data;

namespace Brevitee.Testing.Repository.Tests
{
	[Serializable]
	public class UnitTests: CommandLineTestInterface
	{
		[UnitTest]
		public void ShouldBeAbleToGetTestDbFilePath()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats = GetServer(mn);
			Expect.IsTrue(stats.DataFile.Contains(mn));
		}

		[UnitTest]
		public void ShouldBeAbleToGetSuiteDefinition()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats = GetServer(mn);
			SuiteDefinition definition = new SuiteDefinition();
			string title = "Suite - {0}:"._Format(mn).RandomLetters(6) ;
			definition.Title = title;
			DefineSuiteResponse response = stats.GetSuiteDefinition(definition);
			Expect.IsTrue(response.Success, response.Message);
			Expect.AreEqual(response.DataAs<SuiteDefinition>().Title, title);
			Expect.IsGreaterThan(response.DataAs<SuiteDefinition>().Id, 0, "Id should have been greater than zero but was {0}"._Format(response.DataAs<SuiteDefinition>().Id));
			Expect.IsFalse(string.IsNullOrEmpty(response.DataAs<SuiteDefinition>().Uuid), "Uuid was null or empty");
			OutLineFormat("Uuid: {0}, Id: {1}, Title: {2}", ConsoleColor.Cyan, response.DataAs<SuiteDefinition>().Uuid, response.DataAs<SuiteDefinition>().Id, response.DataAs<SuiteDefinition>().Title);
		}

		[UnitTest]
		public void ShouldSetTestDefinitions()
		{
			
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer server = GetServer(mn);
			SuiteDefinition suite = new SuiteDefinition();
			suite.TestDefinitions = new TestDefinition[] { new TestDefinition { Title = "".RandomLetters(4) } };
			Expect.IsTrue(suite.Id == 0);
			server.Repository.Save(suite);
			suite = (SuiteDefinition)server.Repository.Retrieve(typeof(SuiteDefinition), suite.Id);
			Expect.IsTrue(suite.Id > 0, "Id was less than 0");
			Expect.IsTrue(suite.TestDefinitions != null, "TestDefinitions property was null");
			Expect.IsTrue(suite.TestDefinitions.Length > 0, "TestDefinitions property had no values");
		}

		[UnitTest]
		public void ShouldBeAbleToUpdateSuite()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats = GetServer(mn);

			SuiteDefinition suite = new SuiteDefinition();
			suite.Title = "Suite - {0}:"._Format(mn).RandomLetters(6);

			DefineSuiteResponse suiteResponse = stats.GetSuiteDefinition(suite);
			Expect.IsTrue(suiteResponse.DataAs<SuiteDefinition>().TestDefinitions.Length == 0, "There should have been 0 test definitions");
			suite = suiteResponse.DataAs<SuiteDefinition>();

			TestDefinition testDefinition = new TestDefinition();
			testDefinition.Title = "Test - {0}:"._Format(mn).RandomLetters(6);

			suite.TestDefinitions = new TestDefinition[] { testDefinition };
			
			UpdateSuiteResponse testResponse = stats.UpdateSuiteDefinition(suite);

			Expect.IsTrue(testResponse.Success, testResponse.Message);
			suiteResponse = stats.GetSuiteDefinition(suite);

			Expect.IsTrue(suiteResponse.DataAs<SuiteDefinition>().TestDefinitions.Length == 1, "There should have been 1 test definition");
		}

		[UnitTest]
		public void ShouldBeAbleToGetTestDefinition()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats = GetServer(mn);
			TestDefinition definition = new TestDefinition();
			string title = "Test - " + mn;
			definition.Title = title;
			DefineTestResponse response = stats.GetTestDefinition(definition);
			Expect.IsTrue(response.Success, response.Message);
			Expect.AreEqual(response.DataAs<TestDefinition>().Title, title);
			Expect.IsGreaterThan(response.DataAs<TestDefinition>().Id, 0, "Id should have been greater than zero but was {0}"._Format(response.DataAs<TestDefinition>().Id));
			Expect.IsFalse(string.IsNullOrEmpty(response.DataAs<TestDefinition>().Uuid), "Uuid was null or empty");
			OutLineFormat("Uuid: {0}, Id: {1}, Title: {2}", ConsoleColor.Cyan, response.DataAs<TestDefinition>().Uuid, response.DataAs<TestDefinition>().Id, response.DataAs<TestDefinition>().Title);		
		}

		[UnitTest]
		public void ShouldBeAbleToSaveTestExecution()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats;
			TestExecution execution;
			PrepServerAndExecution(mn, out stats, out execution);
			string title = execution.TestDefinition.Title;

			TestExecution check = (TestExecution)stats.Repository.Retrieve(typeof(TestExecution), execution.Uuid);
			Expect.IsNotNull(check.TestDefinition, "TestDefinition was null");
			Expect.AreEqual(check.TestDefinition.Title, title);
			SaveTestExecutionResponse saveResponse = stats.SaveTestExecution(execution);
			Expect.IsTrue(saveResponse.Success, saveResponse.Message);

		}

		[UnitTest]
		public void ShouldBeAbleToSaveTestPass()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats;
			TestExecution execution;
			PrepServerAndExecution(mn, out stats, out execution);

			TestPass pass = new TestPass();
			pass.TestExecutionId = execution.Id;
			SaveTestPassResponse passResponse = stats.SaveTestPass(pass);
			Expect.IsTrue(passResponse.Success, passResponse.Message);
			Expect.IsNotNull(passResponse.DataAs<TestPass>().TestExecution, "TestExecution property was null");
		}

		[UnitTest]
		public void ShouldBeAbleToSaveTestFailure()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats;
			TestExecution execution;
			PrepServerAndExecution(mn, out stats, out execution);

			TestFailure failure = new TestFailure();
			failure.TestExecutionId = execution.Id;
			SaveTestFailureResponse failResponse = stats.SaveTestFailure(failure);
			Expect.IsTrue(failResponse.Success, failResponse.Message);
			Expect.IsNotNull(failResponse.DataAs<TestFailure>().TestExecution);
		}

		[UnitTest]
		public void ShouldBeAbleToSaveTestSummary()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats;
			TestExecution execution;
			PrepServerAndExecution(mn, out stats, out execution);

			TestSummary summary = GetTestExecutionSummary();
			summary.TestExecutionId = execution.Id;
			SaveTestSummaryResponse summaryResponse = stats.SaveTestSummary(summary);
			Expect.IsTrue(summaryResponse.Success, summaryResponse.Message);
			summary = summaryResponse.DataAs<TestSummary>();
			Expect.IsNotNull(summary.TestExecution, "TestExecution was null");
			Expect.IsNotNullOrEmpty(execution.TestDefinition.Title, "Test definition title was blank or null");
			TestExecution fromSummary = stats.RetrieveTestExecutionById(summary.TestExecutionId).DataAs<TestExecution>();
			Expect.AreEqual(fromSummary.TestDefinition.Title, execution.TestDefinition.Title);
			Expect.IsTrue(summary.Id > 0, "Id wasn't set");
		}

		[UnitTest]
		public void ShouldBeAbleToRetrieveTestExecution()
		{
			string mn = MethodBase.GetCurrentMethod().Name;
			TestRepositoryServer stats;
			TestExecution execution;
			PrepServerAndExecution(mn, out stats, out execution);

			RetrieveTestExecutionResponse response = stats.RetrieveTestExecutionById(execution.Id);
			CheckExpectations(execution, response);
			response = stats.RetrieveTestExecutionByUuid(response.DataAs<TestExecution>().Uuid);
			CheckExpectations(execution, response);
		}

		private static void CheckExpectations(TestExecution execution, RetrieveTestExecutionResponse response)
		{
			Expect.IsTrue(response.Success, response.Message);
			Expect.IsNotNull(response.DataAs<TestExecution>(), "TestExecution was null");
			Expect.AreEqual(execution.Id, response.DataAs<TestExecution>().Id);
			Expect.IsTrue(execution.Id > 0, "Id was less than or equal to 0");
			Expect.IsNotNullOrEmpty(response.DataAs<TestExecution>().Uuid);
		}

		private TestRepositoryServer GetServer(string methodName)
		{
			DefaultConfiguration.SetAppSettings();
			InjectTestSettings(methodName);
			return new TestRepositoryServer();
		}

		private void InjectTestSettings(string methodName)
		{
			DirectoryInfo dir = new DirectoryInfo(Path.Combine(".", methodName));
			Dictionary<string, string> settings = new Dictionary<string,string>();
			settings.Add("TestResultsDataDirectory", dir.FullName);
			DefaultConfiguration.SetAppSettings(settings);
			ConsoleLogger logger = new ConsoleLogger();
			logger.StartLoggingThread();
			Log.Default = logger;
		}

		private static TestSummary GetTestExecutionSummary()
		{
			TestSummary summary = new TestSummary();
			summary.SuiteCount = 5;
			summary.TestCount = RandomNumber.Between(200, 350);
			int failedCount = RandomNumber.Between(1, summary.TestCount);
			int passedCount = summary.TestCount - failedCount;
			summary.PassedCount = passedCount;
			summary.FailedCount = failedCount;
			return summary;
		}

		private void PrepServerAndExecution(string mn, out TestRepositoryServer stats, out TestExecution exec)
		{
			stats = GetServer(mn);
			TestDefinition definition = new TestDefinition();
			string title = "Test - " + mn;
			definition.Title = title;
			DefineTestResponse response = stats.GetTestDefinition(definition);
			TestExecution execution = new TestExecution();
			execution.TestDefinitionId = response.DataAs<TestDefinition>().Id;
			stats.SaveTestExecution(execution);
			exec = stats.RetrieveTestExecutionById(execution.Id).DataAs<TestExecution>();
		}
	}
}
