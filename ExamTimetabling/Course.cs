using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Course
    {
        public string CourseName;
        public int students;

        public Course(string n, int s)
        {
            CourseName = n;
            students = s;
           
        }
    }
}
