using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class SetOperationsSample
    {
        private readonly List<Personal> list01;
        private readonly List<Personal> list02;
        public SetOperationsSample()
        {
            list01= GetPersonal01.GetPersonals();
            list02= GetPersonal02.GetPersonals02();
        }

        // Distinct

        public void TestDistinct()
        {
            var result = list02.Distinct();
        }

        // Distinct By
        public void TestDistinctBy()
        {
            //بر اساس کلید خاصی بیاد تکراری ها را پاک کند
            var result = list01.DistinctBy(e => e.NationalCode);
        }
    

        //Union
        public void TestUnion()
        {
            //در یونیون هرچی مشترک میاره یعنی در دولیست باشه 2 تا نشون میده
            var result=list01.Union(list02);
        }

        public void TestUnionBy()
        {
            //وقتی از کلاس ها استفاده می کنیم عملا ما رفرنس میدیم و هیچ وقت باهم برابر نیستن تا اشتراک یا اجتماع بگیریم
            //برای همین از این مدل استفاده می کنیم  یعنی
            //UnionBy
            //و با آیدی میگیم بیا عملیات را انجام بده
            var result=list01.UnionBy(list02, e => e.NationalCode);
        }

        public void TestExcept()
        {
            //مقادیری که در للیست یک وجود دارد و در لیست دو هم وجود دارد فقط یک دفعه نمایش داده میشود
            var result=list01.Except(list02);
        }

        public void TestIntersect()
        {
            //مشترک در هر جدول یک بار نمایش میده
           List<int> number01=new List<int> { 1,2,3,4,5,6 };
            List<int> number02 = new List<int> { 1, 2, 3, 4 };
            var result = number02.Intersect(number01);
        }

        public void TestIntersectBy()
        {

            var reuslt = list01.IntersectBy(list02, e => e);

        }

    }


    public class Personal
    {
        public long NationalCode { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }


    }




    public static  class GetPersonal01
    {
        private static List<Personal> personals = new List<Personal>
        {
           new Personal
           {
               NationalCode=0013374559 ,
               FirstName="Alireza",
               LastName= "Rezaee",
               FatherName="Naser"
           },
              new Personal
           {
               NationalCode=5245464464 ,
               FirstName="Abbas",
               LastName= "Rezaee",
               FatherName="Naser"
           },
              new Personal
           {
               NationalCode=1458745898 ,
               FirstName="Naser",
               LastName= "Rezaee",
               FatherName="Mohammad"
           },
              new Personal
              {
                  NationalCode=454545545,
                   FirstName="Horie",
                   LastName="Farzin",
                   FatherName="Mohoamad Goli"
              }
        };

         

        public static List<Personal> GetPersonals()
        {
            return personals;
        }

  
    }

    public static class GetPersonal02
    {
        private static List<Personal> personals02 = new List<Personal>
        {
           
           new Personal
           {
               NationalCode=0013374559 ,
               FirstName="Alireza",
               LastName= "Rezaee",
               FatherName="Naser"
           },
              new Personal
           {
               NationalCode=548547854 ,
               FirstName="Masoud",
               LastName= "Haji",
               FatherName="Unknowe"
           },
              new Personal
           {
               NationalCode=8966547452 ,
               FirstName="Sommaye",
               LastName= "Babaei",
               FatherName="Parviz"
           }
        };

        public static List<Personal> GetPersonals02()
        {
            return personals02;
        }
    }
}
