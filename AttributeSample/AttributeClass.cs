using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSample
{
    public class AttributeClass
    {
        //به اصطلاح وقتی میخواهیم اتریبیوتی اختصاص بدیم می گویم دکوریت کردن

    }

    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class PersonPrint
    {
        private readonly Person _person;

        public PersonPrint(Person person)
        {
            this._person = person;
        }

       public void Print()
        {
            PrintFullName();
            PrintAge();
        }

        private void PrintAge()
        {
            Console.WriteLine($"Age Is {_person.Age}");
        }

        private void PrintFullName()
        {
            Console.WriteLine($"FirstName :{_person.FirstName} And LastName : {_person.LastName}");
        }
    }
}
