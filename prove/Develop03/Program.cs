using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        Reference reference = new Reference("John", 5, 2);

        Scripture scripture = new Scripture(reference, "habia una vez un barquito chiquitito");

        Console.WriteLine($"{scripture.GetReference().GetBook()} {scripture.GetReference().GetChapter()}:{scripture.GetReference().GetVerse()}");
        foreach(Word word in scripture.GetWords()){
            Console.Write($"{word.GetText()} ");
        }
    }
}