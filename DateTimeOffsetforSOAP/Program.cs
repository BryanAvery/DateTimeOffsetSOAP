using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeOffsetforSOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo
            {
                Id = Guid.NewGuid(),
                AcquireDate = DateTimeOffset.Now
            };

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(foo.GetType());
            xmlSerializer.Serialize(Console.Out, foo);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
