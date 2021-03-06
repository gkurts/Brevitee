using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Web
{
    public class ProxyAlias
    {
        public ProxyAlias() { }

        public ProxyAlias(string alias, Type typeToAlias)
        {
            this.Alias = alias;
            this.ClassName = typeToAlias.Name;
        }

        public string Alias { get; set; }
        public string ClassName { get; set; }

		public override string ToString()
		{
			string format = "{Alias}.{ClassName}";
			return format.NamedFormat(this);
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ProxyAlias alias = obj as ProxyAlias;
			if (alias != null)
			{
				return alias.ToString().Equals(this.ToString());
			}
			else
			{
				return base.Equals(obj);
			}
		}
    }
}
