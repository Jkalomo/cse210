using System;
using System.Collections.Generic;

// Comment class to store user comments
class Comment
{
    public string Username { get; set; }
    public string Text { get; set; }

    public Comment(string username, string text)
    {
        Username = username;
        Text = text;
    }
}

// Video class to store video details and associated comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    // Method to add a comment
    public void AddComment(string username, string text)
    {
        comments.Add(new Comment(username, text));
    }

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of Comments: {GetCommentCount()}\n");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.Username}: {comment.Text}");
        }
    }
}

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
        video1.AddComment("Charlie", "Oustanding video.");

        Video video2 = new Video("Python Basics Tutorial", "Jack Smith", 900);
        video2.AddComment("Daniel", "Taught me a lo, thanks!");
        video2.AddComment("Emma", " Incredible Information?");

        Video video3 = new Video("Learning C#", "Mike Thomas", 1200);
        video3.AddComment("Frank", "This was helpfu!");
        video3.AddComment("Grace", "Great examples.");
        video3.AddComment("Terry", "Good programming principles?");

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