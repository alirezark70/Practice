using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class ThreadPoolSample
    {
        // Thread Pool 
        // همیشه ساخت ترد هزینه ئ وقت و سربار داره و اگر متد که به ترد پاس داده میشه کمتر از هزینه ساخت ترد باشد ما کار درستی را انجام نداده ایم
        //ترد پول محلیه که تعدادی ترد های آماده به کار در اونجا وجود دارد
        //برای انجام اکشن های کوجک که میخواهیم موازی با برنامه مون انجام بشه از این قابلییت استفاده می کنیم و به راحتی و بدون هزینه ساخت ترد این کار را انجام میدهیم
        // وقتی از ترد پول استفاده می کنیم امکان نامگذاری نداریم
        // ترد پول همیشه بک گراند هستند
        
        public void PrintThreadType()
        {
            var isPool = Thread.CurrentThread.IsThreadPoolThread;//به ما میگه این ترد ساخته شده یا از ترد پول استفاده کردیم

            var isBackGround = Thread.CurrentThread.IsBackground;//میگه این ترد بک گراند هست یا نه

            Console.WriteLine($"Is Pool : {isPool}");
            Console.WriteLine($"Is Background : {isBackGround}");
            Console.ReadLine();
        }

        public void TakeThreadFromThreadPool()
        {
            //با این متد میخواهیم از ترد پول تردون را دریافت کنیم

            Task.Run(() => PrintThreadType());
        }
    }
}
