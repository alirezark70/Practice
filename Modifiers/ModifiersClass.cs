using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modifiers
{
    public class ModifiersClass
    {

        /// <summary>
        /// متد های که 
        /// Protected
        /// باشند فقط کلاس های که از کلاس والد ارث بری کردند می توانند ببینند
        /// </summary>
        protected void TestMethod()
        {

        }


        /// <summary>
        /// Protect Or internal
        /// یا باید از اینستنس ارث بری کرده باشند 
        /// یا داخل همین اسمبلی استفاده شود
        /// </summary>
        protected internal void TestProtectedInternal()
        {

        }

        /// <summary>
        /// Private internal 
        /// private and internal 
        /// یعنی همون 
        /// protected internal 
        /// است ولی به جای یا
        /// و است and
        /// 
        /// </summary>
        //private internal void TestPrivideInternal()
        //{

        //}

    }

    
}
