using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Kolektor";
        job1._startYear = 2021;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "MELI";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resume resume = new Resume();
        resume._personName = "Jorge Calvi";
        resume._jobList.Add(job1);
        resume._jobList.Add(job2);

        resume.DisplayResume();

    }
}