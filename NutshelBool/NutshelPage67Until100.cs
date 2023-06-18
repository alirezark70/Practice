using System;
using System.Collections.Generic;
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

    }
}
