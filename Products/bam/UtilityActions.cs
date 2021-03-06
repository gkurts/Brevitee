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
using System.Web;
using System.Net;
using CsQuery;
using dotless.Core;

namespace bam
{
	[Serializable]
	public class UtilityActions: CommandLineTestInterface
	{
		[ConsoleAction("get", "Download the specified url")]
		public void Get()
		{
			string url = string.Empty;
			if (!IsInteractive)
			{
				Arguments.EnsureArgumentValue("get");
				url = Arguments["get"];
			}
			else
			{
				url = Prompt("Enter the url to GET");
			}

			string html = Http.Get(url);
			string fileName = Path.GetFileName(url);
			CQ dollarSign = CQ.Create(html);
			Dictionary<string, string> css = new Dictionary<string, string>();
			Dictionary<string, byte[]> images = new Dictionary<string,byte[]>();
			OutLine("All css files: ");
			dollarSign["link[type=text/css]"].Each(o =>
			{
				string href = o.GetAttribute("href");
				OutLine(href, ConsoleColor.Cyan);
				if (!href.StartsWith("http://") && !href.StartsWith("https://"))
				{
					string cssUrl = "{0}{1}"._Format(url, href);
					string cssFileName = Path.GetFileName(href);
					OutLineFormat("Downloading: {0}", ConsoleColor.Yellow, cssUrl);
					css.Add(cssFileName, Http.Get(cssUrl));
				}
			});
			OutLine("All images: ");			

			DirectoryInfo saveTo = new DirectoryInfo(MethodBase.GetCurrentMethod().Name);
			if (!saveTo.Exists)
			{
				saveTo.Create();
			}

			FileInfo htmlFile = new FileInfo(Path.Combine(saveTo.FullName, fileName));
			html.SafeWriteToFile(htmlFile.FullName);
			foreach(string key in css.Keys)
			{
				FileInfo cssFile = new FileInfo(Path.Combine(saveTo.FullName, key));
				css[key].SafeWriteToFile(cssFile.FullName);
			}
		}

		[ConsoleAction("less", "Process .less files")]
		public void ProcessDotLessFiles()
		{
			string folder = Prompt("Enter the folder path containing .less files");
			DirectoryInfo dir = new DirectoryInfo(folder);
			FileInfo[] lessFiles = dir.GetFiles("*.less");
			lessFiles.Each(file =>
			{
				string fileName = Path.GetFileNameWithoutExtension(file.Name);
				string content = File.ReadAllText(file.FullName);
				string newFileName = Path.Combine(dir.FullName, string.Format("{0}.css", fileName));
				string css = Less.Parse(content);
				css.SafeWriteToFile(newFileName, true);
			});
		}
	}
}
