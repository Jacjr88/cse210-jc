public class Word
{
    private string _text;
    private bool _isHidden;


    public Word(string text){
        _text = text;
        _isHidden = false;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetTop(string text)
    {
        _text = text;
    }

     public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void SetTop(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public void Hide(){
        /*Must set the isHidden = true and replace letters for underscores*/
    }
    public void Show(){
        /*Must set the isHidden = false and replace underscores for letters*/
    }
    public bool isHidden(){
        /*To manage the transition of states*/
        return true;
    }

    public string GetDisplayText(){
        /*This method will display the text*/
        return "";
    }

}