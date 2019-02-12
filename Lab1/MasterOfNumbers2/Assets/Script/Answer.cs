using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    static class Answer
    {
        private static List<string> answers = new List<string>();
        private static System.Random randomGenerator = new System.Random();


        public static string GetAnswer(string question)
        {
            return answers[randomGenerator.Next(0, answers.ToArray().Length)];
        }

        static Answer()
        {
            answers.Add("Yes");
            answers.Add("No");
            answers.Add("Definetly!");
            answers.Add("Of course!");
            answers.Add("No way!");
            answers.Add("How can you ask that?");
            answers.Add("That's not possible!");
            answers.Add("Are you kidding?");
            answers.Add("You're dreaming here.");
        }

        public static QA CheckIfAnswered(string question, List<QA> history)
        {
            foreach(QA askedQA in history)
            {
                if (question == askedQA.Question)
                {
                    return askedQA;
                }
            }
            return null;
        }
    }
}
