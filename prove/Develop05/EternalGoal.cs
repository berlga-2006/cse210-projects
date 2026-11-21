public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
        
    }

    public override string GetDisplayString()
    {
        return $"[ ] {_title} ({_description})";
    }
    public override string GetSaveString()
    {
        string saveString = $"EternalGoal|{_title}|{_description}|{_points}";
        return saveString;
    }
    public override int ScoreGoal()
    {
        return _points;
    }
}