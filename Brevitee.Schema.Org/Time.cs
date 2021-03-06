using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Schema.Org
{
    public class Time: DataType
    {
        public Time()
        {
            this.Name = "Time";
        }

        public Time(DateTime value)
        {
            this.Value = value;
        }

        public static implicit operator DateTime(Time time)
        {
            return time.Value;
        }

        public static implicit operator Time(DateTime value)
        {
            return new Time(value);
        }

        public DateTime Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value.ToString("s");
        }
    }
}
