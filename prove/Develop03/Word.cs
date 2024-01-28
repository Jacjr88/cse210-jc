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

    public void SetText(string text)
    {
        _text = text;
    }

     public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public void Hide(){
        string hiddenWord = "";
        char[] word = _text.ToCharArray();
        foreach(char letter in word){
          hiddenWord = $"{hiddenWord}{letter.ToString().Replace(letter.ToString(),"_")}";
        }
        _text = hiddenWord;
        /*Must set the isHidden = true and replace letters for underscores*/
    }
    public void Show(){
        //**I did not find this method useful, so I did not implemented its functionallity**///
    }
    public bool isHidden(){
        return _isHidden = true;
    }

    /*This method will display the text or the word*/
    public string GetDisplayText(){
        if (GetIsHidden()){
            Hide();
        }
        return _text;
    }
}