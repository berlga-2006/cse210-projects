using System;

class Program
{
    static void Main(string[] args)
    {
        static double tenth(double number)
        {
            return number * 0.1;
        }

        double tithe = tenth(90);
        Console.WriteLine(tithe);
    }
}