using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Abstract Base Class
    abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; } // Added Description
        public int PointValue { get; set; }
        public bool IsComplete { get; set; }

        public Goal(string name, string description, int points) // Modified constructor
        {
            Name = name;
            Description = description;
            PointValue = points;
            IsComplete = false;
        }

        public abstract void RecordEvent();
        public abstract string GetStatus();
        public abstract string GetStringRepresentation();
        public virtual int GetPoints() => IsComplete ? PointValue : 0;
    }

    // Simple Goal
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { } // Modified constructor

        public override void RecordEvent()
        {
            IsComplete = true;
        }

        public override string GetStatus() => IsComplete ? "[X] " + Name : "[ ] " + Name;

        public override string GetStringRepresentation() => $"SimpleGoal:{Name},{Description},{PointValue},{(IsComplete ? "1" : "0")}"; // Modified
    }

    // Eternal Goal
    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points) { } // Modified constructor

        public override void RecordEvent()
        {
            // Eternal goals never complete
        }

        public override string GetStatus() => "[E] " + Name;

        public override string GetStringRepresentation() => $"EternalGoal:{Name},{Description},{PointValue}"; // Modified
    }

    // Checklist Goal
    class ChecklistGoal : Goal
    {
        private int timesCompleted; // Changed to private
        public int CompletionTarget { get; private set; }
        public int BonusPoints { get; private set; }

        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points) // Modified constructor
        {
            CompletionTarget = target;
            BonusPoints = bonus;
            timesCompleted = 0;
        }

        public override void RecordEvent()
        {
            if (timesCompleted < CompletionTarget)
            {
                timesCompleted++;
                if (timesCompleted == CompletionTarget)
                {
                    IsComplete = true;
                    PointValue += BonusPoints; // Add bonus points on completion
                }
            }
        }

        public override string GetStatus() => $"[ ] {Name} (Completed {timesCompleted}/{CompletionTarget})";

        public override string GetStringRepresentation() => $"ChecklistGoal:{Name},{Description},{PointValue},{timesCompleted},{CompletionTarget},{BonusPoints},{(IsComplete ? "1" : "0")}"; // Modified
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalPoints = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            string command = "";

            while (command != "6") // Changed to exit on option "6"
            {
                Console.WriteLine($"You have {totalPoints} points.");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Select a choice from the menu:");

                command = Console.ReadLine()?.Trim();

                switch (command)
                {
                    case "1": // Create New Goal
                        Console.WriteLine("The types of goals are: ");
                        Console.WriteLine("1. Simple goal");
                        Console.WriteLine("2. Eternal goal");
                        Console.WriteLine("3. Checklist goal"); // Corrected the typo
                        Console.WriteLine("Which one would like to create?");
                        string type = Console.ReadLine()?.Trim(); // Use Trim() to avoid leading/trailing spaces

                        Console.WriteLine("What is the name of your goal? ");
                        string name = Console.ReadLine()?.Trim();

                        Console.WriteLine("What is the short description of it?");
                        string description = Console.ReadLine()?.Trim(); // Added description input

                        Console.WriteLine("What is the amount of points associated with this goal?");
                        int points = Convert.ToInt32(Console.ReadLine());

                        if (type == "3") // Corrected to check for "3" instead of "1"
                        {
                            Console.WriteLine("Enter completion target: ");
                            int target = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter bonus points: ");
                            int bonus = Convert.ToInt32(Console.ReadLine());
                            goals.Add(new ChecklistGoal(name, description, points, target, bonus)); // Modified constructor call
                        }
                        else if (type == "2")
                        {
                            goals.Add(new EternalGoal(name, description, points)); // Modified constructor call
                        }
                        else
                        {
                            goals.Add(new SimpleGoal(name, description, points)); // Modified constructor call
                        }
                        break;

                    case "2": // List Goals
                        Console.WriteLine($"Total Points: {totalPoints}");
                        for (int i = 0; i < goals.Count; i++)
                        {
                            Console.WriteLine($"{i}: {goals[i].GetStatus()}");
                        }
                        break;

                    case "3": // Save Goals
                        SaveGoals();
                        break;

                    case "4": // Load Goals
                        LoadGoals();
                        break;

                    case "5": // Record Event
                        Console.WriteLine("Enter goal ID to record (0 to " + (goals.Count-1) + "): ");
                        if (goals.Count == 0){
                            Console.WriteLine("There are no goals to record");
                            break;
                        }
                        int id;
                        if (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                        }

                        if (id >= 0 && id < goals.Count)
                        {
                            goals[id].RecordEvent();
                            totalPoints += goals[id].GetPoints();
                        }
                        else
                        {
                            Console.WriteLine("Invalid goal ID.");
                        }
                        break;


                    case "6": // Exit
                        Console.WriteLine("Exiting the application.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void SaveGoals()
        {
            using (StreamWriter sw = new StreamWriter("goals.txt"))
            {
                foreach (var goal in goals)
                {
                    sw.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt");
                goals.Clear();
                totalPoints = 0;

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];

                    if (type == "SimpleGoal")
                    {
                        var goal = new SimpleGoal(parts[1], parts[2], Convert.ToInt32(parts[3])); // Modified constructor call
                        goal.IsComplete = parts[4] == "1"; // Corrected index
                        goals.Add(goal);
                    }
                    else if (type == "EternalGoal")
                    {
                        var goal = new EternalGoal(parts[1], parts[2], Convert.ToInt32(parts[3])); // Modified constructor call
                        goals.Add(goal);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        var goal = new ChecklistGoal(parts[1], parts[2], Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]), Convert.ToInt32(parts[5])); // Modified constructor call
                        goal.IsComplete = parts[6] == "1";

                        // Setting timesCompleted using reflection
                        var timesCompletedField = typeof(ChecklistGoal).GetField("timesCompleted",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        timesCompletedField?.SetValue(goal, Convert.ToInt32(parts[4])); //Corrected Index

                        if (goal.IsComplete)
                        {
                            goal.PointValue += goal.BonusPoints;
                        }
                        goals.Add(goal);
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
    }
}