public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;

    protected Goal (string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public abstract string GetDisplayString();
    public abstract string GetSaveString();
    public abstract int ScoreGoal();
}