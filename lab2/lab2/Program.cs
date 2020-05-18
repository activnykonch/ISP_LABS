using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions func = new Functions();
            string text;
            Console.WriteLine("Task 2. Enter text");
            text = Console.ReadLine();

            Console.WriteLine(func.Invert(text));

            Console.WriteLine("Task 5. Enter text");
            text = Console.ReadLine();

            Console.WriteLine(func.FindNonEnglishCapitalLetters(text));

            Console.WriteLine("Task 5. Enter text");
            text = Console.ReadLine();

            Console.WriteLine(func.ReplaceLetters(text));
        }
    }
}
