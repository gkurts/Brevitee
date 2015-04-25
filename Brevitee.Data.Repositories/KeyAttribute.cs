using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Data.Repositories
{
	/// <summary>
	/// Specifies that a property should be used as the 
	/// primary key for an object
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class KeyAttribute: Attribute
	{
	}
}
