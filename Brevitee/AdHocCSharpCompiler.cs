using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace Brevitee
{
    public static class AdHocCSharpCompiler
    {
		static string[] _referenceAssemblies = new string[] { };
		static string[] _defaultReferenceAssemblies = new string[] { };
		public static string[] DefaultReferenceAssemblies
		{
			get
			{
				if(_defaultReferenceAssemblies.Length == 0)
				{
					string folder = typeof(AdHocCSharpCompiler).Assembly.GetFileInfo().DirectoryName;
					List<string> defaultAssemblies = new List<string>();
					defaultAssemblies.Add("System.dll");
					defaultAssemblies.Add("System.Core.dll");
					defaultAssemblies.Add("System.Xml.dll");
					defaultAssemblies.Add("System.Data.dll");
					defaultAssemblies.Add(Path.Combine(folder, "System.Web.Mvc.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.ServiceProxy.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.Data.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.Data.Schema.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.Data.dll"));
					defaultAssemblies.Add(Path.Combine(folder, "Brevitee.Incubation.dll"));
					_defaultReferenceAssemblies = defaultAssemblies.ToArray();
				}

				return _defaultReferenceAssemblies;
			}
		}

		public static void SetReferenceAssemlbies(string[] value)
		{
			_referenceAssemblies = value;
		}

		public static Assembly ToAssembly(this DirectoryInfo direcotry, string assemblyFileName)
		{
			CompilerResults ignore;
			return ToAssembly(direcotry, assemblyFileName, out ignore);
		}

		/// <summary>
		/// Compile the directory to the specified assemblyFileName and return the assembly
		/// </summary>
		/// <param name="directory"></param>
		/// <param name="assemblyFileName"></param>
		/// <param name="results"></param>
		/// <returns></returns>
		public static Assembly ToAssembly(this DirectoryInfo directory, string assemblyFileName, out CompilerResults results)
		{
			return ToAssembly(directory, assemblyFileName, out results, true);
		}

		public static Assembly ToAssembly(this DirectoryInfo directory, string assemblyFileName, out CompilerResults results, bool throwOnError = true)
		{
			if (_referenceAssemblies.Length == 0)
			{
				_referenceAssemblies = DefaultReferenceAssemblies;
			}

			results = CompileDirectory(directory, assemblyFileName, _referenceAssemblies, false);
	
			if(results.Errors.Count > 0 && throwOnError)
			{
				throw new CompilationException(results);
			}

			return results.CompiledAssembly;
		}

		public static CompilerResults CompileDirectory(DirectoryInfo directory, string assemblyFileName, string[] referenceAssemblies, bool executable)
		{
			return CompileDirectories(new DirectoryInfo[] { directory }, assemblyFileName, referenceAssemblies, executable);
		}

        public static CompilerResults CompileDirectories(DirectoryInfo[] directories, string assemblyFileName, string[] referenceAssemblies, bool executable)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters parameters = GetCompilerParameters(assemblyFileName, referenceAssemblies, executable);

            List<string> fileNames = new List<string>();

            foreach (DirectoryInfo directory in directories)
            {
                foreach (FileInfo fileInfo in directory.GetFiles("*.cs", SearchOption.AllDirectories))
                {
                    if (!fileNames.Contains(fileInfo.FullName))
                    {
                        fileNames.Add(fileInfo.FullName);
                    }
                }
            }
            return codeProvider.CompileAssemblyFromFile(parameters, fileNames.ToArray());
        }

        public static CompilerParameters GetCompilerParameters(string assemblyFileName, string[] referenceAssemblies, bool executable)
        {
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = executable;
            parameters.OutputAssembly = assemblyFileName;

            SetCompilerOptions(referenceAssemblies, parameters);
            return parameters;
        }

        public static void SetCompilerOptions(string[] referenceAssemblies, CompilerParameters parameters)
        {
            StringBuilder compilerOptions = new StringBuilder();

            foreach (string referenceAssembly in referenceAssemblies)
            {
                compilerOptions.AppendFormat("/reference:{0} ", referenceAssembly);
            }
            parameters.CompilerOptions = compilerOptions.ToString();
        }

		public static string GetMessage(CompilerResults compilerResults)
		{
			StringBuilder message = new StringBuilder();

			foreach (CompilerError error in compilerResults.Errors)
			{
				message.AppendFormat("File=>{0}\r\n", error.FileName);
				message.AppendFormat("Line {0}, Column {1}::{2}", error.Line, error.Column, error.ErrorText);
			}

			return message.ToString();
		}
    }
}
