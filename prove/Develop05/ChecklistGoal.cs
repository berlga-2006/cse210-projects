public class ChecklistGoal : Goal
{
    private int _completionGoal;
    private int _timesCompleted;
    private int _completionPoints;

    public ChecklistGoal(string title, string description, int points, int completionGoal, int completionPoints) : base(title, description, points)
    {
        _completionGoal = completionGoal;
        _completionPoints = completionPoints;
        _timesCompleted = 0;
    }

    public ChecklistGoal(string title, string description, int points, int completionGoal, int timesCompleted, int completionPoints) : base(title, description, points)
    {
        _completionGoal = completionGoal;
        _timesCompleted = timesCompleted;
        _completionPoints = completionPoints;
    }

    public override string GetDisplayString()
    {
        string displayString;
        displayString = "[";
        if (_timesCompleted == _completionGoal)
        {
            displayString += "X";
        }
        else
        {
            displayString += " ";
        }
        displayString += $"] {_title} ({_description}) | {_timesCompleted}/{_completionGoal}";
        return displayString;
    }
    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_title}|{_description}|{_points}|{_completionGoal}|{_timesCompleted}|{_completionPoints}";
    }
    public override int ScoreGoal()
    {
        int score = 0;
        if (_timesCompleted < _completionGoal)
        {
            _timesCompleted += 1;
            if (_timesCompleted == _completionGoal)
            {
                score += _completionPoints;
            }
            score += _points;
        }
        return score;
    }

}