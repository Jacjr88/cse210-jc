
public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public PromptGenerator(){
    }

    public string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> ReadPromptsFromFile(List<string> prompts)
    {
        Console.WriteLine("Reading Prompts from file.....");
        string[] lines = System.IO.File.ReadAllLines("prompts.txt");
        
        foreach (string line in lines)
        {
            prompts.Add(line);
        }
        return prompts;
    }

    public void AddPromptToFile(List<string> prompts, string newPrompt){
        prompts.Add(newPrompt);
        using (StreamWriter outputFile = new StreamWriter("prompts.txt")){
            foreach(string prompt in prompts){
                    outputFile.WriteLine($"{prompt}");
                }
        }
    }

    public void DisplayPromptsFromFile()
    {
        Console.WriteLine("Reading from file.....");
        string[] lines = System.IO.File.ReadAllLines("prompts.txt");

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}