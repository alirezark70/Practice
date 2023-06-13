namespace Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Firstname { get; set; }

        public string LastName { get; set; }

        public ICollection<CourseTeachers> CourseTeachers { get; set; }
    }
}
