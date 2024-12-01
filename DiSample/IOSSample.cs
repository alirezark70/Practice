using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSample
{
    public class IOSSample
    {
        //IOS
        //Inversion Of controll
        //معکوس سازی وابستگی
        //یعنی یک کلاس مشخص وظیفه نمونه سازی را بر عهده میگیره

    }

    public class CalssA
    {
        public void PrintName(string name)
        {
            //این روش معمولی نمونه سازی می باشد
            var print = new Printer();
            print.Print(name);
              
            
            //ولی برای اجرای 
            //ios  
            //بدین روش استفاده می کنم

            var printFactory=PrintFactory.Create();

            printFactory.Print(name);
        }
    }

    public class PrintFactory
    {
        public static Printer Create()
        {
            return new Printer();
        }
    
    }

    public class  Printer
    {
        public void Print(string name)
        {
            Console.WriteLine(name); 
        }
    }
}
