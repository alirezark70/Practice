using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBooK
{
    internal class NutshelPage151Until200
    {
    }

    #region Type Parameters And Conversions

    public class TypeParametersAndConversions
    {
        public StringBuilder Foo<T>(T arg)
        {
            //if(arg is StringBuilder)
            //    return (StringBuilder)arg;//اگر کد را اینگونه بنویسیم ابهام ایجاد می شود 

            StringBuilder stringBuilder=arg as StringBuilder;
            if (stringBuilder!=null)
            {
                return stringBuilder;
            }
            return null;
            //انواع تایپ ها و تبدیل ها در زمان کامپایلر مشخص می شود
        }


        public int Foo2<T>(T arg)
        {
           //وقتی ما میخواهیم یک مدل جنریک را به یک ولیو تایپ تبدیل کنیم تبدیل انباکسین هم با ابهام مواجه است
           //بهتر است به آبجکت تبدیل کنیم سپس به یک ولیو تایپ تبدیل اش کنیم

            return (int)(object)arg;
        }
    }


    #endregion


    #region Covariance
    
    public class CovarianceExample
    {
        class Animal
        {

        }
        class Bear:Animal
        {

        }
        class Camel:Animal
        { }


        class Stack<T>
        {
            int position;
            T[] data = new T[100];

            public void Push(T arg) => data[position++] = arg;

            public T Pop() => data[--position];

        }

        class ZooCleaner
        {
            public static void Wash(Stack<Animal>animals)  //Compailer Time Error
            { 
            }

            public static void WashWithoutError<T>(Stack<T> animals)where T :Animal//این خط باعث می شود ما با ابهام کوواریانس مواجه نشویم
            {

            }
        }

        void ExampleMethod()
        {
            Stack<Bear>bears = new Stack<Bear>();
            //Stack<Animal> animals = bears;//این خط خطا میدهد و دلیل خطا هم کوواریانس است

            //animals.Push(new Camel());//تلاش برای ریختن مدل شتر درون مدل پرنده ها

            //ZooCleaner.Wash(bears);//این خط خطا دارد و دلیل خطا هم کوواریانس می باشد 
            //برای رفع ابهام باید یک محدودیت 
            //Parameters Constraint 
            //اضافه کنیم

            ZooCleaner.WashWithoutError(bears);

            //راه حل دیگری هم وجود دارد به نام
            //out Parameters
            //که با کلمه کلیدی
            //out
            //در پارامتر کار می کند
            //این شیوه اولویت ندارد
        }
    }

    #endregion

    #region Contravariance تضاد
    //اگر تبدیل ها به صورت برعکس انجام شود 
    //تضاد رخ می دهد
    #endregion


    #region Chapter 4


    #region Delegates
    //دلیگیت نماینده ای است که یک متد را صدا میزند
    //باید پارامترها و خروجی مانند متدی باشد که فراخوانی می کند

    public class DeletageExample
    {
        //خروجی متد باید اینتیجر باشد و پارامتر هم یک عدد اینت
        delegate int Transformer(int x);

        int Square(int x)
        { return x; }

        void MethodExample()
        {
            //دلیگیت را این گونه به متد بالا متصل کردیم
            Transformer t = Square;

            //فراخوانی بدین شکل است
            //دلیگیت یک اشاره گر یا صدا زننده یک متد است
            int result = t(19);

            //دلیگیت ها متد را در زمان ران تایم صدا میزند

        }

        //یکی دیگر از کاربردهای دلیگیت ها این است که ما بتوانیم یک متد را به عنوان آرگومان به یک متد دیگر پاس بدهیم

        void Trasform(int[] values, Transformer t)
        {
            for(int i=0; i<values.Length; i++)
            {
                values[i] = t(i);
            }
        }
        

    }
    #endregion

    #region Instance And Static Method Targets

    

    public class InstanceAndStaticMethodTargets
    {
        public delegate void progressReporter(int percentComplete);

        class MyReporter
        {
            public string Prefix = "";

            public void ReportProgress(int percentComplete)
            {
                Console.WriteLine(Prefix+ percentComplete);
            }
        }
    }

    #endregion





    #endregion

}
