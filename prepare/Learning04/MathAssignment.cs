public class MathAssignment : Assignment
{
    private string _textBook;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbook, string problems): base(studentName, topic){
        _textBook = textbook;
        _problems = problems;
    }

    public string GetTextBook(){
        return _textBook;
    }

    public void SetTextBook(string textBook){
        _textBook = textBook;
    }

    public string GetProblems(){
        return _problems;
    }

    public void SetProblems(string problems){
        _problems = problems;
    }

    public string GetHomeWorkList(){
        return $"{GetTextBook()} {GetProblems()}";
    }
    
}