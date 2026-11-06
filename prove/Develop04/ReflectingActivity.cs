public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<int> _usedPromptIndex = new List<int>();
    private List<string> _questions;
    private List<int> _usedQuestionIndex = new List<int>();
    Random _random = new Random();

    const int QuestionLength = 1;

    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void StartActivity()
    {
        _usedQuestionIndex.Clear();
        Random random = new Random();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {_prompts[GetUniqueIndex(_prompts, _usedPromptIndex)]} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);
        if (_duration % QuestionLength > 0)
        {
            AskQuestion(_duration % QuestionLength);
        }
        for (int i = 0; i < _duration / QuestionLength; i++)
        {
            AskQuestion(QuestionLength);
        }
    }

    public void AskQuestion(int time)
    {
        Console.Write($"> {_questions[GetUniqueIndex(_questions, _usedQuestionIndex)]} ");
        Countdown(time);
    }

}