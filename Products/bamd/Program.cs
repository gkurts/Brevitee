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
using Brevitee.Yaml;
using Brevitee.Testing;
using System.Reflection;
using Brevitee.UserAccounts;
using Brevitee.Data;

namespace Brevitee.Server
{
    [Serializable]
    class Program : CommandLineTestInterface
    {
        static void Main(string[] args)
        {
            EnsureAdminRights();
            // must match values in bams.exe
            ServiceExe.SetInfo(new ServiceInfo("BreviteeDaemon", "Brevitee Daemon", "Brevitee http application server"));
            ServiceExe.Kill(ServiceExe.Info.ServiceName);
            //
            IsolateMethodCalls = false;

			Type type = typeof(Program);
			AddSwitches(type);
			DefaultMethod = type.GetMethod("Interactive");

			Initialize(args);

			if (Arguments.Length > 0)
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
                
        [ConsoleAction("S", "Start default server")]
        public static void StartDefaultServer()
        {
            Server.Start();
			Pause("Default server started");
        }

        [ConsoleAction("K", "Stop (Kill) default server")]
        public static void StopDefaultServer()
        {
            Server.Stop();
			_server = null;
			Pause("Default server stopped");
        }

        [ConsoleAction("R", "Restart default server")]
        public static void RestartDefaultServer()
        {
            Server.Stop();
            _server = null; // force reinitialization
            Server.Start();
			Pause("Default server re-started");
        }
    }
}
