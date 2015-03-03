using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Exam
    {
        public string ExamCode;
        public List<Course> courses;

        public Exam(string e)
        {
            ExamCode = e;
            courses = new List<Course>();
        }

        public void addCourse(Course c)
        {
            courses.Add(c);
        }
    }
}
    