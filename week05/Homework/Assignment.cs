public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor to initialize student name and topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Optionally, create a getter for student name (useful in derived classes)
    public string GetStudentName()
    {
        return _studentName;
    }
}
