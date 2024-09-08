using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTCore.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Fees { get; set; }
        public int Duration { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
