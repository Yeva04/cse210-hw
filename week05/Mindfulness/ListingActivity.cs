public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    {
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        int duration = GetDuration();

        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        Console.WriteLine("Start thinking...");
        ShowCountdown(5);

        Console.WriteLine("List as many items as you can:");
        int count = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}