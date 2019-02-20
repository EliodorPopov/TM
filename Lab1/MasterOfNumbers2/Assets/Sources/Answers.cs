using System.Collections.Generic;
using UnityEngine;
using ConsoleApp1;
public class Answers
{
    private List<string> _answers = new List<string>();

    public string GetAnswer(string question)
    {
        return _answers[Random.Range(0, _answers.Count)];
    }

    public Answers()
    {
        _answers.Add("Yes");
        _answers.Add("No");
        _answers.Add("Definetly!");
        _answers.Add("Of course!");
        _answers.Add("No way!");
        _answers.Add("How can you ask that?");
        _answers.Add("That's not possible!");
        _answers.Add("Are you kidding?");
        _answers.Add("You're dreaming here.");
    }

    public QA CheckIfAnswered(string question, List<QA> history)
    {
        foreach (QA askedQA in history)
        {
            if (question == askedQA.Question)
            {
                return askedQA;
            }
        }

        return null;
    }
}