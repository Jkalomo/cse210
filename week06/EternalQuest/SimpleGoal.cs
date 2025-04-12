public class SimpleGoal : Goal
{
    private bool completed;

    // Constructor for SimpleGoal
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        completed = false;
    }

    // Override AddProgress to mark goal as completed
    public override void AddProgress()
    {
        if (!completed)
        {
            completed = true;
            Console.WriteLine($"{Name} has been completed! You earned {Points} points.");
            ProvideMotivation();
        }
        else
        {
            Console.WriteLine($"{Name} is already completed.");
        }
    }

    // Override IsComplete to return if goal is completed
    public override bool IsComplete()
    {
        return completed;
    }
}


