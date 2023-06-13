using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    //این ساختمان داده بر  برخلاف دیگر لیست ها در داده یک نود هستش که بعدی و قبلی خودشو داره و سرعت درج در این ساختمان
    // داده بیشتر است
    public class LinkedList
    {
        LinkedList<string> listValue=new LinkedList<string>();


        public void AddFirst(string input)
        {
            listValue.AddFirst(input);
        }

        public void AddLast(string input)
        {
            listValue.AddLast(input);
        }

        public void AddSecend(string input)
        {
            //در این لیست با اضافه کم کردن نیازی نیست همه اجزا جاشون عوض بشه 
            //نود در جای خاص خودش قرار میگیره
           listValue.AddAfter(listValue.First,input);   
        }
    }
}
