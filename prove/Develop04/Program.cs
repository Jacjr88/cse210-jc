using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        int userInput = 0;

        while (userInput != 4){
            Console.Clear();
            Console.WriteLine("Menu Options:\n 1. Start breathing activity\n 2. Start reflecting activity\n 3. Start listing activity\n 4. Quit");
            userInput = int.Parse(Console.ReadLine());
            if(userInput == 1){
                Console.Clear();
                BreathingActivity breathingActivity = new BreathingActivity(0);
                breathingActivity.Run();
            }
            else if(userInput == 2){
                Console.Clear();
                ReflectingActivity reflectingActivity = new ReflectingActivity(0,new List<string>(),new List<string>());
                reflectingActivity.Run();
            }
            else if(userInput == 3){
                Console.Clear();
                ListingActivity listingActivity = new ListingActivity(20,new List<string>());
                listingActivity.Run();
            } 
        }
    }
}