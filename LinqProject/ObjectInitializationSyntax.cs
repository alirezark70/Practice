using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class ObjectInitializationSyntax
    {
        // Object Initialization Syntax

        //این قایلیت میده که در لحظه ایجاد مقدار دهی کنیم

        Person person = new Person
        {
            FirstName="Alireza",
            lastName="Rezaee"
        };
    }
    public class Person
    {
        public string FirstName { get; set; }

        public string lastName { get; set; }
    }
}
