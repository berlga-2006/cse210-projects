public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
        
    }

    public SimpleGoal(string title, string description, int points, bool completed) : base(title, description, points)
    {
        _completed = completed;
    }

    public override string GetDisplayString()
    {
        string displayString;
        displayString = "[";
        if (_completed == true)
        {
            displayString += "X";
        }
        else
        {
            displayString += " ";
        }
        displayString += $"] {_title} ({_description})";
        return displayString;
    }
    public override string GetSaveString()
    {
        // Template: SimpleGoal|Title|Description|points|completed
        string saveString = $"SimpleGoal|{_title}|{_description}|{_points}|{_completed}";
        return saveString;
    }
    public override int ScoreGoal()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }
}