using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");



        List<double> numbers = new List<double>();
            double inputNumber;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            while (true)
            {
                Console.Write("Enter number: ");
                inputNumber = Convert.ToDouble(Console.ReadLine());

                if (inputNumber == 0)
                {
                    break; 
                }

                numbers.Add(inputNumber);
            }

            if (numbers.Count > 0)
            {
                double sum = CalculateSum(numbers);

                double average = CalculateAverage(numbers);

                double maxNumber = FindMaximum(numbers);

                Console.WriteLine($"The sum is: {sum} ");
                Console.WriteLine($"The average is: {average} ");
                Console.WriteLine($"The largest number is: {maxNumber} ");

                double smallestPositive = FindSmallestPositive(numbers);
                List<double> sortedNumbers = SortNumbers(numbers);

                Console.WriteLine($"The smallest positive number is: {smallestPositive} ");
                Console.WriteLine("The sorted list is: ");

                foreach (var number in sortedNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.Write("No numbers were entered. ");
            }
        }

        static double CalculateSum(List<double> numbers)
        {
            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static double CalculateAverage(List<double> numbers)
        {
            double sum = CalculateSum(numbers);
            return sum / numbers.Count; 
        }

        static double FindMaximum(List<double> numbers)
        {
            double maxNumber = numbers[0]; 
            foreach (var number in numbers)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
            return maxNumber;
        }

        static double FindSmallestPositive(List<double> numbers)
        {
            double smallestPositive = double.MaxValue;
            foreach (var number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
            return smallestPositive == double.MaxValue ? 0 : smallestPositive; 
        }

        static List<double> SortNumbers(List<double> numbers)
        {
            numbers.Sort(); 
            return numbers; 
        }
    }