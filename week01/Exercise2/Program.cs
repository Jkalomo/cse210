using System;

class Program
{
    static void Main(string[] args)
    {
         // Prompt user for grade percentage
        Console.Write("Enter your grade percentage: ");
        
        // Ensure valid input
        if (int.TryParse(Console.ReadLine(), out int grade))
        {
            string letter;
            string sign = "";
            
            // Determine the letter grade
            if (grade >= 90)
            {
                letter = "A";
            }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }
            
            // Determine the sign (+ or -) if applicable
            int lastDigit = grade % 10;
            if (grade >= 60 && grade < 90) // Only applies for B, C, and D
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            
            // Ensure A+ does not exist
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
            // Ensure F+ and F- do not exist
            if (letter == "F")
            {
                sign = "";
            }
            
            Console.WriteLine($"Your grade is {letter}{sign}.");
            
            // Determine pass or fail
            if (grade >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Keep trying! Better luck next time.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a numeric grade.");
        }
    }
}