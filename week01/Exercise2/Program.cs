  using System;

class Program
{

    static void Main(string[] args)

    {
    
        Console.Write("Enter your grade: ");

        int grade = int.Parse(Console.ReadLine()); 

        string letter = "";

        if (grade >= 90)
        {
            letter = ("A");
        }

        else if (grade >= 80)
        {
            letter = ("B");
        }

        else if (grade >= 70)
        {
            letter = ("C");
        }

        else if (grade >= 60)
        {
            letter = ("D");
        }

        else
        {
            letter = ("F");
        }

        Console.Write("Your letter grade is: " +letter);

        string passMessage = (grade >= 70 ? " " + "Congratulations! You passed the course!" : " " + "Sorry, you didn't pass. Better luck next time!");
       
        Console.WriteLine(passMessage);

        string sign = ""; 

        if (letter != "F")

        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }

            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        if (letter != "F")

        {
            Console.WriteLine("Your full grade is: " + letter + sign);
        }

        else
        {
            Console.WriteLine("Your full grade is: " + letter); 
        }
    }
}