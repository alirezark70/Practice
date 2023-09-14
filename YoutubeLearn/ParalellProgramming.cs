using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeLearn
{
    internal class ParalellProgramming
    {
        List<string> data=new List<string>() { "Alireza","Sommaye","Abbas","Saeed","Javad","Mohamaad"};

        //برای اینکه بتوانیم مقدار را به صورت همزمان همه باهم پروسس کرد اینکار را انجام میدهیم

        public async void Execute()
        {
            var taskList=new List<Task>();
            ConvertData convertData = new ConvertData();
            foreach (var item in data)
            {
                //لیستی از تسسک ها را میسازیم و اجرا می کنیم
               var task= convertData.Convert(item);

                taskList.Add(task);
            }

            //این کد هم باعث میشه تسک ها در پس زمینه کار بکنند
            //فقط با ایسینگ ننوشتیم که منتظر اتمام نباشه
            _ = Task.Run(async () =>
            {

                //با این کد همه تسکت ها باهم اجرا می شوند و منتظر نمی مونه تا تسک اول تموم بشه
                await Task.WhenAll(taskList);
            });
           

        }

        public async Task PrintMessage()
        {
            
            while (true)
            {
               await Task.Delay(1000);
                Console.WriteLine("I Am Working");
            }
        }
    }


    public class ConvertData
    {
        public async Task Convert(string data)
        {
           await Task.Delay(5000);
            Console.WriteLine("Convert Data");
            //Convert Example
        }
    }
}
