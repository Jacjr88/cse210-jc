using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        bool allHidden = false;

        string userInput = "";

        int quantityOfWords;

        RandomScripturePicker rsp = new RandomScripturePicker();

        List<Scripture> scriptures = rsp.ReadScripturesFromFile();

        Scripture randomScripture = rsp.GetRandomScripture(scriptures);

        quantityOfWords = randomScripture.GetWords().Count;

        while (allHidden == false && userInput != "quit"){
            allHidden = randomScripture.IsCompletelyHidden();
            Console.Clear();
            Console.WriteLine("Press enter to hide wome words in the scripture or type 'quit' to stop program");

            Console.WriteLine("Random Scrpiture");
            
            Console.WriteLine($"{randomScripture.GetDisplayText()}");
            
            userInput = Console.ReadLine();
            if(userInput == ""){

                if (quantityOfWords>=3){
                    randomScripture.HideRandomWords(3);
                    quantityOfWords-=3;
                } else {
                    randomScripture.HideRandomWords(quantityOfWords);
                    quantityOfWords-=quantityOfWords;
                }
                              
            } else if (userInput == "quit"){
                break;
            }
        }
    }
}