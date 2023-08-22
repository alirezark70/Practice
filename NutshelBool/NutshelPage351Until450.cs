using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    internal class NutshelPage351Until450
    {
    }


    #region The ICollection And IList Interface
    //شمارشگرهای 
    //IEnumerable And IEnumerator
    //فقط شمارشگر رو به جلو هستند و امکانات زیر را ارائه نمی دهند
    //امکان اندازه گیری تعداد کالکشن
    //امکان کار  و دسترسی بر روی ایندکس معین
    //امکان جستجو در کالکشن

    //بهترین کالکشن های در نظر گرفته شده برای کار بر روی ایندکس و ...
    //ICollection and IList and IDictionary


    //IList<T>
    //بهتر و کاربردی تر از 
    //ICollection
    //می باشد


    #endregion



    #region IList<T> and IList
    public class IListTAndIListClass
    {

    }

    #endregion


    #region Array Class
    //آرایه یک رفرنس تایپ می باشد که از قوانین رفرنس تایپ ها هم پیروی می کند
    //یعنی دو مقدار شبیه هم باهم برابر نیستند چن رفرنس های مرجع متفاوتی دارند

    public class ArrayClass
    {
        void TestArray()
        {
            var arrayList = Array.CreateInstance(typeof(string), 3);

            arrayList.SetValue("Alireza", 0);


            string[] s1 = (string[])arrayList;

        }
    }

    #endregion
}
