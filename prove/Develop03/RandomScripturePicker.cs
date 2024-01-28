public class RandomScripturePicker
{
    private List<Scripture> _scriptures;

    public RandomScripturePicker(List<Scripture> scriptures){
        _scriptures = scriptures;
    }
    
        public RandomScripturePicker(){
    }

    public List<Scripture> GetScriptures()
    {
        return _scriptures;
    }

    public void SetScriptures(List<Scripture> scriptures)
    {
        _scriptures = scriptures;
    }

    public List<Scripture> ReadScripturesFromFile()
    {
        Console.WriteLine("Reading Scriptures from file.....");
        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");
        List<Scripture> scriptures = new List<Scripture>();
        
        foreach (string line in lines){
            Reference reference = new Reference();
            string[] parts = line.Split("--");
            if(int.Parse(parts[3]) == 0){
                reference = new Reference(parts[0],int.Parse(parts[1]),int.Parse(parts[2]));
            } else {
                reference = new Reference(parts[0],int.Parse(parts[1]),int.Parse(parts[2]), int.Parse(parts[3]));
            }
            Scripture scripture = new Scripture(reference,parts[4]);
            scriptures.Add(scripture);

        }
        return scriptures;
    }

    public Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        var random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

}