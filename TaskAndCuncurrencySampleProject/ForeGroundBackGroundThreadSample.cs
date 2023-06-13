using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class ForeGroundBackGroundThreadSample
    {
        public void Start()
        {
            //ما می توانیم از دستور جوین استفاده کنیم برای اینکه اگر کار ترد بکگراند تموم نشده 
            //ترد فورگراند به کارش ادامه بده تا ترد بک گراند هم کارش به پایان برسه
            Thread thread = new Thread(PrintAndRead);
            thread.IsBackground = true;
            thread.Start();
            Console.WriteLine("Main Thread Finished");
            thread.Join(TimeSpan.FromSeconds(10));
        }
        public void PrintAndRead()
        {
            Console.WriteLine("Please Enter a Word");
            Console.ReadLine();
        }
    }
}
