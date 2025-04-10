using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) 
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_shortName}' completed!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_isComplete}";
    }
}
