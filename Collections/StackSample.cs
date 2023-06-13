using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class StackSample
    {
        Stack<string> strings=new Stack<string>();

        public static void Start()
        {
            var test=new StackSample();
            test.AddToStack("1");
            test.AddToStack("2");
            test.AddToStack("3");
            test.AddToStack("4");
            test.GetStackCount();
            Console.WriteLine("*******************");
            test.GetFromStack(test.GetStackCount());

            Console.WriteLine("*******************");


        }

        public void AddToStack(string input)
        {
            //در استک آخری اولی خوانده می شود یعنی دقیقا برعکس صف یا پشته
            strings.Push(input);
        }
      
        private void Test()
        {

        }
        public void GetFromStack()
        {
            Console.WriteLine(strings.Pop());
            
        }

        public void GetFromStack(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(strings.Pop());
            }
        }

        public int GetStackCount()
        {
            return strings.Count();
        }
    }
}
