using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTCore.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TName { get; set; }
        public string Education { get; set; }

        public int CourseID { get; set; }
        public Course Courses { get; set; }
    }
}

