using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Program
    {
        static void Main(string[] args)
        {
            //used to measure execution
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            double F = 0;
            Tuple X = new Tuple();
            for (int loop = 0; loop < 100000; loop++)
            {
                Tuple x = new Tuple();
                Random r = new Random();
                bool flag;
                bool filled = false;
                if (x.I.Count >= x.exams.Count)
                {
                    for (int i = 0; i < x.exams.Count; i++)
                    {
                        flag = true;
                        while (flag)
                        {
                            int R = (int)(r.NextDouble() * x.I.Count - 1);
                            if (x.isSlotEmpty(R))
                            {
                                flag = false;
                                x.I[R].addExam(x.exams[i]);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < x.exams.Count; i++)
                    {
                        if (i == x.I.Count - 1) filled = true;
                        if (filled)
                        {
                            flag = true;
                            while (flag)
                            {
                                int R = (int)(r.NextDouble() * x.I.Count - 1);
                                if (x.K.SatisfyHardConstraint(x.exams[i], x.I[R]))
                                {
                                    flag = false;
                                    x.I[R].addExam(x.exams[i]);
                                }
                            }

                        }
                        else
                        {
                            flag = true;
                            while (flag)
                            {
                                int R = (int)(r.NextDouble() * x.I.Count - 1);
                                if (x.isSlotEmpty(R))
                                {
                                    flag = false;
                                    x.I[R].addExam(x.exams[i]);
                                }
                            }
                        }
                    }
                }
                double f = x.Score();
                if (f > F) {
                    F = f;
                    X = x;             
                }
            }
            System.Console.WriteLine("\n\tFinal Score: " + F + "\n");

            X.printSlots();
            
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value. 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
             ts.Milliseconds / 10);
            Console.WriteLine("\tRunTime " + elapsedTime);

            Console.ReadKey();
        }
    }
}
