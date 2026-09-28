using System;

class Program
{
    static void Main(string[] args)
    {
       Job job1 = new Job();
       job1._jobTitle = "Software Engineer";
       job1._company = "Microsoft";
       job1._startYear = "1842";
       job1._endYear = "2454";
       Job job2 = new Job();
       job2._jobTitle = "Phone Maker";
       job2._company = "Apple";
       job2._startYear = "18456";
       job2._endYear = "245424";

        Resume resume = new Resume();
        resume._name = "Bob Smith";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}