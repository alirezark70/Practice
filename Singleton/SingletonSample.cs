using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonSample
    {
        //مثال ها در کلاس های زیر زده می شود
    }

    public sealed class NoThreadSafeSingleton
    {
        private NoThreadSafeSingleton() { }
        private static NoThreadSafeSingleton? _instance = null;

        public static NoThreadSafeSingleton Instance
        {
            get
            {
                if( _instance == null )
                    _instance = new NoThreadSafeSingleton();

                return _instance;
            }
        }

    }
}
