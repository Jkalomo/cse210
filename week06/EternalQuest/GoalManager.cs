using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Goal Management System!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player's Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(string type, string name, string description, int points, int target = 0, int bonus = 0)
    {
        Goal goal = type.ToLower() switch
        {
            "simple" => new SimpleGoal(name, description, points),
            "eternal" => new EternalGoal(name, description, points),
            "checklist" => new ChecklistGoal(name, description, points, target, bonus),
            _ => throw new ArgumentException("Unknown goal type.")
        };

        _goals.Add(goal);
        Console.WriteLine($"Created a new goal: {goal.GetDetailsString()}");
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            var goal = _goals[goalIndex];
            goal.RecordEvent();
            if (goal.IsComplete())
            {
                _score += goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete() ? checklistGoal.GetStringRepresentation().Length : goal.GetStringRepresentation().Length;
                Console.WriteLine($"Current score: {_score}");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void SaveGoals(string fileName)
    {
        // Code to save the goals to a file (e.g., serialization)
        Console.WriteLine($"Goals saved to {fileName}.");
    }

    public void LoadGoals(string fileName)
    {
        // Code to load goals from a file
        Console.WriteLine($"Goals loaded from {fileName}.");
    }
}

