using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark {  get; set; }
        public Answer[]? AnswerList { get; set; }
        public Answer? RightAnswer { get; set; }


        public Question(string _Header, string _Body, int _Mark, Answer[] _AnswerList, Answer _RightAnswer)
        {
            Header = _Header;
            Body = _Body;
            Mark = _Mark;
            AnswerList = _AnswerList;
            RightAnswer = _RightAnswer;
        }

    }
}
