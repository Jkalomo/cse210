public class WritingAssignment : Assignment
{
    // Private member variable for the title of the writing assignment
    private string _title;

    // Constructor to initialize all properties
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic) 
    {
        _title = title;
    }

    // Method to get the writing information
    public string GetWritingInformation()
    {
        // Access the student name using the GetStudentName() method from the base class
        return $"{_title} by {GetStudentName()}";
    }
}
