using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class PersonExtensionMethod
    {
    }

    public interface IPerson
    {

        public string Author { get; }
    }


    public class Person : IPerson
    {
        private readonly string _author;

        public Person(string author = "System")
        {
            _author = author;
        }

        public string Author
        {
            get { return _author; }

        }
    }

    public static class Utility
    {
        public static string GetAuthorName(this IPerson person)
        {
            return person.Author;
        }
    }
}
