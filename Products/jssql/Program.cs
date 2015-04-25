using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Brevitee;
using Brevitee.CommandLine;
using Brevitee.Logging;
using Brevitee.Incubation;
using Brevitee.Configuration;
using System.IO;
using Brevitee.Testing;
using System.Reflection;
using Brevitee.Data;
using Brevitee.Javascript;
using Brevitee.Javascript.Sql;
using System.Collections.Specialized;

namespace Brevitee.Server
{
	[Serializable]
	class Program : CommandLineTestInterface
	{
		static void Main(string[] args)
		{
			IsolateMethodCalls = false;
			Directory.SetCurrentDirectory(Server.ContentRoot);

			Type type = typeof(Program);
			AddSwitches(type);
			AddConfigurationSwitches();
			AddValidArgument("i", true, "interactive");

			DefaultMethod = type.GetMethod("Interactive");

			ParseArgs(args); 

			SetSqlProvider();

			if (Arguments.Length > 0 && !Arguments.Contains("i"))
			{
				ExecuteSwitches(Arguments, type, null, null);
			}
			else
			{
				Interactive();
			}
		}

		static BreviteeServer _server;
		static object _serverLock = new object();
		public static BreviteeServer Server
		{
			get
			{
				return _serverLock.DoubleCheckLock(ref _server, () => new BreviteeServer(BreviteeConf.Load()));
			}
		}

		[ConsoleAction("S", "Start jssql server")]
		public static void StartDefaultServer()
		{
			Server.Start();
			Pause("jssql server started");
		}

		[ConsoleAction("K", "Stop (Kill) jssql server")]
		public static void StopDefaultServer()
		{
			Server.Stop();
			_server = null;
			Pause("jssql server stopped");
		}

		[ConsoleAction("R", "Restart jssql server")]
		public static void RestartDefaultServer()
		{
			Server.Stop();
			_server = null; // force reinitialization
			Server.Start();
			Pause("jssql server re-started");
		}

		private static void SetSqlProvider()
		{
			SqlProvider provider = (SqlProvider)Type.GetType(DefaultConfiguration.GetAppSetting("SqlProvider")).Construct();
			CommandLineArgumentConfigurer configurer = new CommandLineArgumentConfigurer(Arguments);
			configurer.Configure(provider);
			Server.AddCommonService<SqlProvider>(provider);
		}
	}
}
