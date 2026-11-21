using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
            
            int _points = 0;
            List<Goal> _goalList = new List<Goal>();

            const string FileName = "SaveData.csv";

            bool isRunning = true;
            while (isRunning)
            {
                    
                Console.Clear();
                Console.WriteLine($"\nPoints: {_points}\n");
                
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Delete Goal");
                Console.WriteLine("  7. Quit");
                Console.Write("Select a choice from the menu: ");
                string userInput = Console.ReadLine();
                switch (userInput) 
                {
                    case "1":
                        // This is the code that we run with the Create New Goal Option.
                        Console.WriteLine("\nPlease select one of the following types of goals:");
                        Console.WriteLine("1. Simple Goal");
                        Console.WriteLine("2. Eternal Goal");
                        Console.WriteLine("3. Checklist Goal");
                        Console.Write("> ");
                        userInput = Console.ReadLine();
                        if (userInput == "1" || userInput == "2" || userInput == "3")
                        {
                            Console.Write("\nEnter the title of your goal: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter the description of your goal: ");
                            string description = Console.ReadLine();
                            Console.Write("How many points? ");
                            int points = int.Parse(Console.ReadLine());
                            switch (userInput)
                            {
                                case "1":
                                    SimpleGoal simpleGoal = new SimpleGoal(title, description, points);
                                    _goalList.Add(simpleGoal);
                                    break;

                                case "2":
                                    EternalGoal eternalGoal = new EternalGoal(title, description, points);
                                    _goalList.Add(eternalGoal);
                                    break;

                                case "3":
                                    Console.Write("How many times do you need to complete this goal? ");
                                    int numberOfTimes = int.Parse(Console.ReadLine());
                                    Console.Write("How many bonus points do you want when you finish? ");
                                    int bonusPoints = int.Parse(Console.ReadLine());
                                    ChecklistGoal checklistGoal = new ChecklistGoal(title, description, points, numberOfTimes, bonusPoints);
                                    _goalList.Add(checklistGoal);
                                    break;
                            }
                        }
                        break;

                    case "2":
                        // Code to list goals.
                        if (_goalList.Count > 0)
                        {    
                            ListGoals(_goalList);
                        }
                        else
                        {
                            Console.WriteLine("\nYou don't have any goals yet :(");
                        }
                        Console.Write("\nPress ENTER to continue...");
                        Console.ReadLine();
                        break;

                    case "3":
                        // Save Goals to csv.
                        SaveData(FileName, _goalList, _points);
                        break;

                    case "4":
                        // Load Goals from csv.
                        if (File.Exists(FileName))
                        {  
                            _points += LoadData(FileName, _goalList);
                        }
                        break;

                    case "5":
                        // Record event
                        if (_goalList.Count > 0)
                        {
                            ListGoals(_goalList, true);
                            Console.Write("\nWhich goal would you like to record? ");
                            int input = int.Parse(Console.ReadLine());
                            _points += _goalList[input - 1].ScoreGoal();
                        }
                        else
                        {
                            Console.WriteLine("\nYou don't have any goals yet :(");
                            Console.ReadLine();
                        }

                        break;

                    case "6":
                        if (_goalList.Count > 0)
                        {
                            ListGoals(_goalList, true);
                            Console.Write("\nWhich goal would you like to delete? ");
                            int goalIndex = int.Parse(Console.ReadLine());
                            if (1 <= goalIndex && goalIndex <= _goalList.Count())
                            {
                                Console.Write("\nAre you sure? (Y/N) ");
                                string userResponse = Console.ReadLine().ToLower();
                                if (userResponse == "y")
                                {
                                    _goalList.RemoveAt(goalIndex - 1);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nYou have no goals to delete :(");
                            Console.ReadLine();
                        }
                        break;

                    case "7":
                        // Quit Program.
                        isRunning = false;
                        break;
                
            }
        }
    }

    static int LoadData(string filePath, List<Goal> goalList)
    {
        goalList.Clear();
        string[] data = System.IO.File.ReadAllLines(filePath);
        int i = 0;
        int score = 0;

        foreach (string line in data)
        {
            if (i == 0)
            {
                score = int.Parse(line);
                i++;
            }
            string[] splitData = line.Split("|");
            string goalType = splitData[0];
            if (goalType == "SimpleGoal")
            {
                // Template: SimpleGoal|Title|Description|points|completed
                // This code runs if the goalType is "SimpleGoal"
                SimpleGoal newGoal = new SimpleGoal(splitData[1], splitData[2], int.Parse(splitData[3]), bool.Parse(splitData[4]));
                goalList.Add(newGoal);
            }
            else if (goalType == "EternalGoal")
            {
                // Template: $"EternalGoal|{_title}|{_description}|{_points}";
                // This code runs if the goalType is "EternalGoal"
                EternalGoal newGoal = new EternalGoal(splitData[1], splitData[2], int.Parse(splitData[3]));
                goalList.Add(newGoal);
            }
            else if (goalType == "ChecklistGoal")
            {
                // Template: $"ChecklistGoal|{_title}|{_description}|{_points}|{_completionGoal}|{_timesCompleted}|{_completionPoints}"
                // This code runs if the goalType is "ChecklistGoal"
                ChecklistGoal newGoal = new ChecklistGoal(splitData[1], splitData[2], int.Parse(splitData[3]), int.Parse(splitData[4]), int.Parse(splitData[5]), int.Parse(splitData[6]));
                goalList.Add(newGoal);
            }
        }
        return score;
    }

    static void SaveData(string filePath, List<Goal> goalList, int points)
    {
        List<string> saveData = new List<string>(){$"{points}"};
        foreach (Goal goal in goalList)
        {
            saveData.Add(goal.GetSaveString());
        }
        File.WriteAllLines(filePath, saveData);
    }

    static void ListGoals(List<Goal> goalList, bool isNumbered = false)
    {
        Console.WriteLine("\n--== Goal List ==--");
        if (isNumbered)
        {
            int i = 0;
            foreach (Goal goal in goalList)
            { 
                i++;
                Console.WriteLine($"{i}. " + goal.GetDisplayString());
            }
        }
        else
        {
            foreach (Goal goal in goalList)
            { 
                Console.WriteLine(goal.GetDisplayString());
            }
        }
    }
}