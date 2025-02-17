using System;
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Points: {_points})";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}: {_points} points";
    }

    public override string GetCheckboxStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // This function can have additional logic if needed
    }

    public override bool IsComplete()
    {
        return false; // Never complete
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Points: {_points} per event)";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}: {_points} points per event";
    }

    public override string GetCheckboxStatus()
    {
        return "[ ]"; // Eternal goals are never complete
    }
}

-20
Bad - doing bad stuff: Negative -20 points

jog - will jog daily: 20 points
drive - I will always drive: 20 points
chill - I will chill more: 50 points (Progress: 3/3)

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, -points)
    {
    }

    public override void RecordEvent()
    {
        // This function can have additional logic if needed
    }

    public override bool IsComplete()
    {
        return true; // Always true since negative goals are immediate
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Negative Points: {_points})";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}: Negative {_points} points";
    }

    public override string GetCheckboxStatus()
    {
        return "[X]"; // Negative goals are marked complete immediately
    }
}

-20
chill - I will chill: 100 points
walk - I will walk each day: Negative -10 points

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1: Display Player Info");
            Console.WriteLine("2: List Goals");
            Console.WriteLine("3: Create Goal");
            Console.WriteLine("4: Record Event");
            Console.WriteLine("5: Save Goals");
            Console.WriteLine("6: Load Goals");
            Console.WriteLine("7: Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
    }

    public void ListGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{goal.GetCheckboxStatus()} {goal.GetStringRepresentation()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter your goal type (1: Simple, 2: Eternal, 3: Checklist, 4: Negative): ");
        string type = Console.ReadLine();

        Console.WriteLine("What is the name of your goal: ");
        string name = Console.ReadLine();

        Console.WriteLine("Describe your goal: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the goal's number of points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.WriteLine("Enter the target: ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter goal bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.Write("Enter goal name: ");
        var name = Console.ReadLine(); 

        var goal = _goals.Find(g => g.GetStringRepresentation().StartsWith(name));
        if (goal != null)
        {
            goal.RecordEvent();
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.Bonus;
            }
            _score += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();
        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            string line;
            _goals.Clear();
            while ((line = reader.ReadLine()) != null)
            {
                // Parsing logic for different goal types
                // This part depends on how the goals are represented in the file
            }
        }
    }
}

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public int Points => _points;

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
    public abstract string GetCheckboxStatus(); // New method for checkbox status
}


<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public int Bonus => _bonus;

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Points: {_points}, Progress: {_amountCompleted}/{_target}, Bonus: {_bonus})";
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName} - {_description}: {_points} points (Progress: {_amountCompleted}/{_target})";
    }

    public override string GetCheckboxStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }
}