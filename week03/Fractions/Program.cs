using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
    }
}
using System;

public class Fraction
{
// this is private attributes for numerator and the denominator.
    private int numerator;
    private int denominator;

//Constructor to initialize the fraction to 1/1.
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

// The constructor with one parameter to initialize the numerators and set the denominator to 1
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        this.denominator = 1;
    }


//The constructor with two parameters to initializes the numerator and the denominator.
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException(" The Denominator cannot be zero.");
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

//the getter method for numerator
    public int GetNumerator() => numerator;
    public void SetNumerator(int numerator) => this.numerator = numerator;


//the getter method for denominator
    public int GetDenominator() => denominator;
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
    }

// the method to get the fraction as a string
    public string GetFractionString() => $"{numerator}/{denominator}";

// the method to get decimal value of the fraction    
    public double GetDecimalValue() => (double)numerator / denominator;
}

class Program
{
    static void Main()
    {
 // creating fractions using various constructors

        Fraction frac1 = new Fraction();  
        Fraction frac2 = new Fraction(4);  
        Fraction frac3 = new Fraction(3, 7);  
        Fraction frac4 = new Fraction(2, 5);  

//this is to display the fraction as a strings

        Console.WriteLine(frac1.GetFractionString());  
        Console.WriteLine(frac2.GetFractionString());  
        Console.WriteLine(frac3.GetFractionString());  
        Console.WriteLine(frac4.GetFractionString());  

        Console.WriteLine(frac1.GetDecimalValue());  
        Console.WriteLine(frac2.GetDecimalValue()); 
        Console.WriteLine(frac3.GetDecimalValue());  
        Console.WriteLine(frac4.GetDecimalValue());  
    }
}