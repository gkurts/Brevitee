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

namespace Brevitee.Server
{
    class Program : ServiceExe
    {
        static void Main(string[] args)
        {
            CommandLineInterface.EnsureAdminRights();

            SetInfo(new ServiceInfo("BreviteeDaemon", "Brevitee Daemon", "Brevitee http application server"));

            if (!ProcessCommandLineArgs(args))
            {
                RunService<Program>();
            }
        }

        protected override void OnStart(string[] args)
        {
            Server.Start();
        }

        protected override void OnStop()
        {
            Server.Stop();
            Thread.Sleep(1000);
        }

        static BreviteeServer _server;
        static object _serverLock = new object();
        public static BreviteeServer Server
        {
            get
            {
                return _serverLock.DoubleCheckLock(ref _server, () =>
                {
                    BreviteeConf conf = BreviteeConf.Load();
                    return new BreviteeServer(conf);
                });
            }
        }

    }
}
