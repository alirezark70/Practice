using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage271Until350
    {

    }


    public class CalculateHelper
    {
        private Stopwatch? _watch;
        protected void StartWatch()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
        }

        protected void StopAndWriteLineWatch()
        {
            _watch?.Stop();

            Console.WriteLine(_watch?.ElapsedMilliseconds);
        }



    }

    //35481

    #region EndCoding
    //بهترین فرمت برای نوشتن و فایل های نوشتاری
    //utf-8
    //می باشد
    #endregion


    #region TimeSpan
    public class TimeSpan
    {
        //اختلاف بین دو ساخت را می توان محاسبه کرد
    }
    #endregion


    #region DateTimeOffset
    //دقیقا شبیه
    //DateTime
    //می باشد فقط موارد ساعت جهانی هم محاسبه می کند

    public class DateTimeOffsetClass
    {
        void TestMethod()
        {
            DateTimeOffset date = new DateTimeOffset(2023, 8, 10,0,0,0, System.TimeSpan.Zero);
        }
    }
    #endregion


    #region DateTime Vs DateTimeOffset
    //وقتی میخواهیم 2 رویداد بین الملی را بررسی کنیم که کدام جدید تر است از 
    //dateTimeOffset 
    //استفاده می کنیم 

    //وقتی میخواهیم بر روی تاریخ و ساعت سیستم جاری خودمان کار کنیم از 
    //DateTime 
    //معمولی استفاده می کنیم
    //برای مثال میخواهیم بگوییم هر یک ساعت یک اسکژولی کار کند
    #endregion

    #region Calclate Execution Time
    public class CalcExecutedTime
    {

        void TestMethod()
        {
            //وقتی میخواهیم یک علمکرد را محاسبه کنیم از کد زیر استفاده می کنیم

            var watch=System.Diagnostics.Stopwatch.StartNew();

            int a = 20;
            int b = 30;

            watch.Stop();

            var result = watch.ElapsedMilliseconds;
            short c =(short)(a+b);
        }
    }
    #endregion


    #region Time zone
    public class TimeZoneExample
    {
        [Obsolete]
        public void TestMethod()
        {
            TimeZone zone = TimeZone.CurrentTimeZone;


        }
    }
    #endregion


    #region ToString And Pars
    public class F0rmattingAndParsSample
    {
        //وقتی میخواهیم یک متغییر را به یک رشته تبدیل کنیم می گوییم
        //formatting

        //وقتی میخواهیم یک مقدار را از حالت رشته خارج کنیم میگوییم 
        //pars

    }
    #endregion


    #region Format Provaiders
    public class FormatPRovaidersSample
    {
        public string MakeNoneyFormat(int number)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

            numberFormatInfo.CurrencySymbol = "$$";

            return number.ToString("C", numberFormatInfo);
        }

        public string GetPersianDateTime(DateTime date )
        {
            CultureInfo faIR = new CultureInfo("fa-IR");

            return date.ToString("d", faIR);
        }


        public string GetPersianStrFromDateTime(DateTime dateTime)
        {
            PersianCalendar _pc=new PersianCalendar();

            var value = $"{_pc.GetYear(dateTime)}/{_pc.GetMonth(dateTime)}/{_pc.GetDayOfMonth(dateTime)}";

            return value;

        }
    }


    #endregion


    #region Rounding real to integral conversions
    public class RoundingRealToIntegralConversionsClass: CalculateHelper
    {
       public void Test()
        {
            //ما 2 نوع تبدیل داریم 
            //explicit Cast
            //Convert

            //در این روش مقدار گرد نمی شود و فقط اعشارش حذف می شود
            double lll = 43435.535;
            int result = (int)lll;

            //در این روش مقدار از تابع گرد شدن استفاده می کند و مقادیری که خروجی شده نزدیک
            //ترین عدد به مقدار واقعی قبل تبدیل می باشد
            int result2 = Convert.ToInt32(lll);
        }
    }

    #endregion


    #region Dynamic Conversions
    public class DynamicConversionsClass
    {
        public void ChangeType()
        {
            //زمان های است که ما نمی دانیم تایپ ما تا لحظه اجرا چیست
            //با استفاده از روش زیر
            //در زمان اجرا تایپ را می توانیم کنترل کنیم تغییر دهیم یا نوع تایپ را مشخص نماییم
            Type targetType=typeof(int);

            object source = "43";

            object result=Convert.ChangeType(source,targetType);

            
        }
    }
    #endregion


    #region Globalization 
    public class GlobalizationClass
    {
        //می تواند رشته یا ساعت در فرهنگ های محتلف تغییر کند و عملکرد درست سیستم
        //را با مشکل مواجه سازد

        public void Test()
        {
            //فرهنگ سیستم کاربر را می توان استخراج کرد
            var result=Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture=CultureInfo.GetCultureInfo("IR-fa");

            var time = DateTime.Now;
        }
    }
    #endregion
}
