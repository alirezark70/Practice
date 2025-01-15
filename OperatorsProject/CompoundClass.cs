using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsProject
{
    public class CompoundClass
    {

        public int MathMethod()
        {

            #region operator
            //در کد پایین یک عملگرد مساوی داریم که کارش اینه عملیاتی جلوشه به یه متغییر دیگه تخصیص میده
            //عملکرد جمع هم 2 مقدار را باهم جمع می کنه
            int a1 = 1;
            int a2 = 2;
            int a3 = a1 + a2;


            //What's the Compound 

            int b1 = 1;
            int b2 = 2;

            b1 += b2;
            //در عملیات بالا عملگرد بالا میاد اول جمع می کنه و مقدار را درون 
            //b1 
            //میریزه

            //عملکردهای کامپونس
            a1++;
            b1--;


            //تفاوت های زیر 
            a1++;
            ++a1;


            //در کد زیر ابتدا مقدار بر روی متد زیر اجرا شده و سپس یه مقدار بهش اضافه شده
            Test(a1++);
            //در متد زیر ابتدا یک به متغییر تخصیص داده شده سپس متد اجرا شده
            Test(++a1);
            #endregion



            return 0;
        }

        public void Test(int a)
        {

        }

        public string ConditionalExperssion(int input)
        {
            //thsi is Conditional Experssion
            return input == 0 ? "Ziro" : "Not Ziro";
        }

        private readonly string input;
        public string MethodA(string input)
        {
            return input;
        }


    }
}
