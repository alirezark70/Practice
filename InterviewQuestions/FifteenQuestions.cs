using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class FifteenQuestions
    {
        #region Boxing And Unboxing

       
        public void BoxingAndUnboxing()
        {
            //Boxing
            //وقتی یک داده را به مرجع منتقل می کنیم بهش می گوییم باکسینگ
            int a = 123;
            object b = a;

            //وقتی یک مدل را به از مرجع به حالت دیگر تبدیل می کنیم بهش میگیم آنباکسینگ
            object c = 12334;
            int d = (int)c;

           
        }

        #endregion


        #region Class And Struct


        struct Location
        {
            public int x, y;
            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public void WhenItBeStruct()
        {
            Location a = new Location(20, 20);
            Location b = a;
            a.x = 100;
            System.Console.WriteLine(b.x);

            //مقدار ب همان 20 می باشد
        }


        class LocationClass
        {
            public int x, y;
            public LocationClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public void WhenItBeClass()
        {
            LocationClass a = new LocationClass(20, 20);
            LocationClass b = a;
            a.x = 100;
            System.Console.WriteLine(b.x);

            //در کلاس وقتی ما مقدار 100 را دادیم حتی بعد از اینکه ب را با آ برابر کردیم ولی باز مقدار ب تغییر کرد
        }
        public void WhatIsDiffirentBetweenClaasAndStruct()
        {
            //class is system.object but struct is value type
            //کلاس می تواند از ابستراکت ارث بری کند ولی استراکت نمی تواند
            //کلاس می تواند سازنده داشتته باشد ولی استراکت نمی تواند
            //استراکت را نمی توان از نوع دیگر به ارث برد
            //
        }


        #endregion


        #region Const And ReadOnly

        public class ConstExample
        {
            //کانست باید در قسمت تعریف مقدار دهی شود و هیچ وقت دیگر نمی شود مقدارش را تغییر داد
            private const int i = 1;
        }

        public class ReadOnlyExample
        {
            //در رد اونلی می شود در محل تعریف مقدار نداد
            //فقط در سازنده مقدار میگیرد و دیگر مقدار را نمی شود تغییر داد
            private readonly int i;
        }
        #endregion


        #region Ref And Out
        //وقتی از کلمات کلیدی رف و اوت استفاده نکنیم مقدار به صورت 
        //value type 
        // به متد ارسال می شود و تغییر در بدنه متد باعث تغییر در مقدار آرگومان نمی شود
        //ولی با استفاده از این کلمات کلیدی می تواند رفرنس را ارسال کرد و با تغییر که در بدنه متد ایجاد می شود
        //مقدار اولیه هم تغییر کند


        //تفاوت 
        //ref and out
        //در هر صورت مقدار ارگومانی که از این کلمات کلیدی استفاد می شود رفرنس ارسال می شود ولی یک تفاوت اصلی دارند
        // وقتی ما میخواهیم مقداری را ارسال کنیم از رف استفاده می کنیم
        //ولی اگه بخواهیم جواب از داخل بدنه متد ارسال گردد و قبل این ما مقداری را نداریم از اوت استفاده می کنیم
        public class TestRef
        {
            //در سی شارپ می توانیم با کلمات کلیدی رف و اوت آرگومان ها را به رفرنس ارسال کنیم
            //در رف باید متغییری که ارسال می شود مقدار داشته باشد
            //در اوت نیازی نیست و فقط تعریف متغییر کفایت می کند
            public static string GetNextName(ref int id)
            {
                string returnText = "Next-" + id.ToString();
                id += 1;
                return returnText;
            }
            public void Execute(ref int i)
            {
                int e = 1;
                Console.WriteLine("Previous value of integer i:" + e.ToString());//result : 1
                //هر تغییر که در بدنه متد زیر بر روی متغییر 
                //e
                //ایجاد شده است در بنده متد زیر وقتی به کنترلر بیاد این تغییر منعکس شده است
                string test = GetNextName(ref e);
                Console.WriteLine("Current value of integer i:" + e.ToString());//result : 2


            }
        }

        public class TestOut
        {
            public static string GetNextNameByOut(out int id)
            {
                id = 1;
                string returnText = "Next-" + id.ToString();
                return returnText;
            }

            public void Execute()
            {
                int i = 0;
                Console.WriteLine("Previous value of integer i:" + i.ToString());
                string test = GetNextNameByOut(out i);
                Console.WriteLine("Current value of integer i:" + i.ToString());
            }
        }
        #endregion
    }
}
