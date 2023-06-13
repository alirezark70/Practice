using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class JonAndSleepThreadSampleClass: ThreadClassSample
    {
        public override void CreateThreadSample()
        {
            Thread dashThread = new Thread(PrintDash);
            dashThread.Name = "Dash Print Name";
            dashThread.Start();
            //با دستور جوین می گیم که وقتی کار ترد اول تموم شد برو سروقت ترد بعدی
            //ما می تونیم به جوین زمان بدیم و بعد از زمان ترد بعدی اجرا بشه
            //متد جوین یک شرط بول برمیگردونه که میگه کار ترد اول تموم شده یا نه
            //dashThread.Join();

            //dashThread.Join(TimeSpan.FromSeconds(5));

            if (dashThread.Join(TimeSpan.FromMilliseconds(2)))
            {
                PrintStar();

            }


        }


        public void SleepThreadMethod()
        {
            Thread dashThread = new Thread(PrintDash);
            dashThread.Name = "Dash Print Name";
            dashThread.Start();


            //این متد زیر این کار می کنه که به سیستم میگه کار من با تسک تموم شد و کنترل را به سی پی یو می سپاره
            Thread.Yield();


            Thread.Sleep(TimeSpan.FromSeconds(2));  
        }



        public void ThreadStateCheck()
        {
            Thread dashThread = new Thread(PrintDash);

            dashThread.Start();

            Console.WriteLine($"Thread State : {dashThread.ThreadState}");

            Console.WriteLine($"Dash Print worker is {IsBlock(dashThread)}");

        }

        public bool IsBlock(Thread thread)
        {
            //بررسی می کنه که ترد آیا بلاک هست یا نه
            return (thread.ThreadState & ThreadState.WaitSleepJoin) != 0;
        }
    }
}
