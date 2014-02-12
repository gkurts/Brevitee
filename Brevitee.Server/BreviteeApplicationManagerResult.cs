using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.Server
{
    public class BreviteeApplicationManagerResult
    {
        public BreviteeApplicationManagerResult(bool success, string message, object data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }
        
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
