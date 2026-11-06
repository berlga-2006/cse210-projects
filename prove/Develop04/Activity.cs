public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void ShowPrologue()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}.\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        Spinner(3);
        Console.WriteLine();
    }

    public void ShowEpilogue()
    {
        Console.WriteLine("Well done!!");
        Spinner(2);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        Spinner(2);
    }

    protected void Spinner(int seconds)
    {
        Console.Write("|");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
        }
        Console.WriteLine("\b ");
    }

    protected void Countdown(int seconds)
    {
        Console.Write($"{seconds}");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\b ");
    }

    protected int GetUniqueIndex(List<string> questionList, List<int> usedQuestionIndex)
    {
        Random random = new Random();
        int randomIndex;
        do
        {
            randomIndex = random.Next(0, questionList.Count); 
        }
        while (usedQuestionIndex.Contains(randomIndex) && usedQuestionIndex.Count < questionList.Count);

        if (usedQuestionIndex.Count < questionList.Count)
        {
            usedQuestionIndex.Add(randomIndex);
        }
        else
        {
            usedQuestionIndex.Clear();
            usedQuestionIndex.Add(randomIndex);
        }

        return randomIndex;
    }
}