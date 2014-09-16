using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.ServiceProxy.Secure
{
    public class ValidationTokenNotFoundException: Exception 
    {
        public ValidationTokenNotFoundException(string message)
            : base(message)
        { }
    }
}
