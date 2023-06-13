using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocument
{
    public class TypeTestClass
    {
        //value type test with pattern matching
        public int CheckList(IEnumerable<int> inputList)
        {
            if(inputList is IList<int> list)
            {
                return list[list.Count / 2];
            }
            else if(inputList is null)
                return 0;


            return 0;
        }

        public interface ITest
        {

        }
        public class Person
        {
            public string Name { get; set; }
            public string FirstName { get; set; }

        }

        //use Switch case with pattern matching
        public string GetColorName(Colors colors) =>
            colors switch
            {
                Colors.Red => "This is Red Color",
                Colors.Green => "This Is Green Color",
                Colors.Gold => "This is Gold Color",
                Colors.White => "This is White Color",
                Colors.Black => "This is Black Color",
                Colors.Blue => "This is Blue Color",
                _ => "Color is Unknows"
            };
    }

    public enum Colors
    {
        Red,
        Green,
        Blue,
        White,
        Gold,
        Black
    }



}
