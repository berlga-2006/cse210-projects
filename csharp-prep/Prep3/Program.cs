using System;

class Program
{
    static void Main(string[] args)
    {
        string startGame = "yes";
        while (startGame == "yes")
        {
            // Gets the magic number
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Loop until the user guesses the magic number
            int guess = magicNumber - 1;
            int totalGuesses = 0;
            while (guess != magicNumber)
            {
                // Get user input
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                totalGuesses++;

                // Compare the user's guess with the magic number
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    if (totalGuesses == 1)
                    {
                        Console.WriteLine($"You guessed it in {totalGuesses} try!");
                    }
                    else
                    {      
                        Console.WriteLine($"You guessed it in {totalGuesses} tries!");
                    }
                }
            }
            Console.Write("Would you like to play again? (yes/no) ");
            startGame = Console.ReadLine().ToLower();
        }
    }
}