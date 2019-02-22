using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
<<<<<<< HEAD
using System;
using System.Collections;
=======
using ConsoleApp1;
using System;
>>>>>>> c0a57489b1ac09ff3a554b14cd9357864fddb17c

public class Controller : MonoBehaviour
{
    public float ballAnimationTime;
    public Animator ballAnimator;
    public TextMeshProUGUI ballText;
    public InputField inputfield;

    private string currentQuestion;
    private List<QA> historyQA = new List<QA>();


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
        currentQuestion = inputfield.text;

        if (string.IsNullOrEmpty(currentQuestion) || currentQuestion.LastIndexOf('?') == -1)
        {
            ShowError("Not a valid question!");
        }
        else
        {
            QA currentInput = _answers.CheckIfAnswered(currentQuestion, historyQA);

            if (currentInput == null)
            {
                currentInput = new QA(currentQuestion, _answers.GetAnswer(currentQuestion));
                historyQA.Add(currentInput);

                ballAnimator.SetTrigger("StartAnimation");
                ballText.text = "";

                StartCoroutine(ShowAnswer(currentInput, ballAnimationTime));

                inputfield.interactable = false;
            }
            else
            {
                ShowError("Already asked!");
            }
        }

        inputfield.text = "";
        inputfield.Select();
        inputfield.ActivateInputField();
    }

    public void ShowError(string answer)
    {
        Debug.Log(answer);
    }

    private IEnumerator ShowAnswer(QA qa, float time)
    {
        yield return new WaitForSeconds(time);

        ballText.text = qa.answer;
        inputfield.interactable = true;
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
