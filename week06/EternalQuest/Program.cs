//Levels and Achievements: Track the user’s level and unlock achievements based on their points.

//Feedback and Motivation: Display motivational messages when goals are completed.


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalTracker goalTracker = new GoalTracker();

        // Create some goals
        Goal simpleGoal = new SimpleGoal("Read Scriptures", "Read the scriptures for today", 100);
        Goal eternalGoal = new EternalGoal("Pray Daily", "Pray every day", 50);
        Goal checklistGoal = new ChecklistGoal("Attend the Temple", "Attend the temple 5 times", 200, 5);

        // Add goals to the tracker
        goalTracker.AddGoal(simpleGoal);
        goalTracker.AddGoal(eternalGoal);
        goalTracker.AddGoal(checklistGoal);

        // Simulate completing goals
        goalTracker.RecordProgress(0); // Completing SimpleGoal
        goalTracker.RecordProgress(1); // Completing EternalGoal
        goalTracker.RecordProgress(2); // Completing ChecklistGoal

        // Display current goals and points
        goalTracker.DisplayGoals();
        goalTracker.DisplayScore();
    }
}



