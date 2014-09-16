using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brevitee.ServiceProxy.Secure;

namespace Brevitee.ServiceProxy
{
    /// <summary>
    /// This class exists for testing
    /// </summary>
    public class EchoData
    {
        public string StringProperty { get; set; }
        public bool BoolProperty { get; set; }
        public int IntProperty { get; set; }
    }

    [ApiKeyRequired]
    public class ApiKeyRequiredEcho : Echo
    {

    }


    [Proxy]
    [Encrypt]
    public class EncryptedEcho: Echo
    {
    }

    /// <summary>
    /// Used specifically for testing ServiceProxy calls
    /// </summary>
    [Proxy("srvrEcho")]
    public class Echo
    {
        public string Send(string value)
        {
            return TestStringParameter(value);
        }

        public string TestStringParameter(string value)
        {
            return value;
        }

        public string TestObjectParameter(EchoData data, string more)
        {
            return string.Format("The data was: {0}\r\n***\r\nMore: {1}", data.PropertiesToString(), more);
        }

        public string TestCompoundParameter(TestObject test)
        {
            return string.Format("Name: {0}, Number: {1}, SubNumber: {2}, SubObject: {3}"
                ._Format(test.Name, test.Number, test.SubNumber, test.SubObject.PropertiesToString()));
        }

        public EchoData TestObjectOut(string value, bool bp = false, int ip = 500)
        {
            return new EchoData { StringProperty = value, BoolProperty = bp, IntProperty = ip };
        }

        public EchoData TestObjectInObjectOut(EchoData data)
        {
            return data;
        }
    }
}
