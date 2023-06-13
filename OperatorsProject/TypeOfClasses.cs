using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsProject
{
    public class TypeOfClasses
    {

        public void GetTypes()
        {
            Type typeValue = typeof(Person);

            Console.WriteLine(typeValue.FullName);
            Console.WriteLine(typeValue.Name);
            Console.WriteLine(typeValue.Assembly);
            Console.WriteLine(typeValue.AssemblyQualifiedName);

            foreach(var item in typeValue.GetProperties())
            {
                Console.WriteLine(item.Name);
            }

        }
    }


    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public short Age { get; set; }
    }
}
