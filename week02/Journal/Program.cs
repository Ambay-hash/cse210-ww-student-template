using System;

class Program
{
     public static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts = {
            "Have l read the book of Mormon today?",
            "How have l seen the hand of the Lord in my life today?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What did l enjoyed today most",
            "what was nice throgh the day",
            "What was the strongest emotion I felt today?",
            "Have l spend time with my family today?",
            "If l had one thing I could do over today, what would it be?"

        };

        while (true)
        {
            Console.WriteLine("Hello, Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine("1. Write in your journal");
            Console.WriteLine("2. Display your journal");
            Console.WriteLine("3. Save the your journal to a file");
            Console.WriteLine("4. Load your journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do today, please choose an option: ");

            string option = Console.ReadLine();

            if (option == "1")
            {
                Random random = new Random();
                int index = random.Next(prompts.Length);
                string prompt = prompts[index];
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                journal.AddEntry(prompt, response);
            }
            else if (option == "2")
            {
                journal.DisplayEntries();
            }
            else if (option == "3")
            {
                Console.Write("Please enter filename to save journal: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("your Journal has been saved successfully.");
            }
            else if (option == "4")
            {
                Console.Write("Enter filename to load journal: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal was loaded successfully.");
            }
            else if (option == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again with correct option.");
            }
        }
    }

}  program.cs
