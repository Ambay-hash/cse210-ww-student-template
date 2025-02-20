using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Activity
    {
        public DateTime Date { get; set; }
        public int Minutes { get; set; }

        public Activity()
        {
            Date = DateTime.Now;
        }

        public virtual double GetDistance()
        {
            return 0.0; 
        }

        public virtual double GetSpeed()
        {
            return 0.0; 
        }

        public virtual double GetPace()
        {
            return 0.0;
        }

        public virtual string GetSummary()
        {
            return $"{Date.ToShortDateString()} Activity: Duration {Minutes} minutes. " +
                   $"Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
        }
    }

    public class Running : Activity
    {
        public double Distance { get; set; } 

        public Running()
        {
            Date = DateTime.Now;
        }

        public override double GetDistance()
        {
            return Distance;
        }

        public override double GetSpeed()
        {
            return (Distance / (double)Minutes) * 60.0;
        }

        public override double GetPace()
        {
            return Minutes / Distance;
        }

        public override string GetSummary()
        {
            return $"{Date.ToShortDateString()} Running ({Minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
        }
    }

    public class Cycling : Activity
    {
        public double Speed { get; set; } 

        public Cycling()
        {
            Date = DateTime.Now;
        }

        public override double GetDistance()
        {
            return Speed * (Minutes / 60.0);
        }

        public override double GetSpeed()
        {
            return Speed;
        }

        public override double GetPace()
        {
            return 60.0 / Speed;
        }
        public override string GetSummary()
        {
            return $"{Date.ToShortDateString()} Cycling ({Minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
        }
    }

    public class Swimming : Activity
    {
        public int Laps { get; set; }

        public Swimming()
        {
            Date = DateTime.Now;
        }

        public override double GetDistance()
        {
            return Laps * 50.0 / 1000.0 * 0.62; 
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            return (distance / (double)Minutes) * 60.0;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
        public override string GetSummary()
        {
            return $"{Date.ToShortDateString()} Swimming ({Minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            Running run = new Running { Minutes = 30, Distance = 3.0 };
            Cycling cycle = new Cycling { Minutes = 60, Speed = 15.0 };
            Swimming swim = new Swimming { Minutes = 45, Laps = 50 };

            activities.Add(run);
            activities.Add(cycle);
            activities.Add(swim);

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}