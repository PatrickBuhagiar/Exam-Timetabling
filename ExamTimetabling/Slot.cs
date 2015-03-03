using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Slot
    {
        public  int ID;
        public List<Exam> exams;
        public bool empty;

        public Slot(int id){
            exams = new List<Exam>();
            ID = id;
            empty = true;
        }

        public void addExam(Exam x){
            exams.Add(x);
            empty = false;
        }

        public bool existsCourse(Course c)
        {
            for (int i = 0; i < exams.Count; i++)
            {
                for (int j = 0; j < exams[i].courses.Count; j++)
                {
                    if (exams[i].courses[j] == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    
}
