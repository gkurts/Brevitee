using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	/// <summary>
	/// Foreing key descriptor for generated TypeSchemas
	/// </summary>
	public class TypeFk
	{
		/// <summary>
		/// The type of the Primary Key poco
		/// </summary>
		public Type PrimaryKeyType { get; set; }

		/// <summary>
		/// The property of the Primary Key poco
		/// that represents the Id/Primary Key
		/// </summary>
		public PropertyInfo PrimaryKeyProperty { get; set; }

		/// <summary>
		/// The type of the Foreign Key poco
		/// </summary>
		public Type ForeignKeyType { get; set; }

		/// <summary>
		/// The Foreign Key property that references the 
		/// Primary Key
		/// </summary>
		public PropertyInfo ForeignKeyProperty { get; set; }

		/// <summary>
		/// The property that represents the collection
		/// of Foreign Keys that represent the same 
		/// Primary Key
		/// </summary>
		public PropertyInfo CollectionProperty { get; set; }

		/// <summary>
		/// The property that represents the Parent
		/// Primary Key instance on the Foreign Key
		/// </summary>
		public PropertyInfo ChildParentProperty { get; set; }

		public override bool Equals(object obj) 
		{
			TypeFk compareTo = obj as TypeFk;
			if (compareTo != null) 
			{
				return PrimaryKeyType.Equals(compareTo.PrimaryKeyType) && ForeignKeyType.Equals(compareTo.ForeignKeyType);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode() 
		{
			return PrimaryKeyType.GetHashCode() + ForeignKeyType.GetHashCode();
		}
	}
}
