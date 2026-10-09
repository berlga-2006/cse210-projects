public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "In what ways was I Christlike today?",
        "What was the worst part of my day?",
        "What was the best food I ate today? Why?",
        "How much water did I drink today?",
        "What are you most grateful for today?"
    };
    public void AddEntry()
    {
        Random random = new Random();
        Entry newEntry = new Entry();
        newEntry._prompt = prompts[random.Next(0, prompts.Count())];
        Console.WriteLine(newEntry._prompt);
        Console.Write("> ");
        newEntry._response = Console.ReadLine().Replace("|", "");
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void Save()
    {
        
    }

    public void Load()
    {
        
    }
}