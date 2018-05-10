﻿using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DateTimeOffsetforSOAP
{
    public struct Iso8601SerializableDateTimeOffset : IXmlSerializable
    {
        public DateTimeOffset value;

        public Iso8601SerializableDateTimeOffset(DateTimeOffset value)
        {
            this.value = value;
        }

        public static implicit operator Iso8601SerializableDateTimeOffset(DateTimeOffset value)
        {
            return new Iso8601SerializableDateTimeOffset(value);
        }

        public static implicit operator DateTimeOffset(Iso8601SerializableDateTimeOffset instance)
        {
            return instance.value;
        }

        public static bool operator ==(Iso8601SerializableDateTimeOffset a, Iso8601SerializableDateTimeOffset b)
        {
            return a.value == b.value;
        }

        public static bool operator !=(Iso8601SerializableDateTimeOffset a, Iso8601SerializableDateTimeOffset b)
        {
            return a.value != b.value;
        }

        public static bool operator <(Iso8601SerializableDateTimeOffset a, Iso8601SerializableDateTimeOffset b)
        {
            return a.value < b.value;
        }

        public static bool operator >(Iso8601SerializableDateTimeOffset a, Iso8601SerializableDateTimeOffset b)
        {
            return a.value > b.value;
        }

        public override bool Equals(object o)
        {
            if (o is Iso8601SerializableDateTimeOffset)
                return value.Equals(((Iso8601SerializableDateTimeOffset)o).value);
            else if (o is DateTimeOffset)
                return value.Equals((DateTimeOffset)o);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var text = reader.ReadElementString();
            value = DateTimeOffset.ParseExact(text, format: "o", formatProvider: null);
        }

        public override string ToString()
        {
            return value.ToString(format: "o");
        }

        public string ToString(string format)
        {
            return value.ToString(format);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(value.ToString(format: "o"));
        }
    }
}
