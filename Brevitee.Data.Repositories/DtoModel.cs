using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Schema;
using System.Reflection;

namespace Brevitee.Data.Repositories
{
	public class DtoModel
	{
		public DtoModel(Type dynamicDtoType, string nameSpace)
		{
			this.TypeName = dynamicDtoType.Name;
			List<string> properties = new System.Collections.Generic.List<string>();
			foreach(PropertyInfo p in dynamicDtoType.GetProperties())
			{
				Type type = (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? Nullable.GetUnderlyingType(p.PropertyType) : p.PropertyType;
				properties.Add("\tpublic {0} {1} {{get; set;}}\r\n"._Format(type.Name, p.Name));
			}
			this.Properties = properties.ToArray();
			this.DtoType = dynamicDtoType;
			this.Namespace = nameSpace;
		}

		public DtoModel(Dao dao, string nameSpace)
			: this(dao.CreateDynamicType<ColumnAttribute>(), nameSpace)
		{ }

		public string TypeName { get; set; }
		public string Namespace { get; set; }
		public string[] Properties { get; set; }

		public Type DtoType { get; set; }

		public string Render()
		{
			List<Assembly> references = new List<Assembly>(RazorParser<DtoTemplate>.GetDefaultAssembliesToReference());
			references.Add(typeof(PropertyInfo).Assembly);
			RazorParser<DtoTemplate> parser = new RazorParser<DtoTemplate>(RazorBaseTemplate.DefaultInspector);
			string output = parser.ExecuteResource("Dto.tmpl", "Brevitee.Data.Repositories.Templates.", typeof(DtoTemplate).Assembly,
				new { Model = this }, references.ToArray());

			return output;
		}
	}
}
