using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam
    {
        public int TimeOfExam {  get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[]? Questions { get; set; }
        protected DateTime StartTime { get; set; }
        protected DateTime EndTime { get; set; }

        public Exam(int _TimeOfExam, int _NumberOfQuestions, Question[] _Questions)
        {
            TimeOfExam = _TimeOfExam;
            NumberOfQuestions = _NumberOfQuestions;
            Questions = _Questions;
        }

        public void StartExam()
        {
            StartTime = DateTime.Now;
        }

        public void EndExam()
        {
            EndTime = DateTime.Now;
        }

        public TimeSpan GetElapsedTime()
        {
            return DateTime.Now - StartTime;
        }

        public TimeSpan GetRemainingTime()
        {
            TimeSpan elapsedTime = GetElapsedTime();
            TimeSpan examDuration = TimeSpan.FromMinutes(TimeOfExam);
            return examDuration - elapsedTime;
        }

        public abstract void ShowExam(); 
    }
}
