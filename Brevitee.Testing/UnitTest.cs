using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.CommandLine;
using System.Reflection;

namespace Brevitee.Testing
{
    /// <summary>
    /// Attribute used to mark a method as a Unit Test
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
    public class UnitTest: ConsoleAction
    {
        public UnitTest()
            : base()
        {
        }

        public UnitTest(string description)
            : base(description)
        {
        }
    }
}
