using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class ReservedWordException : Exception
{
    public ReservedWordException(string msg)
        : base(msg)
    {
        Console.WriteLine("You used reserved key-word");
    }

}

class Program
{

    private static readonly String date = "Date";
    private static String input;

    public static bool IsKey()
    {
        if (input == date) { return true; } else { return false; }
    }

    static void Main(string[] args)
    {
        const string one = "1", two = "2";
        String selectedOption;
        var currentDate = DateTime.Today;


        Console.WriteLine("Enter your input");

        input = Console.ReadLine();


        bool containsDigits = input.Any(char.IsDigit);
        bool justText = (input.All(char.IsLetter) || input.Contains(" "));

        if (containsDigits) { Console.WriteLine("I'm not a calculator"); }
        if (justText && !IsKey() && !containsDigits) { Console.WriteLine("Hi!"); }


        try
        {
            if (IsKey())
            {
                throw new ReservedWordException("Reserved key");

            }
        }

        catch (ReservedWordException ex)
        {
            Console.WriteLine("If you'd like to see current date, press " + one + " else press " + two);
            selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case one:
                    Console.WriteLine(currentDate);
                    break;
                case two:
                    Console.WriteLine("Hi");
                    break;
                default:
                    Console.WriteLine(currentDate);
                    break;
            }
        }
    }
}

