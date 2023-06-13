using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class ExceptionThreadsClass
    {
        public void Execute()
        {
            Thread thread=new Thread(ThreadStartPoint);
            thread.Start();

            Console.Read();

        }

        public void ThreadStartPoint()
        {
            try
            {
                BadMethod();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception!!!!");
            }
        }


        public void BadMethod()
        {
            throw new Exception("Bad Method Exception");
        }
    }
}
