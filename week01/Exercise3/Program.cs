using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        bool playAgain = true;

        while (playAgain)
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number!");
            Console.WriteLine(" Please pick up a magic number between 1 and 100. And try to guess it!");

            while (guess != magicNumber)
            {
                Console.WriteLine(" What is your guess? ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out guess))
                {
                    guessCount++;

                    if (guess > magicNumber)
                    {
                        Console.Write("Higher");
                    }
                    else if (guess < magicNumber)
                    {
                        Console.Write("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                        Console.WriteLine($"It took you {guessCount} guesses.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            //requesting the user if he or she can wish to play agianed.

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();

            if (playAgainInput != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing, hope your enjoed the game.");
            }
        }

    }
}