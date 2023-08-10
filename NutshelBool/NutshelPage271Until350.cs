using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage271Until350
    {

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

}
