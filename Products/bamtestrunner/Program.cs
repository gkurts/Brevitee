using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Brevitee.CommandLine;
using Brevitee;
using Brevitee.Testing;
using Brevitee.Encryption;
using Brevitee.Logging;

namespace Brevitee.Testing
{
    [Serializable]
    class Program : CommandLineTestInterface
	{
	    private const string _exitOnFailure = "exitOnFailure";
		private const string _programName = "bamtestrunner";
        static void Main(string[] args)
        {
            PreInit();
            Initialize(args);
        }

        public static void PreInit()
        {
            #region expand for PreInit help
            // To accept custom command line arguments you may use            
            /*
             * AddValidArgument(string argumentName, bool allowNull)
            */

            // All arguments are assumed to be name value pairs in the format
            // /name:value unless allowNull is true then only the name is necessary.

            // to access arguments and values you may use the protected member
            // arguments. Example:

            /*
             * arguments.Contains(argName); // returns true if the specified argument name was passed in on the command line
             * arguments[argName]; // returns the specified value associated with the named argument
             */

            // the arguments protected member is not available in PreInit() (this method)
            #endregion
            AddValidArgument("search", false, "The search pattern to use to locate test assemblies");
            AddValidArgument("dir", false, "The directory to look for test assemblies in");
			AddValidArgument("debug", true, "If specified, the runner will pause to allow for a debugger to be attached to the process");
			AddValidArgument(_exitOnFailure, true);
            DefaultMethod = typeof(Program).GetMethod("Start");
        }

        #region do not modify
        public static void Start()
        {			
			if(Arguments.Contains("debug"))
			{
				Pause("Attach the debugger now");
			}
			
			if(File.Exists(tempFile))
			{
				File.Delete(tempFile);
			}

            DirectoryInfo testDir = new DirectoryInfo(".");
            if (Arguments.Contains("dir"))
            {
                string dir = Arguments["dir"];
                testDir = new DirectoryInfo(dir);
                if (!testDir.Exists)
                {
                    OutLineFormat("The specified directory ({0}) was not found", ConsoleColor.Red, dir);
                    Exit(1);
                }
            }

            FileInfo[] files = null;
            if (Arguments.Contains("search"))
            {
                files = testDir.GetFiles(Arguments["search"]);
            }
            else
            {
                files = testDir.GetFiles();
            }

            TestFailed += TestFailedHandler;
			EventHandler<TestExceptionEventArgs> onFailed = TestFailedHandler;
			EventHandler<ConsoleInvokeableMethod> onPassed = TestPassedHandler;
			TestState state = new TestState();
			state.ExitOnFailure = Arguments.Contains(_exitOnFailure);

			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fi = files[i];
				try
				{
					InvokeInSeparateAppDomain(typeof(CommandLineTestInterface).GetMethod("RunAllTestsInFile"), null, state, new object[] { fi, onFailed, onPassed });
				}
				catch (Exception ex)
				{
					OutLineFormat("bamtestrunner: {0}", ConsoleColor.DarkRed, ex.Message);
					if (Arguments.Contains(_exitOnFailure))
					{
						Exit(1);
					}
				}
			}

			if (state.ExceptionOccurred)
			{				
				Log.AddEntry(tempFile.SafeReadFile(), LogEventType.Error);
				Exit(1);
			}
			else
			{
				Exit(0);
			}
        }

		static string tempFile = string.Format(".\\{0}_tmp.txt", _programName);
		static void WriteFailure(TestExceptionEventArgs e)
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine("Method: {0}"._Format(e.ConsoleInvokeableMethod.Method.Name));
			s.AppendLine("Description: {0}"._Format(e.ConsoleInvokeableMethod.Information));
			s.AppendLine("Assembly: {0}"._Format(e.ConsoleInvokeableMethod.Method.DeclaringType.Assembly.FullName));
			s.AppendLine("\t{0}"._Format(e.Exception.Message));
			s.AppendLine();
			string message = s.ToString();
			message.SafeAppendToFile(tempFile);
			OutLine(message, ConsoleColor.Red);
			TestState state = PopState<TestState>();
			state.Error(message, e.Exception);
		}
		
        static void TestFailedHandler(object sender, TestExceptionEventArgs e)
        {
			WriteFailure(e);
			TestState state = PopState<TestState>();
			state.ExceptionOccurred = true;
			if (state.ExitOnFailure)
			{
				Exit(1);
			}
        }

		static void TestPassedHandler(object sender, ConsoleInvokeableMethod cim)
		{
			string outputFormat = "{0}:Passed";
			OutLineFormat(outputFormat, ConsoleColor.Green, cim.Information);
			TestState state = PopState<TestState>();
			state.Info(outputFormat._Format(cim.Information));
		}
        #endregion
    }

}
