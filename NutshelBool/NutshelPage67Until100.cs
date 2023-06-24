using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace NutshelBooK
{
    public class NutshelPage67Until100
    {
        #region Ref Locals

        void TestRefLocals()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5 };

            //ما می توانیم متغییر های که در داخل متد میسازیم با کلمه کلیدی 
            //ref
            //ایجاد کنیم 
            //در این حالت وقتی که مقدار دومی تغییر کرد مقدار شی اشاره شده هم تغییر می کنه
            ref int numbf = ref numbers[1];// result is 1

            numbf = 20; //result is 20

            //مقداری که قبلا 1 بود هم داخل آرایه تغییر کرد
            var r = numbers[1]; //result is 20

        }


        #endregion


        #region Ref Method
        static string fullName = "Alireza Rezaee"; //Values Is Alireza Rezaee -- After Call Change Full Name Is Naser Rezaee
                                                   //ما می توانیم متد های با فرمت ref
                                                   //داشته باشیم 
                                                   //وقتی مقدار پاس داده شده تغییر کند مقدار اصلی هم تغییر می کند

        static ref string GetFullName()
        {
            return ref fullName;
        }

        public void ChangeFullName()
        {
            ref string changeFullName = ref GetFullName();

            changeFullName = "Naser Rezaee";
        }

        #endregion


        #region Operator 

        public void Null_CoalescingAssignmentOperator()
        {

            //این عملکرد میگه اگه مقدار نال بود مقدار جدید را قرار بده
            // یعنی طرف سمت چپ اگه مقدار نداشت مقدار سمت راست را قرار بده
            //این برای 
            //Reference Type 
            //ها قابل انجام است
            string a = null;

            a ??= "Alireza";



        }

        #endregion

        #region Switching On Types
        public void TellMeTheType(object input)
        {
            switch (input)
            {
                case int i:
                    Console.WriteLine($"Type is {i}");
                    break;
                case long l:
                    Console.WriteLine($"Type is {l}");
                    break;
                case string s:
                    Console.WriteLine($"Type is {s.GetType().Name}");
                    break;
            }
        }
        #endregion


        #region Goto 
        public void GoToLoop()
        {
            //با نوشتن کلمه کلیدی
            //goto
            //کاپایلر به قسمت اشاره شده میپره
            int i = 1;
            startLoop: 
            if (i <= 5) 
            {
                Console.Write(i + " "); i++; goto startLoop; 
            }

        }
        #endregion


        #region Checked And Unchecked
        public void CheckedAndUnchecked()
        {
            //برای سرریز مقادیر عددی استفاده می شود
            //checked
            //مقدار را بررسی می کند و در صورت وجود خطا یک خطای سرریز ارسال می کند

            //Unchecked
            //این باعث می شود سرریز نادیده گرفته شود و مقدار منفی شود
            int Multiply(int a, int b) => a * b;

            int factor = 2;

            try
            {
                unchecked
                {
                    Console.WriteLine(Multiply(factor, int.MaxValue));  // output: -2
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                unchecked
                {
                    Console.WriteLine(Multiply(factor, factor * int.MaxValue));
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
            }
        }
        #endregion

        #region Global Using
        public void GlobalAndStatic()
        {
            //ما می توانیم با پیشوند
            //static
            //در 
            //using
            //ها از تکرار کد کلاس های ثابت جلوگیری کنیم
            WriteLine("");
        }
        #endregion
    }


    public class TestInitiazField
    {
        public TestInitiazField(int inputAge)
        {
            
            Age = inputAge;
            
        }
        public int Age = 20;

        //Static Readonly
        //این نوع تعریف فقط در مقدار دهی اولیه قابل مقدار دهی است و در سازنده هم قابل مقدار دهی نیست

        //const vs static readonly
        //کانست ها مقدار از پیش تعریف شده فقط میگیرند مثلا ساعت جاری را هم قبول نمی کنند
        //استاتیک رید اونلی مقدار اولیه داینامیک قبول می کند


       // public const string expireDate=DateTime.Now.ToString();//compiler Error
    }
}






