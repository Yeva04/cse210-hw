// Exceeds requirements: Logs activity completions (date, time, name, duration) to activity_log.txt for tracking mindfulness habits.
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;
            if (choice == "1")
                activity = new BreathingActivity();
            else if (choice == "2")
                activity = new ReflectionActivity();
            else if (choice == "3")
                activity = new ListingActivity();
            else if (choice == "4")
                break;
            else
            {
                Console.WriteLine("Invalid option. Try again.");
                continue;
            }

            activity.Start();
        }
    }
}