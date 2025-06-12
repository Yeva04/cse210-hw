using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";

        // Load existing goals
        manager.LoadGoals(filename);

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal type (Simple/Eternal/Checklist): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int points = int.Parse(Console.ReadLine());
                    if (type.ToLower() == "checklist")
                    {
                        Console.Write("Enter target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.CreateGoal(type, name, description, points, target, bonus);
                    }
                    else
                    {
                        manager.CreateGoal(type, name, description, points);
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    Console.Write("Enter the goal number to record (1-based index): ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    int pointsEarned = manager.RecordEvent(index);
                    Console.WriteLine($"You earned {pointsEarned} points!");
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    Console.WriteLine($"Your total score: {manager.GetScore()}");
                    break;

                case "5":
                    manager.SaveGoals(filename);
                    Console.WriteLine("Goals saved.");
                    break;

                case "6":
                    manager.LoadGoals(filename);
                    Console.WriteLine("Goals loaded.");
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
    // Exceeding Requirements: Added a leveling system where users level up every 1000 points, earning a "Quest Master" title at level 5, and a celebratory message.
}