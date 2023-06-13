using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public  static class StudentObject
    {
       private static List<Student> students = new List<Student>
        {
            new Student{Id= 1, FirstName="Alireza",LastName="Rezaee"},
            new Student{Id= 2, FirstName="Sommaye",LastName="Babaei"},
            new Student{Id= 3, FirstName="Saeed",LastName="Farzin"},
            new Student{Id= 4, FirstName="Masoud",LastName="Haji"},
            new Student{Id= 5, FirstName="Ali",LastName="Shafie"},
        };

        private static List<Lesson> lessons = new List<Lesson>
        {
            new Lesson{Id= 1, Name="Riazi"},
            new Lesson{Id= 2, Name="Fanavari Etelaat"},
            new Lesson{Id= 3, Name="Hosh Masnoui"},
            new Lesson{Id= 4, Name="Modiriat Etelaat"},
        };

        private static List<Major> majors = new List<Major>
        {
            new Major{Id = 1, Name= "It"},
            new Major{Id = 2, Name= "Narmafzar"},
        };

        private static List<Grade> grades = new List<Grade>
        {
            new Grade{Id= 1, StudentId = 1, LessonId = 1, MajorId = 1, GradeNumber =17},
            new Grade{Id= 2, StudentId = 1, LessonId = 2, MajorId = 1, GradeNumber =19},
            new Grade{Id= 3, StudentId = 2, LessonId =3 , MajorId =2 , GradeNumber =15},
            new Grade{Id= 4, StudentId = 2, LessonId = 4, MajorId = 2, GradeNumber =18},
            new Grade{Id= 5, StudentId = 3, LessonId =1 , MajorId =2 , GradeNumber =17},
            new Grade{Id= 6, StudentId = 3, LessonId = 3, MajorId =2 , GradeNumber =18},
            new Grade{Id= 7, StudentId = 4, LessonId =2 , MajorId =1 , GradeNumber =15},
            new Grade{Id= 8, StudentId = 4, LessonId =2 , MajorId =1 , GradeNumber =10},
            new Grade{Id= 9, StudentId = 5, LessonId = 1, MajorId =2 , GradeNumber =20},
            new Grade{Id= 10, StudentId =5 , LessonId =1 , MajorId =2 , GradeNumber =20},
            new Grade{Id= 11, StudentId =1 , LessonId = 3, MajorId =1 , GradeNumber =19},
            new Grade{Id= 12, StudentId = 1, LessonId =4 , MajorId =1 , GradeNumber =18},
            new Grade{Id= 13, StudentId = 2, LessonId = 2, MajorId =2 , GradeNumber =18},
        };

        public static StudentDetails GetStudentDetails()
        {
            var studentDetails = new StudentDetails
            {
                Grades= grades,
                Students= students,
                Lessons= lessons,
                Majores=majors
            };

            return studentDetails;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class Major
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class Grade
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int LessonId { get; set; }

        public int MajorId { get; set; }

        public int GradeNumber { get; set; }

    }


    public class StudentDetails
    {
       

        public List<Student> Students { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<Major> Majores { get; set; }

        public List<Grade> Grades { get; set; }
    }
}
