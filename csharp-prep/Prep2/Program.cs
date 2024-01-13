using System;

class Program
{
    static void Main(string[] args)
   /* A >= 90
    B >= 80
    C >= 70
    D >= 60
    F < 60*/
    {
        Console.WriteLine("Hello Prep2 World!");
        string letter = "";
        string sign = "";
        Console.Write("What is your grade? ");
        string userInput = Console.ReadLine();
        int score = int.Parse(userInput);
        int remainder = score % 10;

        if(score >= 90){
            letter = "A";
        } else if (score >= 80 && score < 90){
            letter = "B";
        } else if (score >= 70 && score < 80){
            letter = "C";
        } else if (score >= 60 && score < 70){
            letter = "D";
        } else if (score < 60){
            letter = "F";
        }

        if (!letter.Equals("F")){
            if (remainder < 3){
                sign = "-";
            } else if (remainder  >= 7 && !letter.Equals("A")){
                sign = "+";
            }
        }
        
        Console.Write($"Your score is {score}, your grade is {letter} {sign}."); 
    }
}