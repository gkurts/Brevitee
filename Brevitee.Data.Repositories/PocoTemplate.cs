using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Data.Schema;
using System.Reflection;
using Brevitee.ServiceProxy;

namespace Brevitee.Data.Repositories
{
	public abstract class PocoTemplate: RazorTemplate<PocoModel>
	{

		public void WriteChildPrimaryKeyProperty(TypeFk fk)
		{
			MethodInfo method = fk.ChildParentProperty.GetGetMethod();
			if(method != null && method.IsVirtual)
			{
				Write(Render<TypeFk>("ChildPrimaryKeyProperty.tmpl", new { Model = fk }));
			}
		}

		public void WriteForeignKeyProperty(TypeFk fk)
		{
			if(fk.CollectionProperty.GetGetMethod().IsVirtual)
			{
				Write(Render<TypeFk>("ForeignKeyProperty.tmpl", new { Model = fk }));
			}
		}

		public void WriteLeftXrefProperty(TypeXref xref)
		{
			MethodInfo method = xref.LeftCollectionProperty.GetGetMethod();
			if(method != null && method.IsVirtual)
			{
				Write(Render<TypeXref>("XrefLeftProperty.tmpl", new { Model = xref }));
			}
		}

		public void WriteRightXrefProperty(TypeXref xref)
		{
			MethodInfo method = xref.LeftCollectionProperty.GetGetMethod();
			if (method != null && method.IsVirtual)
			{
				Write(Render<TypeXref>("XrefRightProperty.tmpl", new { Model = xref }));
			}
		}

		private string Render<T>(string templateName, object options)
		{
			List<Assembly> referenceAssemblies = new List<Assembly>{ 
					typeof(DaoGenerator).Assembly,
					typeof(ServiceProxyController).Assembly, 
					typeof(Providers).Assembly};

			referenceAssemblies.Add(typeof(DaoRepository).Assembly);
			RazorParser<RazorTemplate<T>> parser = new RazorParser<RazorTemplate<T>>();
			string result = parser.ExecuteResource(templateName, "Brevitee.Data.Repositories.Templates.", typeof(PocoTemplate).Assembly, options, referenceAssemblies.ToArray()).Trim();
			return result;
		}
	}
}
