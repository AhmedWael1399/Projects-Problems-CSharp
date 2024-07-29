using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string _Header, string _Body, int _Mark, Answer _RightAnswer): base(_Header, _Body, _Mark, new Answer[]
        {
            new Answer(1, "True"),
            new Answer(2, "False")
        }, _RightAnswer)
        {
        }
    }
}
