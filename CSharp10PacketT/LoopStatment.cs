using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityProject.Help;
namespace CSharp10PacketT
{
    public class LoopStatment:LearningHelp
    {
        

        public void Excute1()
        {
            string[] names = new string[] { "Alireza", "Sommaye" };


            IEnumerator e= names.GetEnumerator();

            while (e.MoveNext())
            {

            }
        }

        public void ExcutePage147()
        {
            long a = 10;

            int b =(int) a;


            long c=long.MaxValue;

            int d = (int)c;

        }



        public void ExcutePage148()
        {
            double[] doubles = new[]
{ 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
            foreach (double n in doubles)
            {
                WriteLine($"ToInt32({n}) is {System.Convert.ToInt32(n)}");
            }
        }
    }
}
