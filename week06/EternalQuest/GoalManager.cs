using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoal(string type, string name, string description, int points, int target = 0, int bonus = 0)
    {
        Goal goal = type.ToLower() switch
        {
            "simple" => new SimpleGoal(name, description, points),
            "eternal" => new EternalGoal(name, description, points),
            "checklist" => new ChecklistGoal(name, description, points, target, bonus),
            _ => throw new ArgumentException("Invalid goal type")
        };
        _goals.Add(goal);
    }

    public int RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            return points;
        }
        return 0;
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int GetScore() => _score;

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                string type = goal is EternalGoal ? "Eternal" : goal is ChecklistGoal ? "Checklist" : "Simple";
                writer.WriteLine($"{type}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.IsComplete()}" +
                    (goal is ChecklistGoal cg ? $"|{cg.GetCurrentCount()}|{cg.GetTargetCount()}|{cg.GetBonusPoints()}" : ""));
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);
                if (type == "Checklist")
                {
                    int currentCount = int.Parse(parts[5]);
                    int targetCount = int.Parse(parts[6]);
                    int bonusPoints = int.Parse(parts[7]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                    goal.SetComplete(isComplete); // Use public method
                    goal.SetCurrentCount(currentCount); // Use public method
                    _goals.Add(goal);
                }
                else
                {
                    Goal goal = type == "Eternal" ? new EternalGoal(name, description, points) : new SimpleGoal(name, description, points);
                    goal.SetComplete(isComplete); // Use public method
                    _goals.Add(goal);
                }
            }
        }
    }
}