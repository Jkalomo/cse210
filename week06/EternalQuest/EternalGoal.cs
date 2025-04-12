public class EternalGoal : Goal
{
    // Constructor for EternalGoal
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    // Override AddProgress to add points every time
    public override void AddProgress()
    {
        // Points are earned every time the user "completes" the goal.
        Console.WriteLine($"{Name} completed! You earned {Points} points.");
        ProvideMotivation();
    }

    // Override IsComplete (EternalGoals never complete)
    public override bool IsComplete()
    {
        return false; // Eternal goals are never completed
    }

    // Override DisplayGoalInfo to show goal info and that it can't be completed
    public override void DisplayGoalInfo()
    {
        base.DisplayGoalInfo(); // Call the base class implementation
        Console.WriteLine("This goal is ongoing and will never be marked as completed.");
    }
}



