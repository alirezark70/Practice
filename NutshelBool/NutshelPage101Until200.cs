using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace NutshelBooK
{
    public class NutshelPage101Until200
    {
    }

    #region Static Constractur
    public class Person
    {
        private string _firstName;
        private string _lastName;
        public Person(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }
    }

    public class Child : Person
    {
        private static int _maximumAge;
        private int _age;
        public Child(string firstName, string lastName, int age) : base(firstName, lastName)
        {
            _age = age;
        }
        //موارد استفاده از سازنده ثابت
        static Child()
        {
            _maximumAge = 18;
        }

        public void AgeChecker()
        {
            if (_age > _maximumAge)
            {
                WriteLine("This Chiled More Than 18");
            }
        }
    }
    #endregion


    #region Property
    public class PropertyExample
    {
        private decimal _x;

        public decimal X
        {
            get { return _x; }
           private set { _x = Math.Round(value,2); }
        }
    }
    #endregion

}
