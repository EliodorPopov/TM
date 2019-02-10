using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConsoleApp1;

namespace ConsoleApp1
{
    public class FinalScript : MonoBehaviour
    {
        public Text log;
        public Text output;
        public InputField inputField;

        private string currentQuestion;
        private List<QA> historyQA = new List<QA>();

        void Start()
        {

        }


        void Update()
        {
        
        }

        public void SubmitAnswer()
        {
            currentQuestion = inputField.text;
            if (currentQuestion == "" || currentQuestion.LastIndexOf('?') == -1)
            {
                ShowError("Not a valid question!");
            }
            else
            {
                QA currentInput = Answer.CheckIfAnswered(currentQuestion, historyQA);
                if (currentInput == null)
                {
                    currentInput = new QA(currentQuestion, Answer.GetAnswer(currentQuestion));
                    historyQA.Add(currentInput);
                    ShowAnswer(currentInput.Answer);
                }
                else
                {
                    ShowError("Already asked!");
                }
                AddToLog(currentInput);
            }
            inputField.text = "";
            inputField.Select();
            inputField.ActivateInputField();
        }

        public void ShowError(string answer)
        {
            output.color = Color.red;
            output.fontSize = 15;
            output.text = answer;
        }

        public void ShowAnswer(string answer)
        {
            output.color = Color.green;
            output.fontSize = 20;
            output.text = answer;
        }

        private void AddToLog(QA currentQA)
        {
            log.text = "> " + currentQA.Question + "\n " + currentQA.Answer + "\n" + log.text;
        }
    }


}