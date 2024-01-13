using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<float> numbers = new List<float>();
        float number = -1;
        float smallestNumber = 100000;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (number != 0){
            Console.Write("Enter number: "); 
            string userInput = Console.ReadLine();
            number = float.Parse(userInput);
            if (number != 0){
                numbers.Add(number);
                if (number < smallestNumber && number > 0){
                    smallestNumber = number;
                }
            }
        }
        numbers.Sort();
        float maxNumber = numbers.Max();
        float sum = numbers.Sum();
        float average = numbers.Average();

        Console.WriteLine($"The sum is: {sum}"); 
        Console.WriteLine($"The average is: {average}"); 
        Console.WriteLine($"The largest number is: {maxNumber}"); 
        Console.WriteLine($"The smallest positive number is: {smallestNumber}"); 
        Console.WriteLine($"The sorted list is:"); 
        
        foreach(float i in numbers){
            Console.WriteLine(i); 
        }

    }
}