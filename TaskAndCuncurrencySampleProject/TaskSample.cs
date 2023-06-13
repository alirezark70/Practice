using AdoSample;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class TaskSample
    {

        public void StartTask()
        {
            //در اجرای تست در ران چون در بک گراند انجام میشه و ما براش ویت گذاشتم به کد نوشتن اسم  خودم نمیرسم
            //چون قبل از اینکه ترد برسد ترد فورگراند کارشو تموم کرده و تسک بسته
            Task.Run(() => PrintName());
            Console.WriteLine("Finished");

        }

        public void PrintName()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Alireza Rezaee");
        }

        public void StartLongRunning()
        {
            //وقتی ما یک کاری داریم که طولانیه و میبایست ای او باند باشه از 
            //Task Factory
            // به شیوه زیر استفاده می کنیم
            //و میگیم که این به مدت زمان زیادی نیاز دارد 
            //در این روش از ترد پول دیگه ترد نمیگیره و یک فرگراند تست می باشد
            Task result = Task.Factory.StartNew(() => PrintName(), TaskCreationOptions.LongRunning);
        }

        public void StartColdTask()
        {

            Task result = new Task(PrintName);

            //در این روش باید دستی ران کنیم تست را
            result.Start();

            result.Wait();

            //صبر می کنه که تست کارش تموم بشه



        }
    }

    public class ContinuationsTaskSample
    {
        public void Start()
        {
            Task<int> sumResult = Task.Run(() => SumNumber(100, 399));
            //در کد زیر بعد از اینکه به مدت 5 ثانیه متوقف شد عملیات با فراخواندن 
            //wait
            //عملیات منتظر می مونه و بعد از اتمام به خط بعدی که 
            //Finished
            //هست میره و اون اجرا می کنه
            sumResult.Wait();

            Console.WriteLine($"Sum Result is {sumResult.Result}");
            Console.WriteLine("Finished");

            Console.ReadLine();
        }

        public void StartAwaiter()
        {
            Task<int> sumResult = Task.Run(() => SumNumber(100, 399));

            //var awaiter = sumResult.GetAwaiter();


            //در این جا با استفاده از این روش فرایند ادامه پیدا می کنه و خط بعدی اجرا میشه 
            //بعد از تموم شدن کار ترد جواب اجرا و اعمال میشه
            ExecuteAwaiter<int>(sumResult.GetAwaiter());

       
            Console.WriteLine("Finished");

            Console.ReadLine();
        }


        public void StartContinueWith()
        {
            //این هم روش دیگر اجرای موازی می باشد
            Task<int> resultSum = Task.Run(() => SumNumber(100, 299));

            resultSum.ContinueWith(t => Console.WriteLine($"Sum After Result{t.Result}"));

            Console.ReadLine();
        }

        public void ExecuteAwaiter<T>(TaskAwaiter<T> input)
        {
            input.OnCompleted(() =>
            {
                var result = input.GetResult();
                Console.WriteLine($"Result is {result}");
            });
        }

        public int SumNumber(int num1,int num2)
        {
            Thread.Sleep(5000);
            return num1 + num1;
        }
    }
}
