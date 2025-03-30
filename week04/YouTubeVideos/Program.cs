using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store multiple videos
        List<Video> videos = new List<Video>();

        // Creating video objects
        Video video1 = new Video("Understanding Numbers", "John Mark", 600);
        video1.AddComment("Aleck", "Great explanation!");
        video1.AddComment("Jonathan", "Very creative.");
        video1.AddComment("Charlie", "Outstanding video.");

        Video video2 = new Video("Python Basics Tutorial", "Jack Smith", 900);
        video2.AddComment("Daniel", "Taught me a lot, thanks!");
        video2.AddComment("Emma", "Incredible Information!");

        Video video3 = new Video("Learning C#", "Mike Thomas", 1200);
        video3.AddComment("Frank", "This was helpful!");
        video3.AddComment("Grace", "Great examples.");
        video3.AddComment("Terry", "Good programming principles.");

        // Adding videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying all videos and their comments
        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine("----------------------------");
        }
    }
}
