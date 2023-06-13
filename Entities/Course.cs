using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime StartDateTime { get; set; }


        public ICollection<CourseTeachers> CourseTeachers { get; set; }


        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comment> Comments { get; set; }


        public Discount Discount { get; set; }

    }
}
