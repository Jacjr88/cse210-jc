public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public Journal(){
    }

    public void AddEntry(Entry entry)
        {
            this._entries.Add(entry);
        }

    public void DisplayAll()
        {
            foreach(Entry ent in _entries){
                ent.DisplayEntry();
            }
        }
    
    public void SaveToFile(string filename, List<Entry> _entries)
        {
            using (StreamWriter outputFile = new StreamWriter(filename)){

                Console.WriteLine("Saving file.....");

                foreach(Entry entry in _entries){
                    outputFile.WriteLine($"{entry._date}--{entry._promptText}--{entry._entryText}");
                }
            }
        }

    public Journal LoadFromFile(string filename, Journal journal)
    {
        Console.WriteLine("Reading from file.....");
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("--");

            Entry entry = new Entry();

            entry._date= parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            journal.AddEntry(entry);
        }
        return journal;
    }
}