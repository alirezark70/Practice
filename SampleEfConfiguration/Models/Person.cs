using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.Models
{
    //کلاس انتیتی حتما باید پابلیک باشد
    //کلاس انتیتی نباید استاتیک باشد
    //پروپرتی ها می تونه ستر پابلیک نداشته باشد ولی حتما باید گتر پابلیک داشته باشد

    public class Person
    {
        public Person(string firstName)
        {
            FirstName = firstName;
        }

        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? IsActive { get; set; }

        public int Age { get; set; }

        public string GetStringAge { get; set; }

        public PersonType PersonType { get; set; }
    }

    public enum PersonType
    {
        Woman,
        Man
    }
}
