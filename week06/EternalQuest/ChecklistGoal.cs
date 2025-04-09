public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"Goal '{_shortName}' accomplished! Completed {_amountCompleted}/{_target}.");
        }
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Goal '{_shortName}' is completed. You earned a bonus of {_bonus} points!");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_amountCompleted}/{_target},{_bonus}";
    }

    // Override the GetDetailsString method to show the progress for checklist goals
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName}: {_description} (Completed {_amountCompleted}/{_target})";
    }
}
