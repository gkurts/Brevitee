using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brevitee.Logging;

namespace Brevitee.Logging
{
    [Proxy("log")]
    public class ClientLogger
    {
        public ClientLogger()
        {
            this.Logger = Log.Default;
        }

        public ClientLogger(ILogger logger)
        {
            this.Logger = logger;
        }

        protected ILogger Logger
        {
            get;
            set;
        }

        public void AddEntry(string messageSignature, int verbosity, string[] formatArgs)
        {
            Logger.AddEntry(messageSignature, verbosity, formatArgs);
        }
    }
}
