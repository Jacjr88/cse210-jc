using System;

public class Activity{

    private string _name;

    private string _description;

    private int _duration;


    public Activity(string name, string description, int duration){
        _name = name;
        _description = description;
        _duration = duration;
    }

    public Activity( int duration){
        _duration = duration;
    }

    public Activity(){
    }

    public string GetName(){
        return _name;
    }
    public void SetName(string name){
        _name = name;
    }
    public string GetDescription(){
        return _description;
    }
    public void SetDescription(string description){
        _description = description;
    }
    public int GetDuration(){
        return _duration;
    }
    public void SetDuration(int duration){
        _duration = duration;
    }
    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {GetName()} \n");
        Console.WriteLine(GetDescription());
        Console.WriteLine("\nHow long, in seconds, would you like for your session?");
        SetDuration(int.Parse(Console.ReadLine()));
        Console.Clear();
    }

    public void DisplayEndingMessage(){
        Console.WriteLine($"\nGood work! You had completed the {GetName()} in {GetDuration()} seconds");
        ShowAnimation(5);
    }

    public void ShowAnimation(int seconds){
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        string deleting = "\b \b";

        int counter = 0;

        while(startTime < futureTime){

            Console.Write(".");
            Thread.Sleep(200);

            startTime = DateTime.Now;
            counter++;
            if (counter ==5){
                counter=0;
                Console.Write(string.Concat(Enumerable.Repeat(deleting, 10)));
            }
        }
    }

    public void ShowCountDown(int seconds){
        
        for (int i = seconds; i > 0; i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}