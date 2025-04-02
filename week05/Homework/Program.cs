using System;

class Program
{
    static void Main()
    {
        // Test for MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3 Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary()); 
        Console.WriteLine(mathAssignment.GetHomeworkList()); 

        // Test for WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary()); 
        Console.WriteLine(writingAssignment.GetWritingInformation()); 
    }
}
