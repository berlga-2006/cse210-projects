using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        static void Modify(List<int> numList)
        {
            numList.Add(1);
        }

        List<int> nums = new List<int>(){3, 2};
        Modify(nums);

        foreach (int num in nums)
        {
            Console.WriteLine(num);
        }
    }
}