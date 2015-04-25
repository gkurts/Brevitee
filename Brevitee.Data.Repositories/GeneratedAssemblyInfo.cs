using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Brevitee.Data.Schema;
using System.CodeDom.Compiler;

namespace Brevitee.Data.Repositories
{
	public class GeneratedAssemblyInfo
	{
		public static implicit operator Assembly(GeneratedAssemblyInfo gen)
		{
			return gen.GetAssembly();
		}

		public GeneratedAssemblyInfo()
		{
			this.Root = ".\\";
		}

		public GeneratedAssemblyInfo(string infoFileName)
			: this()
		{
			this.InfoFileName = infoFileName;
		}

		public GeneratedAssemblyInfo(string infoFileName, CompilerResults compilerResults)
			: this(infoFileName)
		{
			if (compilerResults.Errors != null &&
				compilerResults.Errors.Count > 0)
			{
				throw new CompilationException(compilerResults);
			}

			this.AssemblyFilePath = new FileInfo(compilerResults.PathToAssembly).FullName;
			this.Assembly = compilerResults.CompiledAssembly;
		}

		public string InfoFileName { get; set; }
		
		/// <summary>
		/// The path to the Assembly (.dll)
		/// </summary>
		public string AssemblyFilePath { get; set; }

		public bool AssemblyExists
		{
			get
			{
				return File.Exists(AssemblyFilePath);
			}
		}

		Assembly _assembly;

		internal Assembly Assembly
		{
			get
			{
				return _assembly;
			}
			set
			{
				_assembly = value;
			}
		}

		public Assembly GetAssembly()
		{
			if (_assembly == null)
			{
				_assembly = Assembly.LoadFrom(AssemblyFilePath);
			}

			return _assembly;
		}

		public string Root { get; set; }

		internal string InfoFilePath
		{
			get
			{
				return Path.Combine(Root, string.Format("{0}.genInfo.json", InfoFileName));
			}
		}

		internal bool InfoFileExists
		{			
			get
			{
				return File.Exists(InfoFilePath);
			}
		}

		public void Save()
		{			
			this.ToJsonFile(InfoFilePath);
		}

	}
}
