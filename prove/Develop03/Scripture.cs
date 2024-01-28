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
        int counter = 0;
        while (counter < numberToHide){
            var random = new Random();
            int index = random.Next(_words.Count);
            if (!_words[index].GetIsHidden()){
                _words[index].isHidden();
                counter++;
            }
        }    
    }

    /**returns the result after hiding words**/
    public string GetDisplayText(){
        string result = "";

        foreach(Word word in _words){
            result = $"{result} {word.GetDisplayText()}";
        }

        return $"{_reference.GetDisplayText()}{result}";
    }

    public bool IsCompletelyHidden(){
        return _words.All(word => word.GetIsHidden());
    }

}