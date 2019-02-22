using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float ballAnimationTime;
    public Animator ballAnimator;
    public TextMeshProUGUI ballText;
    public InputField inputfield;

    private string currentQuestion;
    private List<QA> historyQA = new List<QA>();


    private Answers _answers;

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
}
