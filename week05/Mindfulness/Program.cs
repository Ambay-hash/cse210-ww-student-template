using System;
using System.Threading;

public class MindfulnessActivity
{
    protected string startMessage;
    protected string endMessage;
    protected int duration;

    public MindfulnessActivity(string startMsg, string endMsg)
    {
        startMessage = startMsg;
        endMessage = endMsg;
    }

    public void StartActivity()
    {
        Console.WriteLine(startMessage);
        Console.WriteLine("Welcome to the Activity");
        Console.Write("Please enter your duration in seconds: ");
        duration = int.Parse(Console.ReadLine());

        PauseForSeconds(3);
        ShowSpinner(" Please get ready to begin...");

        PerformActivity();

        PauseForSeconds(2);
        Console.WriteLine(endMessage);
    }

    protected virtual void PerformActivity()
    {
    }

    protected void PauseForSeconds(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(string message)
    {
        Console.WriteLine(message);
        string[] spinner = { "/", "-", "\\", "|" };
        int i = 0;
        while (i < 20)
        {
            Console.Clear();
            Console.Write(spinner[i % 4]);
            Thread.Sleep(200);
            i++;
        }
        Console.Clear();
    }
}
public class BreathingActivity : MindfulnessActivity
{
    
    public BreathingActivity() : base("Breathing Activity", "Good job! You have completed your breathing session.")
    { }

    protected override void PerformActivity()
    {
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseForSeconds(3); 
            Console.WriteLine("Breathe out...");
            PauseForSeconds(3);
        }
    }
}
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Thinks of a time when you feeled that you were impressed by what you did.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "How good is this experiece to your own life.?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Well done! You have completed your reflection activity.")
    { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        PauseForSeconds(3);

        for (int i = 0; i < duration / 5; i++) 
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine(question);
            PauseForSeconds(5);
        }
    }
}

public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "Why are you appreciative to those people.",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity() : base("Listing Activity", "Great job! You have completed your listing session.")
    { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        PauseForSeconds(3);

        Console.WriteLine("Start listing now...");

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        MindfulnessActivity activity = null;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Strat Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Please Choose from the Menu Options: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
            }

            activity.StartActivity();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
