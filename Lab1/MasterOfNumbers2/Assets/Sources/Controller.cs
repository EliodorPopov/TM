using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float ballAnimationTime;
    public Animator ballAnimator;
    public TextMeshProUGUI ballText;
    public Button goButton;

    private Answers _answers;

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
}
