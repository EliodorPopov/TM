using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class QA
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        private int Id { get; set; }

        private static int id = 1;

        public QA(string Question, string Answer)
        {
            this.Question = Question;
            this.Answer = Answer;
            Id = id;
            id++;
        }

    }
}
