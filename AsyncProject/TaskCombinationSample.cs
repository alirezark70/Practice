using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProject
{
    public class TaskCombinationSample
    {
        //با این روش می توان ترتیب تعالی اجرای دستورات و تسک ها را کنترل کرد
        public async Task Start()
        {

            var taskAfter3= PrintAfter3Sec();
            var taskAfter4 = PrintAfter4Sec();
            var taskAfter5 = PrintAfter5Sec();

            //وقتی که تمام تسک ها عملیات اجرا شدن ترد را ببند
           await Task.WhenAll(taskAfter3,taskAfter4, taskAfter5);

            //در اینجا وقتی هر کدوم از تسک ها کار را انجام دادن دیگه اینجا وای نمیسته و ادامه میده 
            //یعنی منتظر بقیه نمیشه
            await Task.WhenAny(taskAfter3, taskAfter4, taskAfter5);
        }

        public async Task PrintAfter1Sec(string message,CancellationToken cancellationToken)
        {
            await Task.Delay(1000);
            Console.WriteLine(message);
        }

        public async Task PrintAfter3Sec()
        {
           await Task.Delay(3000);

            Console.WriteLine("Print After 3 Secend");
        }
        public async Task PrintAfter4Sec()
        {
            await Task.Delay(4000);

            Console.WriteLine("Print After 4 Secend");
        }

        public async Task PrintAfter5Sec()
        {
            await Task.Delay(5000);

            Console.WriteLine("Print After 5 Secend");
        }
    }
}
