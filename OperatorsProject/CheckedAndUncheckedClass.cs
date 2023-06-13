using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsProject
{
    public class CheckedAndUncheckedClass
    {
        //به صورت پیش فرض سر ریز دیتا در سی شارپ چک نمی شود 
        // ما اگر بخواهیم این کار را انجام بدیم برای سیستم سربار زیادی میزاره و بهتره اگر نیاز واجبی نداره فعال نکنیم
        //میشه هم تیکه کد چک کرد و هم در کل پروژه تیکش بزنی فعال بشه
        //برای چک کردن قسمتی از کد به شکل زیر عمل می کنیم

        public void CheckedMethod()
        {
            checked
            {
                char charValue = char.MinValue;

                char b = charValue++;
            }

            //یا بدین شکل استفاده کنیم
            char checkOther = char.MaxValue;
           char c= checked(checkOther++);

            //یا اگر در کل سیستم فعال کردیم و خواستیم در قسمتی چک نشود بدین شکل عمل میکنیم
            unchecked
            {
                char d = c++;
            }

        }
    }
}
