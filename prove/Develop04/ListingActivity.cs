public class ListingActivity : Activity{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description, int duration) : base (name,description,duration){
    }
    public ListingActivity(){
        SetName("Listing Activity");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things" +
                        "as you can in a certain area.");
        SetPrompts(new List<string>());
        SetCount(0);
        SetDuration(0);
    }

    public int GetCount(){
        return _count;
    }
    public void SetCount(int count){
        _count = count;
    }
    public List<string> GetPrompts(){
        return _prompts;
    }
    public void SetPrompts(List<string> prompts){
        _prompts = prompts;
    }

    public void Run(){
        DisplayStartingMessage();

        GetRandomPrompt();

        GetListFromUser();

        Console.WriteLine($"You listed {GetCount()} items");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt(){
        string[] lines = System.IO.File.ReadAllLines("ListingPrompts.txt");
        List<string> prompts = new List<string>();
        
        foreach (string line in lines){
            prompts.Add(line);
        }
        SetPrompts(prompts);
        var random = new Random();
        int index = random.Next(prompts.Count);
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt:\n");
        Console.WriteLine($"--- {prompts[index]} ---\n");
        Console.Write($"You may begin in: \n");
        ShowCountDown(5);
    }

    public List<string> GetListFromUser(){
        List<string> answers = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());

        while(startTime < futureTime){            
            Console.Write("> ");
            string answer = Console.ReadLine();
            answers.Add(answer);
            Console.WriteLine();

            startTime = DateTime.Now;
        }
        SetCount(answers.Count);
        return answers;
    }

}