using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Brevitee.Data.Repositories
{
    /// <summary>
    /// Used to describe a many to many 
    /// relationship between two types.
    /// This would imply that each type
    /// has an IEnumerable property
    /// of the other type
    /// </summary>
    public class TypeXref
    {
        public Type Left { get; set; }
        public Type Right { get; set; }

		/// <summary>
		/// The property of the Left type that represents
		/// the collection containing elements of the Right type
		/// </summary>
		public PropertyInfo LeftCollectionProperty
		{
			get;
			set;
		}

		/// <summary>
		/// The property of the Right type that represents 
		/// the collection containing elements of the Left type
		/// </summary>
		public PropertyInfo RightCollectionProperty
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the LeftCollectionProperty.  Used by underlying 
		/// Poco generator
		/// </summary>
	    public string LeftCollectionTypeName 
		{
		    get 
			{
				string value = LeftCollectionProperty.PropertyType.IsArray ? LeftCollectionProperty.PropertyType.FullName : string.Format("List<{0}.{1}>", Left.Namespace, Left.Name);
			    return value;
		    }
	    }

		/// <summary>
		/// The name of the RightCollectionProperty.  Used by underlying
		/// Poco generator
		/// </summary>
		public string RightCollectionTypeName
		{
			get
			{
				string value = RightCollectionProperty.PropertyType.IsArray ? RightCollectionProperty.PropertyType.FullName : string.Format("List<{0}.{1}>", Right.Namespace, Right.Name);
				return value;
			}
		}

		/// <summary>
		/// Used by the underlying Poco generator
		/// </summary>
	    public string LeftArrayOrList 
		{
		    get { return LeftCollectionProperty.PropertyType.IsArray ? "Array" : "List"; }
	    }

		/// <summary>
		/// Used by the underlying Poco generator
		/// </summary>
		public string RightArrayOrList
		{
			get { return RightCollectionProperty.PropertyType.IsArray ? "Array" : "List"; }
		}

		public override bool Equals(object obj)
		{
			TypeXref compareTo = obj as TypeXref;
			if(compareTo != null)
			{
				return compareTo.Left.Equals(this.Left) && compareTo.Right.Equals(this.Right) ||
					compareTo.Left.Equals(this.Right) && compareTo.Right.Equals(this.Left);
			}
			
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.Left.GetHashCode() + this.Right.GetHashCode();
		}
    }
}
