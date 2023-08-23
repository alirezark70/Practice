using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


    #region Length and Rank
    //لنت طول یک آرایه را برمیگرداند
    //رنک rank تعداد بعدهای یک آرایه را برمیگرداند
    #endregion




    #region Searching
    public class SearchingArrayClass
    {
        public void Prossess()
        {
            string[] names = { "Alireza", "Soo", "Mohammad", "Ali" };

            string match = Array.Find(names, n => n.Contains('a'));
        }
        
        
    }

    #endregion


    #region Predicate<T>
    public class PredicateClass
    {
        //پردیکیت هم یک نوع دلیکیت و اکشن است
        //یک ورودی می گیرد و یک خروجی از نوع 
        //bool
        //برمیگرداند

        private Predicate<string>? checkContains;

        public static bool Containsaaaa(string input)
        {
            return input.Contains("a");
        }


        public void ExampleMethod()
        {
            checkContains = Containsaaaa;

            string[] names = { "Alireza", "Soo", "Mohammad", "Ali" };

            string match = Array.Find(names, checkContains);
        }
    }
    #endregion


    #region Collection - Copying
    public class CopyingClass
    {
        //ما 4 نوع کپی داریم
        //clone
        public void CloneExample()
        {
            int[] arr = { 1, 2, };

            //اگر ما از کلون استفاده کنیم یک مقدار جدید ایجاد می شود
            var copyArr = arr.Clone();
        }


        public void CopyAndCopyToExample()
        {
            //copyto and copy
            //یک کپی از زیر مجموعه پیوسته از آرایه ایجاد می کند

            int[] arr = { 1, 2, };

            arr.CopyTo(arr, 0);
        }
    }
    #endregion


    #region Converting And Resizing
    public class ConvertingAndResizing
    {
        //متد کانورت یه شکل زیر می باشد
        //public delegate TOutput Converter<TInput,TOutput> (TInput input)

        public void ExampleMethod()
        {
            float[] arr= { 1.2f, 2.1f,3.9f };

            int[] result = Array.ConvertAll(arr,r=>Convert.ToInt32(r));
            //result is {1,2,4}
        }
    }
    #endregion
}
