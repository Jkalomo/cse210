
//A progress bar is displayed during each activity to show the user how much time has passed. 
//After each activity, the program increments this count and displays it to the user at the end of the session (e.g., "You have completed X activities").
// If the input is invalid, the program will ask again until the user provides a valid response.
//the program shows a progress bar after each prompt/question or item listing to give the user a sense of progress throughout the activity.


using System;
using System.Collections.Generic;
using System.Threading;

class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    // Constructor to initialize activity name and description
    public MindfulnessActivity(string activityName, string description)
    {
        this.activityName = activityName;
        this.description = description;
    }

    // Method to set the duration for the activity
    public void SetDuration(int seconds)
    {
        this.duration = seconds;
    }

    // Starting the activity with a common starting message
    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {activityName}: {description}");
        Console.WriteLine("Get ready...");
        PauseActivity(3);  // Small pause before starting
    }

    // Method to pause the activity for a certain number of seconds
    protected void PauseActivity(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Display a progress bar to show how much time has passed in the activity
    protected void ShowProgressBar(int currentTime)
    {
        double progress = (double)currentTime / duration;
        int barLength = 30;  // Length of the progress bar
        int progressBars = (int)(progress * barLength);
        
        string progressBar = new string('#', progressBars) + new string('-', barLength - progressBars);
        Console.Write($"\r[{progressBar}] {currentTime}/{duration} seconds");
    }

    // Ending the activity with a common completion message
    public virtual void EndActivity()
    {
        Console.WriteLine("\nWell done! You've completed the activity.");
        Console.WriteLine($"Duration: {duration} seconds.");
        PauseActivity(3);
    }
}

class BreathingActivity : MindfulnessActivity
{
    // Constructor to initialize Breathing Activity
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly.")
    { }

    // Overriding the StartActivity method to implement breathing exercise
    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Let's begin the breathing exercise...");
        for (int i = 0; i < duration / 4; i++) // each breath cycle takes 4 seconds
        {
            Console.WriteLine("Breathe in...");
            PauseActivity(2); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            PauseActivity(2); // Pause for 2 seconds
            ShowProgressBar((i + 1) * 4); // Show progress bar after each cycle
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    // Constructor to initialize Reflection Activity
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    // Overriding StartActivity to implement the reflection process
    public override void StartActivity()
    {
        base.StartActivity();
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseActivity(3); // Pause to think

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            PauseActivity(3); // Pause to reflect
            ShowProgressBar(3); // Show progress after each question
        }
        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    // Constructor to initialize Listing Activity
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    // Overriding StartActivity to implement the listing process
    public override void StartActivity()
    {
        base.StartActivity();
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseActivity(3); // Pause to think

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.WriteLine("Enter an item (or type 'done' to finish):");
            string item = Console.ReadLine();
            if (item.ToLower() == "done") break;
            items.Add(item);
            ShowProgressBar(items.Count); // Show progress bar based on items listed
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}

class Program
{
    static int activityCount = 0; // To track how many activities the user has completed

    static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        // Prompt to select the activity (updated to sound like a question)
        Console.WriteLine("Please select the activity you would like to conduct:");
        Console.WriteLine("1. Breathing Activity - A relaxation exercise to help you focus on your breathing.");
        Console.WriteLine("2. Reflection Activity - A time for you to reflect on your personal strengths and experiences.");
        Console.WriteLine("3. Listing Activity - A chance for you to list things you're grateful for or appreciate.");
        Console.Write("Enter the number of your choice: ");

        string choice = Console.ReadLine();

        MindfulnessActivity activity = null;

        // Activity selection logic
        if (choice == "1")
        {
            activity = new BreathingActivity();
        }
        else if (choice == "2")
        {
            activity = new ReflectionActivity();
        }
        else if (choice == "3")
        {
            activity = new ListingActivity();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid number (1, 2, or 3).");
            return;
        }

        // Prompt for the duration of the activity (new change)
        Console.Write("How many seconds would you like to perform this activity? ");
        int duration = 0;

        // Input validation to ensure the user enters a valid number
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
            {
                break;  // Valid input
            }
            else
            {
                Console.Write("Invalid input. Please enter a positive number for the duration (in seconds): ");
            }
        }

        // Set the duration for the activity and start it
        activity.SetDuration(duration);
        activity.StartActivity();

        // Increment the activity count after completion
        activityCount++;
        Console.WriteLine($"\nYou have completed {activityCount} activities.");
    }
}

