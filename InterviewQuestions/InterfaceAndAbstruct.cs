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
}
