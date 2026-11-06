using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<string> _menuOptions = new List<string>(){
            "Start breathing activity",
            "Start reflecting activity",
            "Start listing activity",
            "Quit"
        };

        List<string> reflectingActivityPrompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        List<string> reflectingActivityQuestions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        List<string> listingActivityPrompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", reflectingActivityPrompts, reflectingActivityQuestions);
        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", listingActivityPrompts);

        bool active = true;

        while (active == true) {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            for (int i = 1; i < _menuOptions.Count() + 1; i++)
            {
                Console.WriteLine($"  {i}. {_menuOptions[i - 1]}");
            }
            Console.Write("Select a choice from the menu: ");
            string userResponse = Console.ReadLine();

            if (userResponse == "1")
            {
                breathingActivity.ShowPrologue();
                breathingActivity.StartActivity();
                breathingActivity.ShowEpilogue();
            }
            else if (userResponse == "2")
            {
                reflectingActivity.ShowPrologue();
                reflectingActivity.StartActivity();
                reflectingActivity.ShowEpilogue();
            }
            else if (userResponse == "3")
            {
                listingActivity.ShowPrologue();
                listingActivity.StartActivity();
                listingActivity.ShowEpilogue();
            }
            else if (userResponse == "4")
            {
                active = false;
            }
        }
    }
}