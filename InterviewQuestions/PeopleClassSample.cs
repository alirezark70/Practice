using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class PeopleClassSample
    {

        //نمونه ساخته شده برای آموزش مبحث رفلکشن
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public void Print()
        {
            Console.WriteLine("Hello Word");
        }

        public void PrintWithInput(string firstName,string lastName)
        {
            Console.WriteLine($"First Name : {firstName} And Last Name : {lastName}");
        }
    }
}
