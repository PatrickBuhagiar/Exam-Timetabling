using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTimetabling
{
    class Tuple
    {
        public List<Exam> exams;
        public List<Course> courses;
        public List<Slot> I;
        public Constraint K;
        public const int SIZE =12;
        public const int STUDENTS = 81;
        public int F;

        public Tuple()
        {
            exams = new List<Exam>();
            courses = new List<Course>();
            I = new List<Slot>();
            K = new Constraint();
            F = 0;
            GenerateExams();
            GenerateTimeSlots();
        }

        private void GenerateExams(){
            exams = new List<Exam>();
            
            /*
             *  COURSES 
             */
            Course CS = new Course("Computing Science", 20);
            Course AI = new Course("Artificial Intelligence", 8);
            Course CE = new Course("Computer Engineering", 18);
            Course SD = new Course("Software Development", 19);
            Course CB = new Course("Computing and Business", 16);

            courses.Add(CS);
            courses.Add(AI);
            courses.Add(CE);
            courses.Add(SD);
            courses.Add(CB);
            /*
             *  EXAMS 
             */
            Exam Compiler = new Exam("CPS2000"); //47
            Compiler.addCourse(CS);
            Compiler.addCourse(AI);
            Compiler.addCourse(SD);
            exams.Add(Compiler);

            Exam CommTheory = new Exam("CCE2313"); //38
            CommTheory.addCourse(CS);
            CommTheory.addCourse(CE);
            exams.Add(CommTheory);

            Exam DSP = new Exam("CCE2202"); //38
            DSP.addCourse(CS);
            DSP.addCourse(CE);
            exams.Add(DSP);

            Exam DBMS = new Exam("CIS2090"); //35
            DBMS.addCourse(SD);
            DBMS.addCourse(CB);
            exams.Add(DBMS);

            Exam MobileComputing = new Exam("CIS2109"); //35
            MobileComputing.addCourse(CB);
            MobileComputing.addCourse(SD);
            exams.Add(MobileComputing);

            Exam WebApp = new Exam("CIS2054"); //35
            WebApp.addCourse(CB);
            WebApp.addCourse(SD);
            exams.Add(WebApp);

            Exam SearchOp = new Exam("ICS2201"); //28
            SearchOp.addCourse(CS);
            SearchOp.addCourse(AI);
            exams.Add(SearchOp);

            Exam DSandAlgorithms = new Exam("ICS2210"); //27
            DSandAlgorithms.addCourse(AI);
            DSandAlgorithms.addCourse(SD);
            exams.Add(DSandAlgorithms);

            Exam SoftwareEngineering = new Exam("CPS2002"); //20
            SoftwareEngineering.addCourse(CS);
            exams.Add(SoftwareEngineering);    

            Exam SystemsProg = new Exam("CPS2003"); //20
            SystemsProg.addCourse(CS);
            exams.Add(SystemsProg);

            Exam OS = new Exam("CSA2822"); //19
            OS.addCourse(SD);
            exams.Add(OS);

            Exam AnalogueVLSISignal = new Exam("MNE3114"); //18
            AnalogueVLSISignal.addCourse(CE);
            exams.Add(AnalogueVLSISignal);
            
            Exam MCBasedSystems = new Exam("CCE2014"); //18
            MCBasedSystems.addCourse(CE);
            exams.Add(MCBasedSystems);

            Exam Hardware = new Exam("MNE3002"); //18
            Hardware.addCourse(CE);
            exams.Add(Hardware);

            Exam ebussiness = new Exam("CIS2086"); //16
            ebussiness.addCourse(CB);
            exams.Add(ebussiness);

            Exam NaturalLangProcessing = new Exam("ICS2203"); //8
            NaturalLangProcessing.addCourse(AI);
            exams.Add(NaturalLangProcessing);
        }
        
        private void GenerateTimeSlots(){
            for (int i = 0; i<=SIZE; i++){
                Slot newSlot = new Slot(i);
                I.Add(newSlot);
            }
        }

        private void GenerateConstraint(){

        }

        public bool isSlotEmpty(int i)
        {
            if (I[i].empty)
                return true;
            else
                return false;
        }

        public bool AllSlotsTake()
        {
            for (int i = 0; i < I.Count; i++)
            {
                if (I[i].empty == true) return false;
            }
            return true;
        }

        public void printSlots()
        {
            for (int i = 0; i < I.Count; i++)
            {
                if (!I[i].empty)
                {
                    for (int j = 0; j < I[i].exams.Count; j++)
                    {
                        System.Console.WriteLine("\tSlot " + I[i].ID + "   Code: " + I[i].exams[j].ExamCode);
                        for (int k = 0; k < I[i].exams[j].courses.Count; k++)
                        {
                            System.Console.WriteLine("\t   "+I[i].exams[j].courses[k].CourseName);
                        }
                        System.Console.WriteLine("");
                    }  
                }
            }
        }

        public double Score()
        {
            double F = 0;
            for (int i = 0; i < courses.Count; i++)
            {
                F += K.weightCourse(courses[i], I);
            }
            return F;
        }
    }
}
