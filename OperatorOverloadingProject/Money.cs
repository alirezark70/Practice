using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloadingProject
{

    /// <summary>
    /// وقتی ما بخواهیم بر روی عملگرها سربار گذاری کنیم بدین شکل عمل می کنیم
    /// برای مثال ما یک موجودیت پول داریم که میخواهیم دوتا کلاس را باهم جمع کنیم برای اینکار بدین صورت عمل می کنیم
    /// </summary>
    public class Money
    {
        private readonly int _value;
        public Money(int value)
        {
            _value = value;
        }

        public int Value { get => _value; }

        //بدین وسیبه یک متد استاتیک نوشتیم و برای عملگردهای منفی و مثبت سربار گذاری را انجام دادیم
        public static Money operator +(Money right,Money left)=> new Money(right.Value + left.Value);
        public static Money operator -(Money right,Money left)=> new Money(right.Value - left.Value);


        #region Equal Object with operator 

        //اگر از کلاس های که از آبجکت ارث بری کردند نمونه سازی کنیم و با مقدار یکسان با هم 
        //equal 
        //قرار بدیم میگه که اینا با هم برابر نیستن 
        // برای حل این مشکل می توانیم برابر یا نا برابر را سر بار گذاری کنیم
        public static bool operator ==(Money left,Money right)=>
            right.Value == left.Value;
        public static bool operator !=(Money left, Money right) =>
            !(left == right);
        #endregion
    }
}
