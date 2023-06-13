using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class SharedAndLocalStateClass
    {
        private readonly int counter = 10;
        private  int i = 0;//وقتی در این محل مقدار قرار بگیره ترد ها همزمان نمی توانند به درستی کارشون انجام بدن

        public void Start()
        {
            Thread first = new Thread(PrintStar);

            Thread secend=new Thread(PrintStar);

            first.Start();

            secend.Start();

            Console.Read();
        }

        private void PrintStar()
        {
            for (; i < counter; i++)
            {
                Console.Write("*");
            }
        }
    }
}
