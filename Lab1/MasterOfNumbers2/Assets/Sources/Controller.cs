using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using ConsoleApp1;
using System;

public class Controller : MonoBehaviour
{
    public float ballAnimationTime;
    public Animator ballAnimator;
    public TextMeshProUGUI ballText;
    public Button goButton;

    public Text log;
    public InputField inputField;

    private Answers _answers;

    private string currentQuestion;
    private List<QA> historyQA = new List<QA>();

    private string answer;

    private void Awake()
    {
        _answers = new Answers();
        ballText.text = "";
    }

    public void OnButtonClick()
    {
        ballAnimator.SetTrigger("StartAnimation");
        ballText.text = "";

        Invoke("ShowAnswer", ballAnimationTime);

        goButton.interactable = false;
    }

    private void ShowAnswer()
    {
        ballText.text = _answers.GetAnswer("");
        goButton.interactable = true;
    }

    public void SubmitAnswer()
    {
        ballText.text = "";

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
                ballAnimator.SetTrigger("StartAnimation");
                answer = currentInput.Answer;
                Invoke("ShowAnswer1", ballAnimationTime);
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
        ballText.color = Color.red;
        //ballText.fontSize = 15;
        ballText.text = answer;
    }

    public void ShowAnswer1()
    {
        ballText.color = Color.green;
        //ballText.fontSize = 20;
        ballText.text = answer;
    }

    private void AddToLog(QA currentQA)
    {
        //log.text = "> " + currentQA.Question + "\n " + currentQA.Answer + "\n" + log.text;
    }

}
