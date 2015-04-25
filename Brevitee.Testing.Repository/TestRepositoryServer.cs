using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Javascript;
using Brevitee.ServiceProxy;
using Brevitee.Data.Repositories;
using Brevitee.Data;
using Brevitee.Configuration;
using Brevitee.Data.SQLite;
using Brevitee.Logging;
using Brevitee.CommandLine;
using Brevitee.Testing.Repository.Data;

namespace Brevitee.Testing.Repository
{
	[Proxy("testRepo", MethodCase = MethodCase.CamelCase)]
	public class TestRepositoryServer: Loggable, IRequiresHttpContext
	{
		DaoRepository _repository;
		public TestRepositoryServer()
		{
			string dataDirectory = DefaultConfiguration.GetAppSetting("TestResultsDataDirectory", "C:\\BreviteeContentRoot\\apps\\hugh\\data\\");
			Database db = new SQLiteDatabase(dataDirectory, "TestResults");
			_repository = new DaoRepository(db);
			_repository.SchemaWarning += (s, e) =>
			{
				Log.AddEntry("SchemaWarning: {0}", LogEventType.Warning, e.TryPropertiesToString());
			};
			_repository.CreateFailed += (s, e) =>
			{
				Log.AddEntry("CreateFailed: {0}", LogEventType.Error, e.TryPropertiesToString());
			};
			_repository.RetrieveFailed += (s, e) =>
			{
				Log.AddEntry("RetrieveFailed: {0}", LogEventType.Error, e.TryPropertiesToString());
			};
			_repository.UpdateFailed += (s, e) =>
			{
				Log.AddEntry("UpdateFailed: {0}", LogEventType.Error, e.TryPropertiesToString());
			};

			AddStorableTypes(_repository);
			this.Repository = _repository;
		}
		
		public string DataFile
		{
			get
			{
				DaoRepository repo = Repository as DaoRepository;
				if (repo != null)
				{
					SQLiteDatabase db = repo.Database as SQLiteDatabase;
					if (db != null)
					{
						return db.DatabaseFile.FullName;
					}
				}

				return string.Empty;
			}
		}

		public override void Subscribe(ILogger logger)
		{
			_repository.Subscribe(logger);
		}

		public override void Subscribe(Loggable loggable)
		{
			_repository.Subscribe(loggable);
		}

		/// <summary>
		/// Gets a suite matching the specified suite doing a cascading search for 
		/// the Uuid, Id or the Title, creating the suite if no match is found.
		/// </summary>
		/// <param name="suite"></param>
		/// <returns></returns>
		public DefineSuiteResponse GetSuiteDefinition(SuiteDefinition suite)
		{
			try
			{
				SuiteDefinition result = null;
				CreateStatus status = CreateStatus.Existing;
				if (!string.IsNullOrEmpty(suite.Uuid))
				{
					result = (SuiteDefinition)Repository.Retrieve(typeof(SuiteDefinition), suite.Uuid);//Query<SuiteDefinition>(Query.Where("Uuid") == suite.Uuid).FirstOrDefault();
				}
				if(result == null && suite.Id > 0)
				{
					result = Repository.Retrieve<SuiteDefinition>(suite.Id);
				}
				if (result == null)
				{
					result = Repository.Query<SuiteDefinition>(Query.Where("Title") == suite.Title).FirstOrDefault();
					if(result != null)
					{
						result = (SuiteDefinition)Repository.Retrieve(typeof(SuiteDefinition), result.Uuid);
					}
				}
				if (result == null)
				{
					DateTime now = DateTime.UtcNow;
					suite.Created = now;
					suite.Modified = now;
					result = Repository.Create<SuiteDefinition>(suite);
					status = CreateStatus.Created;
				}

				return new DefineSuiteResponse { Success = true, Status = status, Data = result };
			}
			catch (Exception ex)
			{
				return new DefineSuiteResponse { Success = false, Message = ex.Message };
			}
		}

		public UpdateSuiteResponse UpdateSuiteDefinition(SuiteDefinition suite)
		{
			try
			{
				suite = Repository.Update(suite);
				return new UpdateSuiteResponse { Success = true, Data = suite };
			}
			catch (Exception ex)
			{
				return new UpdateSuiteResponse { Success = false, Message = ex.Message };
			}
		}

		public DefineTestResponse GetTestDefinition(TestDefinition test)
		{
			try
			{
				TestDefinition result = null;
				CreateStatus status = CreateStatus.Existing;
				if (!string.IsNullOrEmpty(test.Uuid))
				{
					result = Repository.Query<TestDefinition>(Query.Where("Uuid") == test.Uuid).FirstOrDefault();
				}
				if (result == null && test.Id > 0)
				{
					result = Repository.Retrieve<TestDefinition>(test.Id);
				}
				if (result == null)
				{
					result = Repository.Query<TestDefinition>(Query.Where("Title") == test.Title).FirstOrDefault();
				}
				if (result == null)
				{
					DateTime now = DateTime.UtcNow;
					test.Created = now;
					test.Modified = now;
					result = Repository.Create<TestDefinition>(test);
					status = CreateStatus.Created;
				}

				return new DefineTestResponse { Success = true, Status = CreateStatus.Created, Data = result };
			}
			catch (Exception ex)
			{
				return new DefineTestResponse { Success = false, Message = ex.Message };
			}
		}

		public SaveTestExecutionResponse SaveTestExecution(TestExecution execution)
		{
			try
			{
				TestExecution exec = Repository.Save(execution);
				return new SaveTestExecutionResponse { Success = true, Data = exec };
			}
			catch (Exception ex)
			{
				return new SaveTestExecutionResponse { Success = false, Message = ex.Message };
			}
		}

		public SaveTestPassResponse SaveTestPass(TestPass testPass)
		{
			try
			{
				TestPass pass = Repository.Save(testPass);
				return new SaveTestPassResponse { Success = true, Data = pass };
			}
			catch (Exception ex)
			{
				return new SaveTestPassResponse { Success = false, Message = ex.Message };
			}
		}	

		public SaveTestFailureResponse SaveTestFailure(TestFailure failure)
		{
			try
			{
				TestFailure failed = Repository.Save(failure);
				return new SaveTestFailureResponse { Success = true, Data = failed };
			}
			catch (Exception ex)
			{
				return new SaveTestFailureResponse { Success = false, Message = ex.Message };
			}
		}

		public SaveTestSummaryResponse SaveTestSummary(TestSummary summary)
		{
			try
			{
				TestSummary sum = Repository.Save(summary);
				sum = Repository.Retrieve<TestSummary>(sum.Id);
				return new SaveTestSummaryResponse { Success = true, Data = sum };
			}
			catch (Exception ex)
			{
				return new SaveTestSummaryResponse { Success = false, Message = ex.Message };
			}

		}

		public RetrieveTestExecutionResponse RetrieveTestExecutionById(long id)
		{
			try
			{
				TestExecution retrieved = Repository.Retrieve<TestExecution>(id);
				return new RetrieveTestExecutionResponse { Success = true, Data = retrieved };
			}
			catch (Exception ex)
			{
				return new RetrieveTestExecutionResponse { Success = false, Message = ex.Message };
			}
		}

		public RetrieveTestExecutionResponse RetrieveTestExecutionByUuid(string uuid)
		{
			try
			{
				TestExecution queried = Repository.Query<TestExecution>(Query.Where("Uuid") == uuid).FirstOrDefault();
				if (queried == null)
				{
					Args.Throw<ArgumentException>("TestExecution with the specified Uuid was not found: {0}", uuid);
				}
				TestExecution retrieved = Repository.Retrieve<TestExecution>(queried.Id);
				return new RetrieveTestExecutionResponse { Success = true, Data = retrieved };
			}
			catch (Exception ex)
			{
				return new RetrieveTestExecutionResponse { Success = false, Message = ex.Message };
			}
		}

		protected internal DaoRepository Repository { get; set; }

		private static void AddStorableTypes(IRepository repository)
		{
			repository.AddNamespace(typeof(SuiteDefinition).Assembly, "Brevitee.Testing.Repository.Data");
			//repository.AddType<SuiteDefinition>();
			//repository.AddType<TestDefinition>();
			//repository.AddType<TestExecution>();
			//repository.AddType<TestFailure>();
			//repository.AddType<TestPass>();
			//repository.AddType<TestSummary>();			
		}

		#region IRequiresHttpContext Members

		public IHttpContext HttpContext
		{
			get;
			set;
		}

		#endregion
	}
}
