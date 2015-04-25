using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using Brevitee;
using Brevitee.Logging;
using Brevitee.Data;
using Brevitee.Data.Repositories;
using Brevitee.Data.Schema;

namespace Brevitee.Yaml
{
	/// <summary>
	/// A class used to generate a YamlSchema from a specified directory
	/// which presumably contains yaml files.  Uses DirectoryInfo.GetFiles("*.yaml") 
	/// internally so an OutOfMemoryExcepion may occur if there are too 
	/// many files.
	/// </summary>
	public class YamlSchemaGenerator: Loggable
	{
		public YamlSchemaGenerator(ILogger logger = null): base()
		{
			if(logger != null)
			{
				this.Subscribe(logger);
			}
		}

		public bool AddAuditFields { get; set; }

		[Verbosity(VerbosityLevel.Information)]
		public event EventHandler FilesFound;

		[Verbosity(VerbosityLevel.Information)]
		public event EventHandler SchemaGenerationComplete;
			
		public YamlSchema GenerateYamlSchema(DirectoryInfo yamlRoot, string fileExtension = "*.yaml")
		{
			YamlSchema yamlSchema = new YamlSchema(yamlRoot);
			this.Subscribe(yamlSchema);
			FileInfo[] yamlFiles = yamlRoot.GetFiles(fileExtension, SearchOption.AllDirectories);
			if (yamlFiles.Length > 0)
			{
				FireEvent(FilesFound, new YamlEventArgs { Files = yamlFiles });
				yamlSchema.AddFiles(yamlFiles.ToList());
				FireEvent(SchemaGenerationComplete, new YamlEventArgs { Schema = yamlSchema, Files = yamlFiles });				
			}

			return yamlSchema;
		}
	}
}
