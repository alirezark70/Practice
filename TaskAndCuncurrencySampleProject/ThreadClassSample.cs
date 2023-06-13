using AdoSample;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TaskAndConcurrencySampleProject
{
    public class ThreadClassSample
    {


        public void PrintStar()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("*");
            }
        }

        public void PrintDash()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("-");
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            
        }


        public virtual void CreateThreadSample()
        {
            Thread dashThread = new Thread(PrintDash);
            dashThread.Name = "Dash Print Name";
            Console.WriteLine($"Dash Print Worker Is Alive Before Start ? {dashThread.IsAlive}");
            dashThread.Start();
            Console.WriteLine($"Dash Print Worker Is Alive Before Start ? {dashThread.IsAlive}");

            PrintStar();
        
        }

    }
}
