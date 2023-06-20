using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           ref string changeFullName=ref GetFullName();

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
            string a=null;

            a ??= "Alireza";
        }

        #endregion
    }
}
