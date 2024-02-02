public class ReflectingActivity : Activity{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description, int duration) : base (name,description,duration){
    }

    public ReflectingActivity(){
        SetName("Reflecting Activity");
        SetDescription("This activity will help you reflect on times in your life when you have shown strengthand resilience. This will help you recognize" + 
                        "the power you have and how you can use it in other aspects of your life.");
        SetPrompts(new List<string>());
        SetQuestions(new List<string>());
        SetDuration(0);
    }

    public List<string> GetPrompts(){
        return _prompts;
    }
    public void SetPrompts(List<string> prompts){
        _prompts = prompts;
    }
    public List<string> GetQuestions(){
        return _questions;
    }
    public void SetQuestions(List<string> questions){
        _questions = questions;
    }

    public void Run(){
        DisplayStartingMessage();

        DisplayPrompt();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt(){
        string[] lines = System.IO.File.ReadAllLines("ReflectingPrompt.txt");
        List<string> prompts = new List<string>();
        
        foreach (string line in lines){
            prompts.Add(line);
        }
        var random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public string GetRandomQuestion(){
        string[] lines = System.IO.File.ReadAllLines("Questions.txt");
        List<string> questions = new List<string>();
        
        foreach (string line in lines){
            questions.Add(line);
        }
        var random = new Random();
        int index = random.Next(questions.Count);
        return questions[index];
    }

    public void DisplayPrompt(){
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();

    }

    public void DisplayQuestions(){
        Console.WriteLine("Now ponder on each of te following questions as they related to this experience\n");
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());

        while(startTime < futureTime){            

            string question = GetValidQuestion(GetQuestions());

            Console.Write($"> {question}");
            Console.WriteLine();
            ShowAnimation(10);
            Console.WriteLine();

            startTime = DateTime.Now;
        }
    }

    public string GetValidQuestion(List<string> questions){
        bool valid = false;
        string question = GetRandomQuestion();
        if (questions.Count()== 0){
            questions.Add(question);
                SetQuestions(questions);
        }else {
            while (!valid){
                if(!questions.Contains(question)){
                    questions.Add(question);
                    SetQuestions(questions);
                    valid = true;
                } else{
                    question = GetRandomQuestion();
                }
            }
        }
        
        return question;
    }

}