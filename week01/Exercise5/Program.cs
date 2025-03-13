using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcome();
        
        // Get user input
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        // Process the square of the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Display final result
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        int number;
        Console.Write("Please enter your favorite number: ");

        // Ensure valid integer input
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}