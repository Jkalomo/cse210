public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    // Constructor for initializing a Goal
    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    // Abstract method to be implemented by subclasses
    public abstract void AddProgress();

    // Virtual method to be overridden in derived classes if necessary
    public virtual void DisplayGoalInfo()
    {
        Console.WriteLine($"{Name}: {Description} - Points: {Points}");
    }

    // Abstract method to check if a goal is complete
    public abstract bool IsComplete();

    // Method to provide motivation (same for all goals)
    public void ProvideMotivation()
    {
        Console.WriteLine($"Great job! Keep up the good work.");
    }
}




