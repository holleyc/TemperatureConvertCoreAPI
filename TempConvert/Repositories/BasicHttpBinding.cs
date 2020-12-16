using System;
using System.Xml;

namespace TempConvert.Repositories
{
    internal class BasicHttpBinding
    {
        public TimeSpan SendTimeout { get; set; }
        public int MaxBufferSize { get; set; }
        public int MaxReceivedMessageSize { get; set; }
        public bool AllowCookies { get; set; }
        public XmlDictionaryReaderQuotas ReaderQuotas { get; set; }
        public object Security { get; set; }
    }
}