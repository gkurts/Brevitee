using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brevitee.Html
{
    public class Select: Tag
    {
        public Select()
            : base("select")
        {
        }

        public Select(Dictionary<string, string> values)
            : this()
        {
            foreach (string key in values.Keys)
            {
                this.Child(new Tag("option").Text(values[key]));
            }
        }
    }
}
