public class Scripture
{
    private Reference _reference;
    private List<Word> _passage = [];

    public Scripture(Reference reference, string passageString)
    {
        _reference = reference;
        foreach (string word in passageString.Split(" "))
        {
            _passage.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Write($"{_reference.GetString()} ");
        foreach (Word word in _passage)
        {
            Console.Write($"{word.GetString()} ");
        }
        Console.WriteLine();
    }

    public void HideWords(int num)
    {
        Random random = new Random();
        for (int i = 0; i < num;)
        {
            Word chosenWord = _passage[random.Next(0, _passage.Count)];
            if (!chosenWord.GetIsHidden())
            {
                chosenWord.Hide();
                i++;
            }
        }
    }

    public int GetAmountOfShownWords()
    {
        int shownWordAmount = 0;
        foreach (Word word in _passage)
        {
            if (!word.GetIsHidden())
            {
                shownWordAmount++;
            }
        }
        return shownWordAmount;
    }
}