using System;

class Program
{
    static void Main(string[] args)
    {
        string letterGrade = "";
        Console.Write("What is your grade in percentage? ");
        string gradeUserInput = Console.ReadLine();
        int grade = int.Parse(gradeUserInput);

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        string gradeModifier = "";
        int gradeRemainder = grade % 10;
        if (gradeRemainder >= 7)
        {
            gradeModifier = "+";
        }
        else if (gradeRemainder < 3)
        {
            gradeModifier = "-";
        }

        if (grade >= 93)
        {
            gradeModifier = "";
        }
        else if (grade < 60)
        {
            gradeModifier = "";
        }

        Console.WriteLine($"Your grade is: {letterGrade}{gradeModifier}");
        if (grade >= 70)
        {
            Console.WriteLine("You passed! Good job!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you didn't pass this time, but you got this! Just study a little more next time!");
        }

    }
}