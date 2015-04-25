using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.CommandLine;
using Brevitee;
using Brevitee.Testing;
using Brevitee.Data;
using Brevitee.Data.SQLite;
using Brevitee.Encryption;
using Brevitee.Stickerize.Business.Data;
using Brevitee.Stickerize.Business;
using Brevitee.UserAccounts.Data;
using Brevitee.UserAccounts;
using System.IO;
using System.Web.WebPages.Deployment;
using System.Reflection;

namespace Brevitee.Stickerize.Data.Tests
{
    [Serializable]
    public class ConsoleActions: CommandLineTestInterface
    {
		static ConsoleActions()
		{
			InitSchemas();
			IsolateMethodCalls = false;
			_database = Db.For<Sticker>();
		}

		static Database _database;

		[ConsoleAction("Show connection string")]
		public void ShowConnectionString()
		{
			if (_database == null)
			{
				InitSchemas();
				_database = Db.For<Sticker>();
			}

			OutLine(_database.ConnectionString);
		}

		[ConsoleAction("Set database path")]
		public void SetDatabasePath()
		{
			string directory = Prompt("Please enter the full directory where the sqlite database is");
			string fileName = Prompt("Please enter the name of the database file");
			if (fileName.ToLowerInvariant().EndsWith(".sqlite"))
			{
				fileName = fileName.Truncate(7);
			}
			_database = new SQLiteDatabase(directory, fileName);
		}

        [ConsoleAction()]
        public void ShowSchemaInitializerJson()
        {
            SchemaInitializer initializer = new SchemaInitializer(typeof(StickerizeContext), typeof(SQLiteRegistrarCaller));
            string fileName = ".\\stickerizeSchemaInitializer.json";
            initializer.ToJson(true).SafeWriteToFile(fileName, true);
            "notepad {0}"._Format(fileName).Run();
        }

        [ConsoleAction()]
        public void ShowAppInitializerAssemblyQualifiedName()
        {
            string fileName = ".\\StickerizeInitializer.txt";
            
            typeof(StickerizeIntializer).AssemblyQualifiedName.SafeWriteToFile(fileName, true);
            "notepad {0}"._Format(fileName).Run();
        }

        [ConsoleAction()]
        public void LoadFileAndGetType()
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\BreviteeContentRoot\apps\stickerize.me\services\Brevitee.Stickerize.Services.dll");
            Type type = assembly.GetType(@"Brevitee.Stickerize.Services.Data.StickerizeContext");
            Expect.IsNotNull(type);
            OutLine(type.AssemblyQualifiedName);
        }

        [ConsoleAction()]
        public void LoadFileAndListTypes()
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\BreviteeContentRoot\apps\stickerize.me\services\Brevitee.Stickerize.Services.dll");
            assembly.GetTypes().Each(type =>
            {
                OutLine(type.AssemblyQualifiedName);
            });
        }

        [ConsoleAction("List Stickerizers")]
        public StickerizerCollection ListStickerizers()
        {
            InitSchemas();
            StickerizerCollection all = Stickerizer.Where(c => c.Name != null, _database);
            all.Each((er, i) =>
            {
                OutLineFormat("{0}. {1}", ConsoleColor.Cyan, i + 1, er.Name);
            });
            return all;
        }

        [ConsoleAction("Add stickerizer")]
        public void AddStickerizer()
        {
            InitSchemas();
            string userName = Prompt("Enter the name of the stickerizer to create");
            Stickerizer.Create(userName, _database);
        }

        [ConsoleAction("List Stickerizees")]
        public void ListStickerizees()
        {
            InitSchemas();
            StickerizeeCollection ees = Stickerizee.LoadAll(_database);
            ees.Each(e =>
            {
                OutLine(e.Name);
            });
        }

        [ConsoleAction("Search Stickerizee")]
        public void SearchStickerizees()
        {
            InitSchemas();
            string startsWith = Prompt("Starting with");
            StickerizeeCollection ees = Stickerizee.Where(c => c.Name.StartsWith(startsWith), _database);
            ees.Each(e =>
            {
                OutLine(e.Name);
            });
        }

        [ConsoleAction("List StickerizableLists")]
        public void ListStickerizableLists()
        {
            InitSchemas();
            string search = Prompt("Please enter the name of the list, blank to get top 1000");
            StickerizableListCollection listCollection = new StickerizableListCollection();
            if (!string.IsNullOrEmpty(search))
            {
                listCollection = StickerizableList.Top(1000, (c) => c.Name.Contains(search) || c.Name.StartsWith(search), _database);
            }
            else
            {
                listCollection = StickerizableList.Top(1000, (c) => c.Id != null, _database);
            }

            for (int i = 0; i < listCollection.Count; i++)
            {
                StickerizableList list = listCollection[i];
                OutFormat("{0}.{1}\r\n", ConsoleColor.Cyan, i + 1, list.Name);
            }
        }

        [ConsoleAction("Add StickerizableList")]
        public void AddStickerizableList()
        {
            InitSchemas();
            string name = Prompt("Enter the name of the list to add");
            if (string.IsNullOrEmpty(name))
            {
                OutFormat("Invalid name: {0}", ConsoleColor.Magenta, name);
            }
            else
            {
                StickerizableList.GetOrCreate(name, _database);
            }
        }

        [ConsoleAction("Delete List")]
        public void DeleteList()
        {
            InitSchemas();
            string name = Prompt("Enter the name of the list to delete");
            if (string.IsNullOrEmpty(name))
            {
                OutFormat("Invalid name: {0}", ConsoleColor.Magenta, name);
            }
            else
            {
                StickerizableList list = StickerizableList.OneWhere(c => c.Name == name, _database);
                if (list != null)
                {
                    list.Delete(_database);
                }
                else
                {
                    OutFormat("List not found", ConsoleColor.Yellow);
                }
            }
        }

        [ConsoleAction("Export database for migration")]
        public void ExportDatabase()
        {
			string basePath = Prompt("Enter the root directory to save to");
			DirectoryInfo baseDirectory = new DirectoryInfo(basePath);
			if (!baseDirectory.Exists)
			{
				baseDirectory.Create();
			}

            //	get all stickerizers and save to Stickerizers/<Uuid>
			DirectoryInfo stickerizersDirectory = new DirectoryInfo(Path.Combine(baseDirectory.FullName, "Stickerizers"));
			StickerizerCollection allStickerizers = Stickerizer.LoadAll();
			allStickerizers.Each(stickerizer =>
			{			
				stickerizer.ToJsonFile(Path.Combine(stickerizersDirectory.FullName, stickerizer.Uuid));
				// for each stickerizer 
				//		create a folder <Stickerizer.Uuid>_Stickerizees
				string stickerizeesFolderName = string.Format("{0}_Stickerizees", stickerizer.Uuid);
				DirectoryInfo stickerizeeDirectory = new DirectoryInfo(Path.Combine(basePath, stickerizeesFolderName));
				if(!stickerizeeDirectory.Exists)
				{
					stickerizeeDirectory.Create();
				}
				// for each stickerizee for current stickerizer save them into <Stickerizer.Uuid>_Stickerizees/Stickerizee.Uuid
				stickerizer.Stickerizees.Each(stickerizee =>
				{
					stickerizee.ToJsonFile(Path.Combine(stickerizeeDirectory.FullName, stickerizee.Uuid));
				});				
			});
			// -- end get all stickerizers and save to Stickerizers/<Uuid>

			//	for each stickerization create a folder Stickerizations
			DirectoryInfo stickerizationDirectory = new DirectoryInfo(Path.Combine(baseDirectory.FullName, "Stickerizations"));
			StickerizationCollection stickerizations = Stickerization.LoadAll();
			foreach (Stickerization stickerization in stickerizations)
			{
				stickerization.ToJsonFile(Path.Combine(stickerizationDirectory.FullName, stickerization.Uuid));
			}
			//		Filename: Stickerization.Uuid => save a representation of them using Uuid instead of Id of Stickerizer and Stickerizee Sticker
			//	create a folder StickerizableLists
			DirectoryInfo stickerizableLists = new DirectoryInfo(Path.Combine(baseDirectory.FullName, "StickerizableLists"));
			//	for each StickerizableList 
			StickerizableListCollection lists = StickerizableList.LoadAll();
			//		save file Uuid => CreatorId: Stickerizer.Uuid, ...the rest
			foreach (StickerizableList list in lists)
			{
				throw new NotImplementedException("This process is not complete");
			}
        }

        public static void InitSchemas()
        {
            SQLiteRegistrar.Register<Stickerizee>();
            SQLiteRegistrar.Register<User>();

            Db.TryEnsureSchema<Stickerizee>();
            Db.TryEnsureSchema<User>();
        }
    }
}
