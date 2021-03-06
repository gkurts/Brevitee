using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.CommandLine;
using Brevitee;
using Brevitee.Testing;
using Brevitee.Encryption;
using Brevitee.Data.Repositories;
using Brevitee.Data.Schema;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using Brevitee.Data;
using Brevitee.Data.SQLite;

namespace Brevitee.Data.Repositories.Tests
{
	#region test Dtos
	[Serializable]
	public class TestParent
	{
		public long Id { get; set; }
		public TestChild[] Childs { get; set; }
	}
	[Serializable]
	public class TestChild
	{
		// missing foreign key to parent
		public string Uuid { get; set; }
	}

	[Serializable]
	public class Parent
	{
		public long Id { get; set; }
		public string Uuid { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public virtual House[] Houses { get; set; } // many to many
		public virtual Daughter[] Daughters { get; set; } //one to many
		public virtual Son[] Sons { get; set; }
	}
	[Serializable]
	public class Daughter
	{
		public long Id { get; set; }
		public string Uuid { get; set; }
		public string Name { get; set; }
	}
	[Serializable]
	public class Son
	{
		public long Id { get; set; }
		public string Uuid { get; set; }
		public string Name { get; set; }

		public long ParentId { get; set; }
		public virtual Parent Parent { get; set; }
	}

	[Serializable]
	public class House
	{
		public long Id { get; set; }
		public string Uuid { get; set; }
		public string Name { get; set; }
		public virtual List<Parent> Parents { get; set; } // many to many
	}

	[Serializable]
	public class TestContainer
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public DateTime BirthDay { get; set; }
		public virtual Parent[] Parents { get; set; }
	}
	#endregion

    [Serializable]
    public class DaoRepositoryUnitTests : CommandLineTestInterface
	{

		[UnitTest]
		public void RetrieveShouldSetParentOnChildren()
		{
			DaoRepository repo = GetTestDaoRepository();
			repo.EnsureDaoAssembly();
			Parent parent = new Parent();
			parent.Name = "Test parent";
			Son one = new Son();
			one.Name = "Son";
			parent.Sons = new Son[] { one };
			parent = repo.Save(parent);
			Son checkSon = repo.Retrieve<Son>(parent.Sons[0].Id);			
			Expect.AreEqual(one.Name, checkSon.Name);
			Expect.AreEqual(parent.Id, checkSon.Parent.Id);
			Expect.AreEqual(parent.Name, checkSon.Parent.Name);
		}

		[UnitTest]
		public void ParentSaveShouldSaveChildren()
		{
			DaoRepository repo = GetTestDaoRepository();
			repo.EnsureDaoAssembly();
			Parent parent = new Parent();
			parent.Name = "Parent Name";
			Son sonOne = new Son();
			Son sonTwo = new Son();
			parent.Sons = new Son[] { sonOne, sonTwo };

			parent = repo.Save(parent);
			Parent retrieved = repo.Retrieve<Parent>(parent.Id);
			Expect.AreEqual(2, retrieved.Sons.Length);
		}

		[UnitTest]
		public void SavingParentShouldSaveChildLists()
		{
			DaoRepository repo = GetTestDaoRepository();
			repo.EnsureDaoAssembly();
			House house = new House { Name = "TestHouse", Parents = new List<Parent> { new Parent { Name = "TestParent" } } };
			repo.Save(house);

			House retrieved = repo.Retrieve<House>(house.Id);
			Expect.AreEqual(1, retrieved.Parents.Count);
		}

		[UnitTest]
		public void SavingParentXrefShouldSetChildXref()
		{
			DaoRepository repo = GetTestDaoRepository();
			repo.EnsureDaoAssembly();
			House house = new House { Name = "TestHouse", Parents = new List<Parent> { new Parent { Name = "TestParent" } } };
			repo.Save(house);

			House retrieved = repo.Retrieve<House>(house.Id);
			Parent parent = repo.Retrieve<Parent>(retrieved.Parents[0].Id);
			Expect.AreEqual(1, parent.Houses.Length);
		}

		[UnitTest]
		public void RepoShouldBeQueryable()
		{
			DaoRepository repo = GetTestDaoRepository();
			repo.EnsureDaoAssembly();
			
			House one = new House { Name = "Get This One" };
			House two = new House { Name = "Get This Too" };
			House three = new House { Name = "Not this one" };
			repo.Save(one);
			repo.Save(three);
			repo.Save(two);

			House[] houses = repo.Query<House>(Query.Where("Name").StartsWith("Get")).ToArray();
			Expect.AreEqual(2, houses.Length);
			houses.Each(house =>
			{
				repo.Delete(house);
			});
			repo.Delete(three);
		}

		[UnitTest]
		public void ShouldHaveEnumerableOfMe()
		{
			Expect.IsTrue(typeof(House).HasEnumerableOfMe(typeof(Parent)), "House didn't have enumerable of Parent");
			Expect.IsTrue(typeof(Parent).HasEnumerableOfMe(typeof(House)), "Parent didn't have enumerable of House");
		}

	    [UnitTest]
	    public void GetTableTypesShouldGetAllAppropriateTypes() 
		{
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
		    HashSet<Type> types = generator.GetTableTypes(typeof(TestContainer));
			Expect.IsTrue(types.Contains(typeof(Parent)));
			Expect.IsTrue(types.Contains(typeof(Daughter)));
			Expect.IsTrue(types.Contains(typeof(Son)));
			Expect.IsTrue(types.Contains(typeof(House)));
	    }

        [UnitTest]
        public void ShouldGetFksForDto()
        {
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
			List<Type> oneToManyTypes = generator.GetForeignKeyTypes(typeof(Parent)).ToList().Select(fk=>fk.ForeignKeyType).ToList();
			Expect.AreEqual(2, oneToManyTypes.Count);
			Expect.IsTrue(oneToManyTypes.Contains(typeof(Daughter)));
			Expect.IsTrue(oneToManyTypes.Contains(typeof(Son)));
        }

		[UnitTest]
		public void ShouldGetXrefsForDto()
		{
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
			List<TypeXref> xrefTypes = generator.GetXrefTypes(typeof(Parent)).ToList();
			Expect.AreEqual(1, xrefTypes.Count);
			Expect.AreEqual(typeof(Parent), xrefTypes[0].Left);
			Expect.AreEqual(typeof(House), xrefTypes[0].Right);
			Expect.IsTrue(xrefTypes[0].LeftCollectionProperty.IsEnumerable());
			OutLineFormat("{0}", ConsoleColor.DarkCyan, xrefTypes[0].LeftCollectionProperty.PropertyType.FullName);
		}

		[UnitTest]
		public void ShouldBeAbleToRenderPocoTemplate()
		{
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
			TypeSchema typeSchema = generator.CreateTypeSchema(typeof(TestContainer));
			PocoModel dtoModel = new PocoModel(typeof(TestContainer), typeSchema);
			string output = dtoModel.Render();
			OutLine(output, ConsoleColor.Cyan);
		}

		[UnitTest]
		public void GenerateDaoForDtosShouldSucceedWithoutErrors()
		{
			ConsoleLogger logger= new ConsoleLogger();
			logger.StartLoggingThread();
			TypeDaoGenerator generator = new TypeDaoGenerator();
			generator.AddType(typeof(TestContainer));
			generator.Subscribe(logger);

			CompilerResults result = generator.GenerateAndCompile("TestAssemblyName", ".\\{0}"._Format(MethodBase.GetCurrentMethod().Name));
			if (result.Errors.Count > 0)
			{
				foreach(CompilerError err in result.Errors)
				{
					OutLineFormat("File: {0}, ErrorNumber: {1}, Line: {2}, Column: {3}, Text: {4}", ConsoleColor.Red, err.FileName, err.ErrorNumber, err.Line, err.Column, err.ErrorText);
				}
			}
			Expect.IsTrue(result.Errors.Count == 0, "There were errors in compilation");
			FileInfo assembly = new FileInfo(result.PathToAssembly);
			OutLineFormat("Assembly is at : {0}", assembly.FullName);
		}

		[UnitTest]
		public void ShouldBeAbleToGenerateSchema()
		{
			TypeDaoGenerator generator = new TypeDaoGenerator();
			generator.AddType(typeof(TestContainer));
			SchemaDefinition schema = generator.CreateSchemaDefinition().SchemaDefinition;
			OutLineFormat("Schema {0} created successfully", ConsoleColor.Green, schema.Name);
		}

		[UnitTest]
		public void GetDaoAssemblyShouldGetTheSameOneEachTime()
		{
			TypeDaoGenerator generator = new TypeDaoGenerator();
			generator.AddType(typeof(TestContainer));
			Assembly first = generator.GetDaoAssembly();
			Assembly again = generator.GetDaoAssembly();
			Assembly andAgain = generator.GetDaoAssembly();
			Assembly oneMoreForGoodMeasure = generator.GetDaoAssembly();

			Expect.AreSame(first, again);
			Expect.AreSame(first, andAgain);
			Expect.AreSame(first, oneMoreForGoodMeasure);
		}

		[UnitTest]
		public void DaoRepositoryCreateShouldSetId()
		{
			DaoRepository repo = GetTestDaoRepository();
			TestContainer toCreate = new TestContainer();
			Expect.AreEqual(0, toCreate.Id);
			string testName = "Test Name".RandomLetters(5);
			toCreate.Name = testName;
			toCreate.BirthDay = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
			toCreate = repo.Create(toCreate);
			Expect.IsGreaterThan(toCreate.Id, 0);
			OutLineFormat("{0} passed", ConsoleColor.Green, repo.GetType().Name);
		}

		[UnitTest]
		public void RepositoryRetrieveByIdTest()
		{
			DaoRepository repo = GetTestDaoRepository();
			TestContainer toCreate = new TestContainer();
			Expect.AreEqual(0, toCreate.Id);
			string testName = "Test Name".RandomLetters(5);
			toCreate.Name = testName;
			toCreate.BirthDay = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
			toCreate = repo.Create(toCreate);
			TestContainer retrieved = repo.Retrieve<TestContainer>(toCreate.Id);
			Expect.IsNotNull(retrieved);
			Expect.AreEqual(toCreate.Name, retrieved.Name);
			Expect.AreEqual(toCreate.BirthDay, retrieved.BirthDay);
			Expect.AreEqual(toCreate.Id, retrieved.Id);
		}

		[UnitTest]
		public void RepositoryUpdateShouldSetNewPropertyValues()
		{
			DaoRepository repo = GetTestDaoRepository();
			TestContainer toCreate = new TestContainer();
			string testName = "Test Name".RandomLetters(5);
			toCreate.Name = testName;
			toCreate.BirthDay = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
			toCreate = repo.Create(toCreate);
			TestContainer toUpdate = repo.Retrieve<TestContainer>(toCreate.Id);
			string newName = "New Name".RandomLetters(8);
			toUpdate.Name = newName;
			DateTime newBirthDay = DateTime.Now.Subtract(new TimeSpan(14,0,0,0));
			toUpdate.BirthDay = newBirthDay;
			toUpdate = repo.Update(toUpdate);
			TestContainer check = repo.Retrieve<TestContainer>(toCreate.Id);
			Expect.AreEqual(newName, check.Name);
			Expect.AreEqual(newBirthDay, check.BirthDay);
			Expect.AreEqual(toCreate.Id, check.Id);
		}

		[UnitTest]
		public void RepositoryDeleteShouldDelete()
		{
			DaoRepository repo = GetTestDaoRepository();
			TestContainer toDelete = new TestContainer();
			string testName = "Test Name".RandomLetters(5);
			toDelete.Name = testName;
			toDelete.BirthDay = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
			toDelete = repo.Create(toDelete);
			Expect.IsTrue(repo.Delete<TestContainer>(toDelete));
			TestContainer check = repo.Retrieve<TestContainer>(toDelete.Id);
			Expect.IsNull(check);
		}
		
		[UnitTest]
		public void SchemaGeneratorShouldWarnAboutMissingForeignKey()
		{
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
			SchemaDefinitionCreateResult result = generator.CreateSchemaDefinition(new Type[] { typeof(TestParent) });
			Expect.IsTrue(result.MissingColumns);
			Expect.AreEqual(1, result.Warnings.MissingForeignKeyColumns.Length);
		}

		public class NoId
		{
			public string Name { get; set; }
			public TestChild[] Children { get; set; }
		}

		[UnitTest]
		public void SchemaGeneratorShouldWarnAboutMissingKeysIfHasForeignKey()
		{
			TypeSchemaGenerator generator = new TypeSchemaGenerator();
			SchemaDefinitionCreateResult result = generator.CreateSchemaDefinition(new Type[] { typeof(NoId) });
			Expect.IsTrue(result.MissingColumns);
			Expect.AreEqual(1, result.Warnings.MissingKeyColumns.Length);
		}

		[UnitTest]
		public void ShouldBeAbleToReflectOverGeneratedDaoAssembly()
		{
			DaoRepository daoRepo = GetTestDaoRepository();
			Assembly daoAssembly = daoRepo.EnsureDaoAssembly();
			Type[] types = daoAssembly.GetTypes();
			foreach(Type type in types)
			{
				OutLineFormat("{0}", type.FullName);
			}

			Type daoType = daoAssembly.GetType("TypeDaos.TestContainerDao");

			Expect.IsNotNull(daoType);
		}


		protected static DaoRepository GetTestDaoRepository()
		{
			DaoRepository daoRepo = new DaoRepository();
			daoRepo.WarningsAsErrors = false;
			daoRepo.Database = new SQLiteDatabase(".\\", "UNITTESTS");
			daoRepo.AddType(typeof(TestContainer));
			return daoRepo;
		}

		protected static MongoRepository GetMongoRepository()
		{
			return new MongoRepository();
		}
    }
}
