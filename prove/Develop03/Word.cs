public class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string word)
    {
        _word = word;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public string GetString()
    {
        if (!_isHidden)
        {   
            return _word;
        } else
        {
            string stringToReturn = "";
            for (int i = 0; i < _word.Length; i++)
            {
                stringToReturn += "_";
            }
            return stringToReturn;
        }
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }

}