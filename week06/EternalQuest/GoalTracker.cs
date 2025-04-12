using System;
using System.Collections.Generic;

public class GoalTracker
{
    private List<Goal> goals;
    private int totalPoints;

    // Constructor for GoalTracker
    public GoalTracker()
    {
        goals = new List<Goal>();
        totalPoints = 0;
    }

    // Add a new goal
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    // Display the list of goals and their progress
    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            goal.DisplayGoalInfo();  // Display basic goal info from the base class
            string status = goal.IsComplete() ? "Completed" : "Not completed";
            Console.WriteLine($"Status: {status}");
        }
    }

    // Record progress on a goal
    public void RecordProgress(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].AddProgress();
            totalPoints += goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    // Display total points
    public void DisplayScore()
    {
        Console.WriteLine($"Total points: {totalPoints}");
    }
}


