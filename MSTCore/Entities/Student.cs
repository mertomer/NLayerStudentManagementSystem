using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTCore.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string PersonalDetail { get; set; }
        public string EducationDetail { get; set; }
        public string FeesDetail { get; set; }

        public int CourseID { get; set; }
        public Course Courses { get; set; }
    }
}

