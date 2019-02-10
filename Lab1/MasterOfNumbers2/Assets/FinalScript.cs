using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConsoleApp1;

//namespace ConsoleApp1
//{
    public class FinalScript : MonoBehaviour
    {

        public Text welcomeText;
        public Text warningText;
        public InputField inputField;


        string currentQuestion;
        string currentAnswer;
        List<string> questions = new List<string>();
        List<QA> historyQA = new List<QA>();
        bool temporary = true;
        void Start()
        {
            //welcomeText.text = "hello";
            questions.Add("what?");
            questions.Add("who?");
            questions.Add("where?");
            questions.Add("when?");
            questions.Add("how?");
        }


        void Update()
        {
            //if (temporary == true)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        currentQuestion = questions[i];
            //        currentAnswer = Answer.GetAnswer(currentQuestion);
            //        historyQA.Add(new QA(currentQuestion, currentAnswer));
            //    }
            //    foreach (QA temp in historyQA)
            //    {
            //        welcomeText.text += temp.Question + " " + temp.Answer + "\n";
            //        Console.Write(temp.Answer);
            //    }
            //}
            //temporary = false;

        }

        public void SubmitAnswer()
        {
            currentQuestion = inputField.text;
            if (currentQuestion == "" || currentQuestion.LastIndexOf('?') == -1)
            {
                warningText.text = "Not a valid question!";
            }
            else
            {
                QA currentInput = Answer.CheckIfAnswered(currentQuestion, historyQA);
                if (currentInput == null)
                {
                    currentAnswer = Answer.GetAnswer(currentQuestion);
                    historyQA.Add(new QA(currentQuestion, currentAnswer));
                    welcomeText.text = "> " + currentQuestion + "\n" + currentAnswer + "\n" + welcomeText.text;
                    warningText.text = "";
                }
                else
                {
                    warningText.text = "Already asked!";
                    welcomeText.text = "> " + currentInput.Question + "\n " + currentInput.Answer + "\n" + welcomeText.text;
                }
            }
        inputField.text = "";
        inputField.Select();
        inputField.ActivateInputField();
        }
    }
//}