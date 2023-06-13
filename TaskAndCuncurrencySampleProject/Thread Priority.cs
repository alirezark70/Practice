using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class Thread_Priority
    {
        //اولیت بندی ترید ها
        //در اینجا فقط اولویت بندی را تعریف کرده ایم

        public void Start()
        {
            Thread T1 = new Thread(() => PrintThread("*"));
            T1.Priority = ThreadPriority.Highest;
            Thread T2 = new Thread(() => PrintThread("-"));

            Thread T3 = new Thread(() => PrintThread("/"));
            T3.Priority = ThreadPriority.Lowest;

            T1.Start();

            T2.Start();

            T3.Start();

        }

        public void PrintThread(string input)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(input);
            }
        }
    }
}
