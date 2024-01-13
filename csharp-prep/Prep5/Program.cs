using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        static void DisplayMessage(){
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName (){
            Console.Write("Please enter your name: "); 
            string userInput = Console.ReadLine();
            return $"Brother {userInput}";
        }

        static int PromptUserNumber (){
            Console.Write("Please enter your favorite number: "); 
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        static int SquareNumber (int number){
            int squaredNumber = number * number;
            return squaredNumber;
        }

        static void DisplayResult  (string username, int number){
            Console.WriteLine($"{username}, the square of your number is {number}");
        }

        DisplayMessage();
        DisplayResult(PromptUserName(),SquareNumber(PromptUserNumber()));
    }
}