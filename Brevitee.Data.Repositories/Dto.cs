using System;
using System.Linq;
using System.Reflection;
using System.IO;

namespace Brevitee.Data.Repositories
{
	/// <summary>
	/// A Data Transfer Object.  Represents the properties
	/// of Dao types without the associated methods.  
	/// </summary>
	public class Dto
	{
		/// <summary>
		/// Get the associated Dto types for the 
		/// Dao types in the specified daoAssembly
		/// </summary>
		/// <param name="daoAssembly"></param>
		/// <returns></returns>
		public static Type[] GetTypesFromDaos(Assembly daoAssembly)
		{
			GeneratedAssemblyInfo assemblyInfo = GetGeneratedDtoAssemblyInfo(daoAssembly);

			return assemblyInfo.GetAssembly().GetTypes();
		}

		/// <summary>
		/// Get a generated Dto type for the specified Dao instance.
		/// The Dto type will only have properties that match the columns
		/// of the Dao
		/// </summary>
		/// <param name="daoInstance"></param>
		/// <returns></returns>
		public static Type TypeFor(Dao daoInstance)
		{
			return TypeFor(daoInstance.GetType());
		}

		/// <summary>
		/// Get the associated Dto type for the specified
		/// daoType
		/// </summary>
		/// <param name="daoType"></param>
		/// <returns></returns>
		public static Type TypeFor(Type daoType)
		{
			return GetTypesFromDaos(daoType.Assembly).Where(t => t.Name.Equals(daoType.Name)).FirstOrDefault();
		}

		/// <summary>
		/// Copy the specified Dao instance as an equivalent Dto instance
		/// </summary>
		/// <param name="instance"></param>
		/// <returns></returns>
		public static object Copy(Dao instance)
		{
			return instance.CopyAs(TypeFor(instance));
		}

		/// <summary>
		/// Generates an assembly containing Dto's that represent all the 
		/// Dao's found in the sepecified daoAssembly.  A Dto or (DTO) is
		/// a Data Transfer Object and represents only the properties of 
		/// a Dao.  A Dao or (DAO) is a Data Access Object that represents
		/// both properties and methods to create, retrieve, update and delete. 
		/// </summary>
		/// <param name="daoAssembly"></param>
		/// <returns></returns>
		public static GeneratedAssemblyInfo GetGeneratedDtoAssemblyInfo(Assembly daoAssembly, string fileName = null)
		{
			DaoToDtoGenerator generator;
			string defaultFileName = GetDefaultFileName(daoAssembly, out generator);
			fileName = fileName ?? defaultFileName;
			GeneratedAssemblyInfo assemblyInfo = GeneratedAssemblies.GetGeneratedAssemblyInfo(fileName);

			if (assemblyInfo == null)
			{
				assemblyInfo = new GeneratedAssemblyInfo(fileName);
				// check for the info file
				if (assemblyInfo.InfoFileExists) // load it from file if it exists
				{
					assemblyInfo = assemblyInfo.InfoFilePath.FromJsonFile<GeneratedAssemblyInfo>();
					if (!assemblyInfo.InfoFileName.Equals(fileName) || !assemblyInfo.AssemblyExists) // regenerate if the names don't match
					{
						assemblyInfo = generator.GenerateDtoAssembly();
					}
				}
				else
				{
					assemblyInfo = generator.GenerateDtoAssembly();
				}
			}

			GeneratedAssemblies.SetAssemblyInfo(fileName, assemblyInfo);
			return assemblyInfo;
		}

		public static string GetDefaultFileName(Assembly daoAssembly)
		{
			DaoToDtoGenerator ignore;
			return GetDefaultFileName(daoAssembly, out ignore);
		}

		public static string GetDefaultFileName(Assembly daoAssembly, out DaoToDtoGenerator generator)
		{
			generator = new DaoToDtoGenerator(daoAssembly);
			string fileName = generator.GetDefaultFileName();
			return fileName;
		}
		public static void WriteRenderedDto(string nameSpace, string writeSourceTo, Type dynamicDtoType)
		{
			DtoModel pocoModel = new DtoModel(dynamicDtoType, nameSpace);
			string csFile = "{0}.cs"._Format(pocoModel.TypeName);
			using (StreamWriter sw = new StreamWriter(Path.Combine(writeSourceTo, csFile)))
			{
				sw.Write(pocoModel.Render());
			}
		}
	}
}