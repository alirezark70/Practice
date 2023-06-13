using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class QueryExecuting
    {
        List<int> numbers = new List<int> { 1, 2, 3, 6, 7, 8, 9, 10 };
        //ما دو مدل اجرای کوئری لینک داریم که به شرح زیر است

        //1- Diferred Query Executing
        //2-Immediat Query Executing

        //در حالت اول کوئری اجرا نمیشه و فقط کوئری را در یک مقدار محلی نگه میداریم تا زمان اجرا 
        // در دومی در لحظه اجرا میشه که به شرح زیر است

        public void DiferredQueryExecuting()
        {
            var result = from a in numbers select a;
            //تای ایجا کوئری اجرا نشده

            foreach(var item in result)
            {
                //در اینجا اجرا میشه
                Console.WriteLine(item);
                //هنوز مقادیر ادد شده اضافه نشده
            }
            numbers.Add(4);
            numbers.Add(5);

            foreach(var item in result)
            {
                //مقادیر اضافه شده در آخرلیست اضافه شده است
                Console.WriteLine(item);
            }
        }

        public void ImmediatQueryExecuting()
        {
            //در خط پایین بعد از اضافه کردن تو لیست کوئری اجرا شده 
            var result=(from a in numbers select a).ToList();
        }
    }
}
