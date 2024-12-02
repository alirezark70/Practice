using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSample
{
    internal class DiSample
    {
        //Dependency Inversion 
        //این قانون میگه ماژول سطح بالا که خدمات میگیره نباید وابسته به ماژول سطح پایین خدمات دهنده باشد
        //برای حل این مشکل از قراردادها استفاده می کنیم

    }

    public interface IUser
    {
        Task AddUser(string username);
    }

    public class User : IUser
    {
        //این کار باعث میشه ما متعهد به قراردادمون باشیم و بتوانیم ماژولار کار بکنیم
        //بهترین مزیت این کار این است که می توانیم تست پذیری را راحت پیاده سازی کنیم
        public Task AddUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
