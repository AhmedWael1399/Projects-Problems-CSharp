using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQ : Question
    {
        public MCQ(string _Header, string _Body, int _Mark, Answer[] _AnswerList, Answer _RightAnswer) : base(_Header, _Body, _Mark, _AnswerList, _RightAnswer)
        {
            AnswerList = _AnswerList;
            RightAnswer = _RightAnswer;
        }
    }
}
