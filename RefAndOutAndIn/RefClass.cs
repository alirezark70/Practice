using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndOutAndIn
{
    public class RefClass
    {
        public void Caller()
        {
            // وقتی ما یک متغییر محلی درست می کنیم یک خونه در 
            //stack
            //ایجاد میشه و وقتی این مقدار در یک پارامتر یک متد کپی میشه یک خونه جدید درست می کنه 
            //وقتی ما بخواهیم همون خونه را انتقال بدیم از 
            //ref
            //استفاده می کنیم 
            // در مثال پایین مقدار 
            //myValue
            //وقتی به متد دادیم تغییر میکنه 
            //خود مقدار فرستاده به متد با کلمه کلیدی
            //ref
            int myValue = 1;
            Console.WriteLine(myValue);
            Calee(ref myValue);
            Console.WriteLine(myValue);
        }

        public void Calee(ref int inputValue)
        {
            inputValue++;
        }
    }

    public class OutClass
    {
        //کلمه کلیدی 
        //Out
        //هم مثل قبلی ref
        //است و با این تفاوت که کلمه کلیدی رف باید اول اینیشیال کنید و یک مقدار بدهی ولی کلمه کلیدی
        // out
        //نیازی نیست که اول مقدار داشته باشد 
        //ولی داخل متد باید مقدار تغییر داده یا مقدار جدیدی اساین بشه بهش
        public void Caller()
        {
            int myValue = 1;
            Calle(out myValue);

        }
        public void Calle(out int inputValue)
        {
            inputValue = 1;
        }
    }

    public class InClass
    {
        //in
        //مقداری که به متد میدیم نباید تغییر کنه و کد نمیزاره که تغییر کنه
        public void Caller()
        {
            int myValue = 1;
            Callee(in myValue);
        }
        public void Callee(in int inputValue)
        {

        }
    }
}
