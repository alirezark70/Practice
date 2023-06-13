using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class GroupBySample
    {
        private readonly StudentDetails _studentDetails;
        public GroupBySample()
        {
            _studentDetails = StudentObject.GetStudentDetails();
        }

        public IEnumerable<IGrouping<int, Grade>> GroupBy()
        {
            //یک ایناموریبلی با فرمت
            //IGRouping میده
            IEnumerable<IGrouping<int, Grade>>? groupByGrade = _studentDetails.Grades.GroupBy(e => e.GradeNumber);
            return groupByGrade;
        }

        public void GroupByForeach(IEnumerable<IGrouping<int, Grade>>? input)
        {
            var result = input;

            foreach(var item in result)
            {
                Console.WriteLine(item.Key);
                
                foreach(var student in item)
                {
                    var getStudent = _studentDetails.Students.FirstOrDefault(e => e.Id == student.StudentId);
                    Console.WriteLine($"FirstName : {getStudent?.FirstName} - Last Name : {getStudent?.LastName}");
                }
                Console.WriteLine("".PadLeft(50, '*'));
            }
        }


        public void GroupByInnerJoin()
        {
            //بر روی جدولی که جوین میخواهیم بزنیم انتخاب می کنیم به شکل زیر
            //بعد از نوشتن جوین داخل پرانتز بدین شکل عمل می کنیم
            //جدولی که جوین باهاش میخواد برقرار بشه می نویسیم
            //بعدش آیدی جدول اولی و اصلی بهش میدیم و در دومی آیدی جدولی که گفتیم با این جوین بزن
            //و در آخر خروجی را انتخاب میکنیم
            var result = _studentDetails.Students.Join(_studentDetails.Grades, e => e.Id, s => s.StudentId,
               (e, s) => new { e.Id, s.GradeNumber, e.FirstName, e.LastName });
        }

        public void GroupByGroupJoin()
        {
            //لینک به صورت پیش فرض لفت جوین نداره و ما باید از گروپ جوین استفاده کنیم
            //این توضیح گروپ جوین هست که همه را میاره
            var result = _studentDetails.Students.GroupJoin(_studentDetails.Grades, s => s.Id, g => g.StudentId, (s, g) =>
            new
            {
                s.Id,
                s.FirstName,
                s.LastName,
                Grade=g
            });
            //در خط آخر جدول سمت راست گذاشتیم که اگه مقدار داشت قرار بده داخل مدل
        }

        public void GroupByLeftJoin()
        {
            //در اینجا ما لفت جوین میزنیم و تمام مواردی که میخواهیم از مدل میکشیم بیرون

            var result = _studentDetails.Students.GroupJoin(_studentDetails.Grades, s => s.Id, g => g.StudentId, (s, g) =>
            new
            {
                s.Id,
                s.FirstName,
                s.LastName,
                Grade=g//دراینجا یک لیست داخل لیست داده ولی ما میخواهیم مقادیر را در یک لیست بگیریم
            }).SelectMany(g => g.Grade.DefaultIfEmpty(), (s, g) =>
            {
                return new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    g?.GradeNumber,

                };
            });

            //DefaultEmpty برای لفت جوین استفاده میشه که میگه اگه مقدار نال بود مقدار پیش فرض را قرار بده
        }
    }
}
