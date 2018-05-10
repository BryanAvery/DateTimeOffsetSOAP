using System;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace DateTimeOffsetforSOAP
{
    public class Foo
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(UtcDateTimeOffsetConverter))]
        [XmlElement("AcquireDate")]
        public string acquireDateForXml
        {
            get { return AcquireDate.ToString(); }
            set { AcquireDate = DateTimeOffset.Parse(value); }
        }

        [XmlIgnore]
        public Iso8601SerializableDateTimeOffset? AcquireDate;
    }
}
