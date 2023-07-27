using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    public class NutshelPage201Until250
    {
    }

    #region Chapter4

    #region AnonymousType
    class AnonymousTypes
    {
        
    }
    #endregion


    #region Tuples
    class Tuples
    {
        void Example()
        {
            //this is Anonymous Tuple
            var bob = ("Bob", 32,14);

           string name= bob.Item1;
        }
    }
    #endregion


    #region Record
    class RecorExample
    {
        //یک نوع ساختار برای کار کردن با داده فقط خواندنی است
        //کامپایل تایم می باشند

        record Record
        {

        }
    }
    #endregion
    #endregion
}
