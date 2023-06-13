using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public List<Person> Personal()
        {
            return new List<Person> { new Person { FirstName="Alireza",LastName="Rezaee"},new Person { FirstName="Saeed",LastName="Farzin"} };
        }
    }




}
