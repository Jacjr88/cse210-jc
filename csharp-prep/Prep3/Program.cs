using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        int number = 0;
        string playAgain = "yes";
        
        while (playAgain == "yes"){
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            Console.WriteLine($"Magic number? {magicNumber}."); 
            int numberOfAttempts = 0;
            while (number != magicNumber){
                Console.Write($"What is your guess? "); 
                string userInput = Console.ReadLine();
                number = int.Parse(userInput);
                numberOfAttempts++;

                if(number < magicNumber){
                    Console.WriteLine("Higher"); 
                } else if (number > magicNumber){
                    Console.WriteLine("Lower");
                } else{
                    Console.WriteLine($"You guessed it! It took {numberOfAttempts} Attempts"); 
                }
            }
            Console.WriteLine($"Do you want to play again? (Write yes to play again)"); 
            playAgain = Console.ReadLine();
        }
    }
}