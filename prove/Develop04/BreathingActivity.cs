public class BreathingActivity : Activity
{

    public BreathingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void StartActivity()
    {
        int extraTime = _duration % 10;
        if (extraTime != 0)
        {
        BreatheIn((int)Math.Ceiling(extraTime * 0.6));
        BreatheOut((int)Math.Ceiling(extraTime * 0.4));
        }

        for (int i = 0; i < (_duration - extraTime) / 10; i++)
        {
            BreatheIn(4);
            BreatheOut(6);
        }
    }

    private void BreatheIn(int seconds)
    {
        Console.Write("Breathe in...");
        Countdown(seconds);
    }

    private void BreatheOut(int seconds)
    {
        Console.Write("Now breathe out...");
        Countdown(seconds);
        Console.WriteLine();
    }
}