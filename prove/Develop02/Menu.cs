using System.IO;

public class Menu
{
    Journal _journal = new Journal();
    const string fileName = "journal.csv";
    public void DisplayMenu()
    {
        bool inMenu = true;
        while (inMenu) {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                _journal.AddEntry();
            } else if (userInput == "2")
            {
                _journal.DisplayEntries();
            } else if (userInput == "3")
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                const int dateIndex = 0;
                const int promptIndex = 1;
                const int responseIndex = 2;

                foreach (string line in lines)
                {
                    string[] parts = line.Split("|");
                    Entry newEntry = new Entry();
                    newEntry._date = parts[dateIndex];
                    newEntry._prompt = parts[promptIndex];
                    newEntry._response = parts[responseIndex];
                    _journal._entries.Add(newEntry);
                }
            } else if (userInput == "4")
            {
                // The format for each entry in the csv file will be Date|Prompt|Response
                using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    foreach (Entry entry in _journal._entries)
                    {
                        outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                    }
                }
            } else if (userInput == "5")
            {
                inMenu = false;
            } else
            {
                Console.WriteLine("Invalid Input!");
            }
        }
    }
}