using System;

class Program
{
    static void Main(string[] args)
    {
         Random random = new Random();
        bool playAgain = true;
        
        while (playAgain)
        {
            int magicNumber = random.Next(1, 101); // Generate random number between 1 and 100
            int guess = -1;
            int attempts = 0;
            
            Console.WriteLine("Welcome to 'Guess My Number' game!");
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    attempts++;
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            playAgain = response == "yes";
        }
        
        Console.WriteLine("Thanks for playing! Goodbye.");
    
    }
}