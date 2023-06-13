using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndConcurrencySampleProject
{
    public class LockingClass
    {
        bool allowWrite = true;
        private readonly static object _lock = new object();

        public void PrintStar()
        {
            if(allowWrite)
            {
                lock(_lock)
                {
                    //Method Or Code Us
                    //نحوه لاک کردن یک کد برای ترد

                   allowWrite = false;
                }
            }
        }
    }
}
