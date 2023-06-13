using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaceMethod
{
    /// <summary>
    /// اینترفیس از سی شارپ 8 می تونه بدنه داشته باشه و دلیلش این بود که اگر یک قرارداد تغییر کنه باید همه بروز کنن و 
    /// Breaking Change 
    /// اتفاق می افته
    /// برای حل این معظل برای متد می تونیم متد با بدنه بسازیم که در تغییرات این اتفاق نیفته
    /// </summary>
    public interface IInterfaceHaveBody
    {
        void Print();

        public string PrintName(string name) => $"this name is {name}";
    }
    public class InterfaceHaveBody : IInterfaceHaveBody
    {
        public void Print()
        {
            throw new NotImplementedException();
        }


    }
}
