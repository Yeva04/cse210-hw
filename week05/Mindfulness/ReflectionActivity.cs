public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind?"
    };

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        int duration = GetDuration();
        int elapsed = 0;

        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        Console.WriteLine("Press Enter when ready to reflect...");
        Console.ReadLine();
        ShowSpinner(3);

        List<string> availableQuestions = new List<string>(_questions); // Track available questions

        while (elapsed < duration && availableQuestions.Count > 0)
        {
            int index = random.Next(availableQuestions.Count);
            string question = availableQuestions[index];
            Console.WriteLine(question);
            availableQuestions.RemoveAt(index); // Remove used question
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}