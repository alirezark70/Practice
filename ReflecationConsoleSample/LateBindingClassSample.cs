using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ReflecationConsoleSample
{
    public class LateBindingClassSample
    {

        public void ActivatorMethodSample()
        {
            //با این متد اسمبلی یک پروژه دیگر را بدون رفرنس دادن بدست میاوریم
            Assembly? loadAssemly = Assembly.LoadFrom(@"C:\Users\email\OneDrive\Source\Practic1401\Practic\InterviewQuestions\bin\Debug\net6.0\InterviewQuestions.dll");

            //تایپ کلاس و مدل را در اینجا بدست میاوریم
            Type? peopleSampleModelType = loadAssemly.GetType("InterviewQuestions.PeopleClassSample");

            //یک اینستنس میسازه از این آبجکتی که اینجا فراخوانیش کردیم
           var peopleModel= Activator.CreateInstance(peopleSampleModelType);

            //متد داخل این آبجکت را فراخوانی کردیم
            MethodInfo? printMethod = peopleSampleModelType.GetMethod("Print");

            MethodInfo? printWithInputMethod = peopleSampleModelType.GetMethod("PrintWithInput");
            //متد را فراخوانی و اجرا کردیم
            //پارامتر اول میگه آبجکت را بهم پاس بده و ما همون آبجکت کلاس را که ایجاد کرده بودیم بهش پاس دادیم
            //در پارامتردوم میگه پارامتر های متد را به من پاس بده
            printMethod.Invoke(peopleModel,null);

            //اینجا متدی که با پارامتر داریم فراخوانی کردیم
            printWithInputMethod.Invoke(peopleModel,new object[]{"Alireza","Rezaee"});

            //پروپرتی های آبجکت را فراخوانی کردیم
            var propertiesPeople=peopleSampleModelType.GetProperties();
            
        }
    }
}
