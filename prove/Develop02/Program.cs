using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
        int option = 0;

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        PromptGenerator pg = new PromptGenerator();

        pg.ReadPromptsFromFile(pg._prompts);

        DisplayWelcome();
        Journal journal = new Journal();
        
        while (option != 7){
            DisplayMenu();
            string userInput = Console.ReadLine();
            option = int.Parse(userInput);
            if (option == 1){
                string randomPrompt = pg.GetRandomPrompt();
                Console.WriteLine(randomPrompt);
                string userAnswer = Console.ReadLine();
                Entry entry= new Entry(dateText,randomPrompt,userAnswer);
                journal.AddEntry(entry);
            } else if (option == 2){
                journal.DisplayAll();
            } else if (option == 3){
                Console.WriteLine("Enter the name of the file to save");
                string filename = Console.ReadLine();
                journal.SaveToFile($"{filename}.txt", journal._entries);
            } else if (option == 4){
                Console.WriteLine("Enter the name of the file to read");
                string filename = Console.ReadLine();
                journal.LoadFromFile($"{filename}.txt", journal);
            } else if (option == 5){
                Console.WriteLine("Enter the the prompt you want to Add");
                string newPrompt = Console.ReadLine();
                pg.AddPromptToFile(pg._prompts,  newPrompt);
            } else if (option == 6){
                pg.DisplayPromptsFromFile();
            } else if (option <= 0 || option > 7){
                Console.WriteLine("This option is not valid");
            }
        }

    }

    public static void DisplayMenu(){
        Console.WriteLine("Please choose one of the following options\n1-Write\n2-Display\n3-Save\n4-Load\n5-Add Prompt\n6-Display Prompts\n7-Quit");
    }

        public static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Journal Program");
    }

}