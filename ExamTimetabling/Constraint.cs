using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Constraint
    {
        
        public bool SatisfyHardConstraint(Exam e, Slot s)
        {
            for (int i = 0; i < e.courses.Count; i++)
            {
                for (int j = 0; j < s.exams.Count; j++)
                {
                    for (int k = 0; k < s.exams[j].courses.Count; k++)
                    {
                        if (e.courses[i] == s.exams[j].courses[k])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public double weightCourse(Course c, List<Slot> s)
        {
            int d = 0;
            double F = 0;

            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].existsCourse(c))
                {
                    if (d > 0)
                    {
                        F += (Math.Pow(2, d) / 81);
                        d = 0;
                    }
                }
                else
                    d++;
            }
            return F;
        }
    }
}
