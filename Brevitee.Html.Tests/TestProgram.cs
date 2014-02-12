using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Naizari.Extensions;
using System.Reflection;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
//using Naizari.Testing;
using System.IO;
using Brevitee.CommandLine;
using Brevitee;
using Brevitee.Testing;
using System.Threading;
using System.Web.Mvc;

namespace Brevitee.Html.Tests
{
    public class TestProgram : CommandLineTestInterface
    {
        // Add optional code here to be run before initialization/argument parsing.
        public static void PreInit()
        {
            #region expand for PreInit help
            // To accept custom command line arguments you may use            
            /*
             * AddValidArgument(string argumentName, bool allowNull)
            */

            // All arguments are assumed to be name value pairs in the format
            // /name:value unless allowNull is true.

            // to access arguments and values you may use the protected member
            // arguments. Example:

            /*
             * arguments.Contains(argName); // returns true if the specified argument name was passed in on the command line
             * arguments[argName]; // returns the specified value associated with the named argument
             */

            // the arguments protected member is not available in PreInit() (this method)
            #endregion
        }

        /*
          * Methods addorned with the ConsoleAction attribute can be run
          * interactively from the command line while methods addorned with
          * the TestMethod attribute will be run automatically when the
          * compiled executable is run.  To run ConsoleAction methods use
          * the command line argument /i.
          * 
          * All methods addorned with ConsoleAction and TestMethod attributes 
          * must be static for the purposes of extending CommandLineTestInterface
          * or an exception will be thrown.
          * 
          */

        // To run ConsoleAction methods use the command line argument /i.        
        [ConsoleAction("This is a main menu option")]
        public static void ExampleMainMenuOption(string parameter)
        {
            Out(parameter, ConsoleColor.Green);
        }

        [ConsoleAction("write icon struct vals")]
        public static void WriteIconStructVals()
        {
            string[] names = File.ReadAllLines("c:\\src\\tmp\\iconnames.txt");
            foreach (string name in names)
            {
                string iconname = name.Trim();
                if (!string.IsNullOrEmpty(iconname))
                {
                    string.Format("\"{0}\",\r\n", iconname).SafeAppendToFile("c:\\src\\tmp\\commas.txt");
                }
            }
        }

        [ConsoleAction("write enum")]
        public static void WriteEnum()
        {
            string[] names = File.ReadAllLines("c:\\src\\tmp\\iconnames.txt");
            foreach (string name in names)
            {
                string iconname = name.Trim().Replace("icon-", "").PascalCase(true, "-");
                if (!string.IsNullOrEmpty(iconname))
                {
                    string.Format("{0},\r\n", iconname).SafeAppendToFile("c:\\src\\tmp\\enumvals.txt");
                }
            }
        }

        [UnitTest]
        public static void DeferredContentShouldRender()
        {
            Tag done = new Tag("span").Text("done");
            int runCount = 0;
            DeferredView view = new DeferredView("Monkey", (dv) =>
            {
                // long processing
                Thread.Sleep(1000);
                runCount++;
                return done;
            },
            () =>
            {
                return new Tag("span").Text("initial");
            }, 300);
            
            Expect.AreEqual(0, runCount, "runcount mismatch");

            string initial = view.Render().ToHtmlString();
            OutFormat("Should be initial: \r\n{0}", initial);
            FileInfo compareToFile = new FileInfo(string.Format(".\\{0}_initial.txt", MethodBase.GetCurrentMethod().Name));
            Compare(view.Content, compareToFile);

            Out("waiting 2 seconds");
            Thread.Sleep(2000);
            Expect.AreEqual(1, runCount, "runcount mismatch");

            string doneHtml = view.Render().ToHtmlString();
            OutFormat("Should be done: \r\n{0}", doneHtml);
            compareToFile = new FileInfo(string.Format(".\\{0}_done.txt", MethodBase.GetCurrentMethod().Name));
            Compare(view.Content, compareToFile);

            string retreived = DeferredViewController.GetContentString(view.Name);
            Expect.AreEqual(1, runCount);
            string reretrieved = DeferredViewController.GetContentString(view.Name, true);
            Expect.AreEqual(retreived, reretrieved);
            Expect.AreEqual(2, runCount);
        }

        private static void Compare(MvcHtmlString tag, FileInfo compareToFile)
        {
            string compare = "";
            if (!compareToFile.Exists)
            {
                Out("The comparison file was not found, using result as comparison", ConsoleColor.Yellow);
                using (StreamWriter sw = new StreamWriter(compareToFile.FullName))
                {
                    sw.Write(tag.ToHtmlString());
                }
            }

            using (StreamReader sr = new StreamReader(compareToFile.FullName))
            {
                compare = sr.ReadToEnd();
            }

            Expect.IsNotNullOrEmpty(compare);
            Expect.AreEqual(compare, tag.ToHtmlString().ToString());
            Out(compare, ConsoleColor.Cyan);
        }

        #region do not modify
        static void Main(string[] args)
        {
            PreInit();
            Initialize(args);
        }


        #endregion
    }
}