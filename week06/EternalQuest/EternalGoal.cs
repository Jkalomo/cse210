public class EternalGoal : Goal
{
    // Constructor for EternalGoal
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    // Override AddProgress to add points every time
    public override void AddProgress()
    {
        Console.WriteLine($"{Name} completed! You earned {Points} points.");
        ProvideMotivation();
    }

    // Override IsComplete (EternalGoals never complete)
    public override bool IsComplete()
    {
        return false; // Eternal goals never complete
    }
}

