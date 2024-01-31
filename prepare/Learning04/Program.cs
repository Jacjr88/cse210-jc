using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        Assignment assignment = new Assignment();
        assignment.SetStudentName("George");
        assignment.SetTopic("Anything");
        Console.WriteLine(assignment.GetSumary());
        Console.WriteLine();

        Assignment assignment2 = new Assignment();
        assignment2.SetStudentName("Mathew");
        assignment2.SetTopic("Fractions");

        MathAssignment mathAssignment = new MathAssignment(assignment2.GetStudentName(), assignment2.GetTopic(), "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetSumary());
        Console.WriteLine(mathAssignment.GetHomeWorkList());

        Assignment assignment3 = new Assignment();
        assignment3.SetStudentName("Alisa");
        assignment3.SetTopic("World War 2 battles");

        WritingAssignment writingAssignment = new WritingAssignment(assignment3.GetStudentName(), assignment3.GetTopic(), "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSumary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}