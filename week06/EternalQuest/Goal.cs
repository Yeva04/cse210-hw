using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";
    }

    public bool IsComplete() => _isComplete;
    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public void SetComplete(bool value) => _isComplete = value; // Changed to public
}