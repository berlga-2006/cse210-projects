// In this assignment I exceeded the expectations because I made a .csv file that contains several different scriptures.
// The program then chooses one at random for the user to memorize.
// It also makes sure that the randomly hidden words are not already hidden.

class Program
{
    static void Main(string[] args)
    {
        // Create variables
        const string fileName = "Scriptures.csv";
        List<Scripture> scriptureList = [];
        Random random = new Random();

        // This constant is how many words are lost per cycle.
        const int hideCount = 5;

        // Read csv file and populate scriptureList
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        { 
            // Split the contents of the csv file.
            string[] scriptureParts = line.Split("|");
            string[] referenceParts = scriptureParts[0].Split("^");

            // Check how much information we have to use the correct Reference constructor.
            if (referenceParts.Count() == 3)
            {
                Reference newReference = new Reference(referenceParts[0], int.Parse(referenceParts[1]), int.Parse(referenceParts[2]));
                // Add the scripture to the scripture list.
                scriptureList.Add(new Scripture(newReference, scriptureParts[1]));
            } else
            {
                Reference newReference = new Reference(referenceParts[0], int.Parse(referenceParts[1]), int.Parse(referenceParts[2]), int.Parse(referenceParts[3]));
                // Add the scripture to the scripture list.
                scriptureList.Add(new Scripture(newReference, scriptureParts[1]));
            }
        }
        
        // Select random scripture from the list.
        Scripture randomScripture = scriptureList[random.Next(0, scriptureList.Count)];

        // The loop will continue until the user types 'quit'
        string userInput = "";
        while (userInput != "quit")
        {
            Console.Clear();
            randomScripture.Display();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish: ");
            // This if statement makes it so if there are less than
            int amountOfShownWords = randomScripture.GetAmountOfShownWords();
            if (amountOfShownWords >= hideCount)
            {     
                randomScripture.HideWords(hideCount);
                userInput = Console.ReadLine();
            } else if (amountOfShownWords > 0)
            {
                randomScripture.HideWords(amountOfShownWords);
                userInput = Console.ReadLine();
            } else
            {
                Console.ReadLine();
                userInput = "quit";
            }
        }
    }
}