public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"\n{_name}");
        Console.WriteLine(_description);
        Console.Write("Enter duration (seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity();
        End();
    }

    protected abstract void RunActivity();

    protected void End()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
        LogActivity();
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write("\r|");
            Thread.Sleep(250);
            Console.Write("\r/");
            Thread.Sleep(250);
            Console.Write("\r-");
            Thread.Sleep(250);
            Console.Write("\r\\");
            Thread.Sleep(250);
        }
        Console.Write("\r   \r");
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r");
    }

    protected int GetDuration()
    {
        return _duration;
    }

    private void LogActivity()
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{_name},{_duration}";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }
}