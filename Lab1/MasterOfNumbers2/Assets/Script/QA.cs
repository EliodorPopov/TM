using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class QA
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public QA(string Question, string Answer)
        {
            this.Question = Question;
            this.Answer = Answer;
        }

    }
}
