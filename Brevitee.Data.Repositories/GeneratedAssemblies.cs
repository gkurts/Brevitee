using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Brevitee;

namespace Brevitee.Data.Repositories
{
	internal static class GeneratedAssemblies
	{
		static Dictionary<string, GeneratedAssemblyInfo> _generatedAssemblies = new Dictionary<string, GeneratedAssemblyInfo>();
		public static Assembly GetGeneratedAssembly(string name)
		{
			GeneratedAssemblyInfo info = GetGeneratedAssemblyInfo(name);
			if (info != null)
			{
				return info.GetAssembly();
			}

			return null;
		}
		public static GeneratedAssemblyInfo GetGeneratedAssemblyInfo(string name)
		{
			if (_generatedAssemblies.ContainsKey(name))
			{
				return _generatedAssemblies[name];
			}

			return null;
		}

		internal static void SetAssemblyInfo(string name, GeneratedAssemblyInfo assembly)
		{
			_generatedAssemblies[name] = assembly;
		}
	}
}
