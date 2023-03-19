using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serializacja
{
    internal class SerializerXML
    {
        public static void Create()
        {
            EmployeeXML emp1 = new EmployeeXML()
            {
                Id = 123,
                FirstName ="Jan",
                LastName = "Kowalski",
                IsManager = null,
                StartAt = new DateTime(2022, 1, 1)
            };
            //emp1.SetToken(Guid.NewGuid().ToString());
            EmployeeXML emp2 = new EmployeeXML()
            {
                Id = 123,
                FirstName ="Zenon",
                LastName = "Nowak",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            //emp2.SetToken(Guid.NewGuid().ToString());
            EmployeeXML emp3 = new EmployeeXML()
            {
                Id = 123,
                FirstName ="Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1),
                ExtraData = new List<string> () { "AAA", "bbb"}
            };
            emp3.SetToken(Guid.NewGuid().ToString());

            EmployeeXML[] empArray = new EmployeeXML[] 
            { 
                emp1 , emp2, emp3
            };

            //serializacja
            using (FileStream fs = new FileStream("xml.xml", FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(EmployeeXML[]));
                xs.Serialize(fs, empArray);

            }

            //deserializacja
            using (FileStream fs = new FileStream("xml.xml", FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(EmployeeXML[]));
                EmployeeXML[] emps = xs.Deserialize(fs) as EmployeeXML[];
                if (emps != null)
                {
                    Console.WriteLine(emps.Length);
                }

            }

        }

    }
}
