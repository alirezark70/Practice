using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    interface TestInterface
    {
        //مقدار دهی محلی در اینترفیس امکان پذیر نیست و خطای کامپایلری میدهد
        // int x = 4;  // Filed Declaration in Interface  

        //متد ابستراکت نمی تواند بدنه داشته باشد
        abstract void setName(string name);

   
    }

   public abstract class TestAbstractClass:TestInterface
    {
        //در ابستراکت کلاس می تواند هرچقدر میخواهیم وریبل محلی داشته باشیم
        //کلاس ابستراکت می تواند سازنده داشته باشد ولی اینترفیس نمی تواند

        int i = 4;
        int k = 3;
        public abstract void getClassName();

        //متد های ابستراکت باید کلمه کلیدی ابستراکت را داشته باشند یا بدنه داشته باشند
   

        public void setName(string name)
        {
            throw new NotImplementedException();
        }

        //Abstraction in C# is the process to hide the internal details and show only the functionality
        //ابستراکت برای پنهان کردن کد و فقط نمایش عملکرد می باشد
    }
    public class TestCodeClass : TestAbstractClass
    {
        public override void getClassName()
        {
            throw new NotImplementedException();
        }

        
    }
    public abstract class TestAbstract
    {
        public abstract void TestMethod();
    }

    public class TestClass:TestAbstract
    {
        public override void TestMethod()
        {
            Console.WriteLine("TT");
        }
    }

    public abstract class Animal
    {
        public abstract void MakeSound(); // این متد باید در کلاس‌های مشتق شده پیاده‌سازی شود  
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!"); // پیاده‌سازی متد abstract  
        }
    }

    class Program
    {
        static void Main()
        {
            // Animal animal = new Animal(); // خطا: کلاس abstract قابل نمونه‌سازی نیست  

            Animal dog = new Dog(); // یک نمونه از Dog (کلاس مشتق شده) ایجاد می‌شود  
            dog.MakeSound(); // فراخوانی متد پیاده‌سازی شده در کلاس مشتق شده  
        }
    }

    // Interface تعریف قرارداد بدون منطق  
    public interface IFlyable
    {
        void Fly();
    }

    // Abstract Class با تعریف منطق پیش‌فرض برای کلاس‌های مشتق شده  
    public abstract class Bird
    {
        public abstract void MakeSound(); // متد Abstract که باید در زیرکلاس پیاده‌سازی شود  

        public virtual void Sleep()
        {
            Console.WriteLine("Sleeping..."); // متد Virtual با پیاده‌سازی پیش‌فرض  
        }
    }

    public class Sparrow : Bird, IFlyable
    {
        public override void MakeSound()
        {
            Console.WriteLine("Chirp Chirp!"); // پیاده‌سازی متد abstract  
        }

        public void Fly()
        {
            Console.WriteLine("Sparrow is flying!"); // پیاده‌سازی متد Interface  
        }
    }

    class Program2
    {
        static void Main()
        {
            Sparrow sparrow = new Sparrow();
            sparrow.MakeSound(); // صدای پرنده  
            sparrow.Sleep(); // منطق پیش‌فرض در کلاس Abstract  
            sparrow.Fly(); // متد Interface  
        }
    }
}
