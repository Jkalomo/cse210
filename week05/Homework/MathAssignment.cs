public class MathAssignment : Assignment
{
    // Private member variable for homework problems
    private string _homeworkList;

    // Constructor to initialize all properties
    public MathAssignment(string studentName, string topic, string homeworkList)
        : base(studentName, topic)  
    {
        _homeworkList = homeworkList;
    }

    // Method to get the list of homework problems
    public string GetHomeworkList()
    {
        return _homeworkList;
    }
}
