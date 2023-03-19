using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serializacja
{
    internal class JsonSerializer1
    {
        public static void Create()
        {
            EmployeeJson emp1 = new EmployeeJson()
            {
                Id = 123,
                FirstName ="Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            emp1.SetToken(Guid.NewGuid().ToString());
            EmployeeJson emp2 = new EmployeeJson()
            {
                Id = 123,
                FirstName ="Zenon",
                LastName = "Nowak",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            emp2.SetToken(Guid.NewGuid().ToString());
            EmployeeJson emp3 = new EmployeeJson()
            {
                Id = 123,
                FirstName ="Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            emp3.SetToken(Guid.NewGuid().ToString());

            EmployeeJson[] empArray = new EmployeeJson[] 
            { 
                emp1 , emp2, emp3
            };

            //serializacja
            using (FileStream fs = new FileStream("json1.json", FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EmployeeJson[]));
                serializer.WriteObject(fs, empArray);
            }

            //deserializacja
            using (FileStream fs = new FileStream("json1.json", FileMode.Open))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EmployeeJson[]));
                EmployeeJson[] emps = serializer.ReadObject(fs) as EmployeeJson[];

                if (emps != null)
                {
                    Console.WriteLine(emps.Length);
                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            string s = js.Serialize(empArray);
            File.WriteAllText("json2.json", s);

            EmployeeJson[] emps2 = js.Deserialize<EmployeeJson[]>(s);
            Console.WriteLine(emps2.Length);

        }

    }
}
