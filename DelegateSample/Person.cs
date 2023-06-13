using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    /// <summary>
    /// دلیگیت ها قرارداد های ما هستن ک همی تونیم رفتار یک متد را از بیرون کنترل کنیم 
    /// 
    /// </summary>
    /// <param name="person"></param>
    /// <returns></returns>
    public delegate string FullNameToString(Person person);
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class PersonFullName
    {
        public static string GetFullName(Person person)
        {
            return $"{person.FirstName}  {person.LastName}";
        }
        public static string GetFullNameReverse(Person person)
        {
            return $"{person.LastName} {person.FirstName}";
        }
    }

    public class PrintPerson
    {
        public void Print(FullNameToString fullNameToString,Person person)
        {
            string result=fullNameToString(person);
            Console.WriteLine(result);
        }
    }
}
