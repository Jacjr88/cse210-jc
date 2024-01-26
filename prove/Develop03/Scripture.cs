public class Scripture
{
    private Reference _reference;
    private List<Word> _words;


    public Scripture(Reference reference, List<Word> text){
        _reference = reference;
        _words = text;
    }

    public Scripture(Reference reference, string text){
        _reference = reference;
        List<Word> wordsResult = new List<Word>();
        string[] textSplit = text.Split(" ");
        List<string> words = textSplit.ToList();
        words.ForEach(str => {
            Word word = new Word(str);
            wordsResult.Add(word);
            });
        _words = wordsResult;
    }

    public Reference GetReference()
    {
        return _reference;
    }

    public void SetReference(Reference reference)
    {
        _reference = reference;
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    public void SetWords(List<Word> words)
    {
        _words = words;
    }

    public void HideRandomWords(int numberToHide){
        //Must hide a random word in the list
    }

    public string GetDisplayText(){
        //returns the result after hiding words
        return "";
    }

    public bool IsCompletelyHidden(){
        //returns a true when all words are hidden
        return true;
    }

}