using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Brevitee.Messaging
{
    public class StringFormatEmailComposer: EmailComposer
    {
        public StringFormatEmailComposer() : base() { }
        public StringFormatEmailComposer(string templateDirectory, string extension = ".txt")
            : base(templateDirectory, extension)
        { }

        public override string GetEmailBody(string emailName, params object[] data)
        {
            return GetTemplateContent(emailName)._Format(data);
        }

    }
}
