using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = -1;
        // This line creates the List
        List<int> numberList = new List<int>();
        // Loop until the user types a 0
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numberList.Add(userInput);
            }
        }

        // Get the sum of all numbers in the list
        // Also in the same loop find the largest and smallest number
        int sum = 0;
        int largest = numberList[0];
        int smallestPosNum = 999999999;
        foreach (int num in numberList)
        {
            sum += num;
            if (num > largest)
            {
                largest = num;
            }
            if (num < smallestPosNum && num >= 0)
            {
                smallestPosNum = num;
            }
        }

        // Get the average
        Console.WriteLine(numberList.Count);
        float avg = (float)sum / numberList.Count;

        // Create sorted list
        List<int> sortedList = new List<int>();
        sortedList = numberList;
        sortedList.Sort();

        // Print out results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largets number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPosNum}");
        Console.WriteLine("The sorted list is: ");
        foreach (int num in sortedList)
        {
            Console.WriteLine(num);
        }
    }
}