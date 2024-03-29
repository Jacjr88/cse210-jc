public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;


    public Reference(){
    }
    public Reference(string book, int chapter, int verse){
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

        public Reference(string book, int chapter, int startVerse, int endVerse){
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetBook()
    {
        return _book;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public void SetVerse(int verse)
    {
        _verse = verse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }

    public string GetDisplayText(){
        if (GetEndVerse() == 0){
            return $"{GetBook()} {GetChapter()}:{GetVerse()}";
        } else
        return $"{GetBook()} {GetChapter()}:{GetVerse()}{-GetEndVerse()}";
    }

}