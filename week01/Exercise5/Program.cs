using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();

        string userName = PuserName();

        int favoriteNumber = PNumber();

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to this program!");
    }

    static string PuserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number;
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
        Console.WriteLine($"{name}, the square of your number is: {squaredNumber}");
    }
}