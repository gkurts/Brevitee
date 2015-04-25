using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	/// <summary>
	/// Class that provides database schema like relationships
	/// for CLR types.  This class should not be instantiated
	/// directly, instead see <see cref="Brevitee.Data.Repositories.TypeSchemaGenerator"/>
	/// </summary>
	public class TypeSchema
	{
		public HashSet<Type> Tables { get; set; }
		public HashSet<TypeFk> ForeignKeys { get; set; }
		public HashSet<TypeXref> Xrefs { get; set; }
	}
}
