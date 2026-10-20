public class Reference
{
    private string _book;
    private int _chapter;
    private int _start;
    private int _end;

    public Reference (string book, int chapter, int start)
    {
        _book = book;
        _chapter = chapter;
        _start = start;
        _end = start;
    }
    public Reference (string book, int chapter, int start, int end)
    {
        _book = book;
        _chapter = chapter;
        _start = start;
        _end = end;
    }

    public string GetString()
    {
        if (_start == _end)
        {
            return $"{_book} {_chapter}:{_start}";
        } else
        {
            return $"{_book} {_chapter}:{_start}-{_end}";
        }
    }
}