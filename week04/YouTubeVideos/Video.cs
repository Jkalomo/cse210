using System;
using System.Collections.Generic;

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

    // Method to format video length as mm:ss
    private string GetFormattedLength()
    {
        int minutes = Length / 60;
        int seconds = Length % 60;
        return $"{minutes:D2}:{seconds:D2}";
    }

    // Method to add a comment with validation
    public void AddComment(string username, string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            comments.Add(new Comment(username, text.Trim()));
        }
    }

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}\nAuthor: {Author}\nLength: {GetFormattedLength()}\nNumber of Comments: {GetCommentCount()}\n");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.Username}: {comment.Text}");
        }
    }
}
