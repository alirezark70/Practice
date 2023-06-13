using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedConversionsProject
{
    /// <summary>
    /// بعضی وقتا ما میخواهیم تایپ های که شخصی خودمون هستند تبدیل انجام دهیم 
    /// برای این کار از روش
    /// User Defined Converstion 
    /// استفاده می کنیم 
    /// اگه دیتا از دست ندهیم از
    /// implicit
    /// استفده می کنیم 
    /// 
    /// و اگر دیتا از دست میدهیم از 
    /// Explicit
    /// استفاده می کنیم
    /// </summary>
    public class Price
    {
        private  int _price;

        public Price(int price)
        {
            _price = price;
        }

        public int Value 
        {
            get
            {
                return _price;
            }
            set
            {
                _price=value;
            }
        }

        //با این تبدیل ها به راحتی مقدار را به کلاس کست می کنیم
        public static implicit operator  int(Price value)=>value.Value;

        public static explicit operator Price(int value)=>new Price(value);
    }
}
