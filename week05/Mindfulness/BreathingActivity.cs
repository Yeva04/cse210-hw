public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in..."); // Newline to prevent overwrite
            ShowCountdown(4);
            elapsed += 4;
            if (elapsed >= duration) break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            elapsed += 4;
        }
    }
}