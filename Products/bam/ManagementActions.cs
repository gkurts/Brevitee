using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Ionic.Zip;
using Brevitee.CommandLine;
using Brevitee.Testing;
using Brevitee;
using Brevitee.Javascript;
using Brevitee.ServiceProxy;
using Brevitee.Server;
using Brevitee.Dust;
using Brevitee.Web;
using Brevitee.Data;
using Brevitee.Management;
using dotless.Core;

namespace bam
{
	[Serializable]
	public class ManagementActions : CommandLineTestInterface
	{
		[ConsoleAction("pt", "Pack toolkit")]
		public void PackToolkit()
		{
			string root;
			string saveTo;
			GetRootAndSaveTarget(out root, out saveTo);

			ContentManager contentMgr = new ContentManager();
			ZipFile toolkit = contentMgr.PackToolkit(root);
			toolkit.Save(saveTo);
		}

		[ConsoleAction("ps", "Pack Server")]
		public void PackServer()
		{
			throw new NotImplementedException();
		}

		[ConsoleAction("pa", "Pack application")]
		public void PackApp()
		{
			throw new NotImplementedException();
		}
		
		[ConsoleAction("ca", "Create application")]
		public void CreateApp()
		{
			BreviteeServer server = new BreviteeServer(BreviteeConf.Load(GetRoot()));
			ConsoleLogger logger = new ConsoleLogger();
			logger.AddDetails = false;
			logger.UseColors = true;
			server.Subscribe(logger);
			AppContentResponder app = server.CreateApp(GetArgument("appName"));
			app.Subscribe(logger);
			app.Initialize();
		}

		private static string GetArgument(string name)
		{
			string value = Arguments.Contains(name) ? Arguments[name] : Prompt("Please enter a value for {0}"._Format(name));
			return value;
		}

		private static string GetRoot()
		{
			string root;
			root = Arguments.Contains("root") ? Arguments["root"] : Prompt("Please enter the root directory path");
			return root;
		}

		private static void GetRootAndSaveTarget(out string root, out string saveTo)
		{
			root = GetRoot();
			saveTo = Arguments.Contains("saveTo") ? Arguments["saveTo"] : Prompt("Please enter the file name to save to");
			if (!saveTo.EndsWith(".zip"))
			{
				saveTo += ".zip";
			}
		}
	}
}
