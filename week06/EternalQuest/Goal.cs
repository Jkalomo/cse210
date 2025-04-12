using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    // Constructor
    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    // Abstract method to add progress for each type of goal
    public abstract void AddProgress();

    // Abstract method to check if the goal is complete
    public abstract bool IsComplete();

    // Method to provide motivational feedback
    protected void ProvideMotivation()
    {
        string[] motivationalMessages = new string[]
        {
            "Great job! Keep pushing!",
            "You're on a roll! Keep it up!",
            "Amazing work! You're getting closer to your goal!",
            "Keep going! You're making progress every day!"
        };

        Random rand = new Random();
        int randomIndex = rand.Next(motivationalMessages.Length);
        Console.WriteLine(motivationalMessages[randomIndex]);
    }
}


