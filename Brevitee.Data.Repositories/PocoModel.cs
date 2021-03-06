using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Schema;
using System.Reflection;

namespace Brevitee.Data.Repositories
{
	public class PocoModel
	{
		public PocoModel(Type pocoType, TypeSchema schema, string nameSpace = "TypePocos")
		{
			this.DtoType = pocoType;
			this.Namespace = nameSpace;
			this.TypeNamespace = pocoType.Namespace;
			this.TypeName = pocoType.Name;
			this.ForeignKeys = schema.ForeignKeys.Where(fk => fk.PrimaryKeyType.Equals(pocoType)).ToArray();
			this.ChildPrimaryKeys = schema.ForeignKeys.Where(fk => fk.ForeignKeyType.Equals(pocoType)).ToArray();
			this.LeftXrefs = schema.Xrefs.Where(xref => xref.Left.Equals(pocoType)).ToArray();
			this.RightXrefs = schema.Xrefs.Where(xref => xref.Right.Equals(pocoType)).ToArray();
		}

		public string Namespace { get; set; }

		public string TypeNamespace { get; set; }

		public string TypeName { get; set; }

		public TypeFk[] ForeignKeys { get; set; }

		public TypeFk[] ChildPrimaryKeys { get; set; }

		/// <summary>
		/// Xrefs where the current DtoType is the left
		/// side of the cross refernce table
		/// </summary>
		public TypeXref[] LeftXrefs { get; set; }

		/// <summary>
		/// Xrefs where the current DtoType is the Right
		/// side of the cross reference table
		/// </summary>
		public TypeXref[] RightXrefs { get; set; }
		
		private Type DtoType { get; set; }

		public string Render()
		{
			List<Assembly> references = new List<Assembly>(RazorParser<PocoTemplate>.GetDefaultAssembliesToReference());
			references.Add(DtoType.Assembly);
			RazorParser<PocoTemplate> parser = new RazorParser<PocoTemplate>(RazorBaseTemplate.DefaultInspector);
			string output = parser.ExecuteResource("Poco.tmpl", "Brevitee.Data.Repositories.Templates.", typeof(PocoGenerator).Assembly,
				new { Model = this }, references.ToArray());

			return output;
		}
	}
}
