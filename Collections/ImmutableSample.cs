using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Collections
{
    public class ImmutableSample
    {
        //کالکشن های غیر قابل تغییر هستند 
        //بدین معنی نیست که کلا غیر قابل تغییر باشن یعنی هرکسی هر تغییری بده برای اون یک اینستنس جدید میسازه
        //مناسب محیط های چد نخی می باشد
        //تفاوتش با ReadOnly 
        //این که رید اونلی اگر به اینستنس دست پیدا کنیم قابل تغییر است ولی این به هیچ عنوان غیر قابل تغییر نمی باشد
        public void Test()
        {
            //ما برای همه کالکشن ها یک نوع از نوع ایمیتیبل داریم
            ImmutableList<string> lists =  ImmutableList.Create<string>();
            var result = lists.Add("1");
            Console.WriteLine(lists.Count);//در اینجا مقدار صفر می باشد چون بعد تغییر یک نمونه جدید ساخت و در نمونه قدیم هیچ تغییری ایجاد نشد

            
            Console.WriteLine(result);//در اینجا مقدار 1 می باشد چون 


            //میشه با یک لیست عادی کار شروع کرد و وقتی نیاز به عدم تغییر داشته باشیم به روش زیر لیست را تبدیل کنیم
            List<string> test = new List<string>();
            test.Add("1");
            test.ToImmutableList();
        }
    }
}
