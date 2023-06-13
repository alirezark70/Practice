using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    public class InterfaceExample : IDisposable
    {

        public void Dispose()
        {
            Dispose();
        }
    }

    //برای اینکه یک کلاس قابلیت 
    //forach 
    // را داشته باشد باید از اینترفیس
    //IEnumrable 
    //ارث بری کنیم
    public class ClassForach : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    //بخواهیم کلاسی قابلیت مقایسه داشته باشه از این اینترفیس استفاده می کنیم 
    public class ComparableClass : IComparable<ComparableClass>
    {
        //this
        //آبجکت جاری می باشد
        //و
        //other
        //آبجکت ورودی به متد می باشد.
        public int CompareTo(ComparableClass? other)
        {
            //اگر آبجکت جدید کوچک تر باشد باید عدد منفی بدیم
            // اگر مساوی باشد برابر میباشد با صفر
            // و اگر بزرگ تر باشد باید عددی بیشترا ز صفر بهش بدیم
            throw new NotImplementedException();
        }
    }

    public class UsingAboveClass
    {
        public void Test()
        {
            //ما زمانی می تونیم از دستور و کلمه کلیدی
            //using
            //استفاده کنیم که درون کلاسمون از 
            //IDisposable
            //ارث بری کرده باشیم
            InterfaceExample example = new();

            using (example)
            {

            }


            //چون این کلاس از اینترفیس 
            // IEnumrable
            //ارث بری کرده است می تونه خود کلاس تک 
            //forach
            // را پشتیبانی کند
            ClassForach foreachItem = new();

            foreach(var item in foreachItem)
            {

            }    

        }
    }
}
