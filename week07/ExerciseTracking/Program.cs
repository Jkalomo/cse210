using System;
using System.Collections.Generic;

// Base class Activity
public abstract class Activity
{
    public string Date { get; set; }
    public int DurationMinutes { get; set; }

    // Constructor for base class
    public Activity(string date, int durationMinutes)
    {
        Date = date;
        DurationMinutes = durationMinutes;
    }

    // Abstract methods that need to be implemented by derived classes
    public abstract string GetDistance();
    public abstract string GetSpeed();
    public abstract string GetPace();

    // Method to get a formatted summary of the activity
    public string GetSummary()
    {
        string distance = GetDistance();
        string speed = GetSpeed();
        string pace = GetPace();

        return $"{Date} {this.GetType().Name} ({DurationMinutes} min): Distance {distance}, Speed {speed}, Pace: {pace}";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double DistanceMiles { get; set; }

    public Running(string date, int durationMinutes, double distanceMiles)
        : base(date, durationMinutes)
    {
        DistanceMiles = distanceMiles;
    }

    public override string GetDistance()
    {
        return $"{DistanceMiles} miles";
    }

    public override string GetSpeed()
    {
        double speedMph = (DistanceMiles / DurationMinutes) * 60;
        return $"{speedMph:F1} mph";
    }

    public override string GetPace()
    {
        double paceMinPerMile = DurationMinutes / DistanceMiles;
        return $"{paceMinPerMile:F2} min per mile";
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double SpeedMph { get; set; }

    public Cycling(string date, int durationMinutes, double speedMph)
        : base(date, durationMinutes)
    {
        SpeedMph = speedMph;
    }

    public override string GetDistance()
    {
        double distanceMiles = SpeedMph * (DurationMinutes / 60.0);
        return $"{distanceMiles:F1} miles";
    }

    public override string GetSpeed()
    {
        return $"{SpeedMph:F1} mph";
    }

    public override string GetPace()
    {
        double paceMinPerMile = 60 / SpeedMph;
        return $"{paceMinPerMile:F2} min per mile";
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(string date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        Laps = laps;
    }

    public override string GetDistance()
    {
        // Each lap is 50 meters, convert to miles (1 km = 1000 meters, 1 mile = 1.60934 km)
        double distanceMiles = (Laps * 50 / 1000.0) * 0.621371;  // Convert meters to miles
        return $"{distanceMiles:F1} miles";
    }

    public override string GetSpeed()
    {
        double distanceKm = (Laps * 50) / 1000.0;  // Convert meters to kilometers
        double speedKph = (distanceKm / DurationMinutes) * 60;
        return $"{speedKph:F1} kph";
    }

    public override string GetPace()
    {
        double distanceKm = (Laps * 50) / 1000.0;  // Convert meters to kilometers
        double paceMinPerKm = DurationMinutes / distanceKm;
        return $"{paceMinPerKm:F2} min per km";
    }
}

class Program
{
    static void Main()
    {
        // Create instances of each activity
        var running = new Running("03 Nov 2022", 30, 3.0);  // 3 miles in 30 minutes
        var cycling = new Cycling("03 Nov 2022", 30, 12.0);  // 12 mph for 30 minutes
        var swimming = new Swimming("03 Nov 2022", 30, 40);  // 40 laps in 30 minutes

        // Store activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
