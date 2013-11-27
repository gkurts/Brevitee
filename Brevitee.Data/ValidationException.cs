using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brevitee.Data
{
    public class ValidationException: Exception
    {
        public ValidationException(string msg) : base(msg) { }
        public ValidationException(Exception inner) : base("An exception occurred", inner) { }
        public ValidationException(string msg, Exception inner) : base(msg, inner) { }
    }
}
