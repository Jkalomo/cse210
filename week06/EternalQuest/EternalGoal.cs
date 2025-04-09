using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) 
        : base(shortName, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{_shortName}' has been completed again!");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never marked as complete
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},false";
    }
}
