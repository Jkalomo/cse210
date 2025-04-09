using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize GoalManager
        GoalManager goalManager = new GoalManager();

        // Start the program (for simplicity, we skip complex menu interaction for now)
        goalManager.Start();

        // Example of creating a goal and interacting with it
        goalManager.CreateGoal("simple", "Learn C#", "Complete a C# tutorial", 10);
        goalManager.CreateGoal("checklist", "Complete Exercises", "Complete 5 exercises", 5, 5, 10);
        
        // List goal names
        goalManager.ListGoalNames();
        
        // Record an event for the first goal (SimpleGoal)
        goalManager.RecordEvent(0); // Complete the first goal
        
        // Record an event for the checklist goal
        goalManager.RecordEvent(1); // Complete an event in the checklist goal
    }
}

