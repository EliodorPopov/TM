public class QA
{
    public string question;
    public string answer;
    internal object _answers;

    public QA(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
    }

    public string Question { get; internal set; }
}