public class ListingActivity : Activity
{
    private List<string> _questions;
    private List<int> _usedQuestionIndex = new List<int>();

    public ListingActivity(string name, string description, List<string> questions) : base(name, description)
    {
        _questions = questions;
    }

    public void StartActivity()
    {
        AskQuestion();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        DateTime currentTime = startTime;

        int totalItems = 0;

        while (currentTime < endTime)
        {
            GetResponse();
            totalItems++;
            currentTime = DateTime.Now;
        }

        Console.WriteLine($"You listed {totalItems} items!\n");
    }

    private void AskQuestion()
    {
        Random random = new Random();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($" --- {_questions[random.Next(GetUniqueIndex(_questions, _usedQuestionIndex))]} ---\n");
        Console.Write("You may begin in: ");
        Countdown(5);
    }

    private void GetResponse()
    {
        Console.Write("> ");
        Console.ReadLine();
    }

}