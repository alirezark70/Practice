using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutshelBool
{
    public class CSharpExample: IExampleLogger
    {
        public void NondestructiveMutationForAnonymousypes()
        {

            //در سی شارپ 10 اضافه شده است
            //با استفاده از این کلمه کلیدی می توان مقدار جدید را به شی که قبلا ساخته شده است اضافه کنیم
            var a1 = new { a = 1, b = 2, c = 3, d = 4, e = 5 };

            var a2 = a1 with { e = 10 };


            //برای اینکه برای کلاس از این روش استفاده کنیم باید از 
            //record
            //در زمان ایجاد کلاس اصلی استفاده کنیم
            var person = new PersonRecordNutshel { Id = 1, Name = "Alireza" };

            var newPerson = person with { Age = 10 };


            Console.WriteLine(a2);
        }

       public void Example()
        {

        }
        public void NewDeconstructionSyntax()
        {
            var point = (3, 4);

            double x = 0;

            (x,double y) = point;

            string first = $"{x}";

            string secend = $"{y}";

            Console.WriteLine(first +" "+ secend);
        }


        public void PatternMatchingImprovements()
        {
            string GetStatus(int sts) => sts switch
            {
                > 15 => Status.High.ToString(),
                < 15 => Status.Normall.ToString(),
                > 9 => Status.low.ToString(),
                
            };
            
        }


        public void Documention()
        {
            //برای استفاده از کلمات کلیدی که در سی سارپ رزرو شده است از اتساین استفاده می کنیم
            //test
            var @using = 4;

            var @public = @using;

            var @add= @public;
            /////////////////
            ///

        }
    }


    public record class PersonRecordNutshel
    {


        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    public enum Status
    {
        low,
        Normall,
        High
    }


    /// <summary>
    /// با اینترفیس که بدنه داریم می توانیم مواردی که مشترک اسست یا هر چیزی استفاده کنیم
    /// ولی برای استفاده از این ویژگی 
    /// این باید به وسیله یک کلاس پیاده سازی بشه 
    /// </summary>
    public interface IExampleLogger
    {
        
        void ExampleLog(string message)
        {
            Console.WriteLine(message);
        }
    }

}
