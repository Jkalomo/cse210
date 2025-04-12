public class ChecklistGoal : Goal
{
    private int timesAchieved;
    private int totalTimesRequired;

    // Constructor for ChecklistGoal
    public ChecklistGoal(string name, string description, int points, int totalTimesRequired)
        : base(name, description, points)
    {
        this.timesAchieved = 0;
        this.totalTimesRequired = totalTimesRequired;
    }

    // Override AddProgress to increment achievement count
    public override void AddProgress()
    {
        if (timesAchieved < totalTimesRequired)
        {
            timesAchieved++;
            Console.WriteLine($"{Name} completed {timesAchieved}/{totalTimesRequired} times. You earned {Points} points.");
            ProvideMotivation();

            // If the goal is completed, add a bonus
            if (timesAchieved == totalTimesRequired)
            {
                Console.WriteLine($"Congratulations! You've completed {Name}! You earned a bonus of 500 points.");
            }
        }
        else
        {
            Console.WriteLine($"{Name} is already fully achieved.");
        }
    }

    // Override IsComplete to check if the goal is fully completed
    public override bool IsComplete()
    {
        return timesAchieved >= totalTimesRequired;
    }
}
