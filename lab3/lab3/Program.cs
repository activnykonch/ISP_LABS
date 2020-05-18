using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Human runner = new Human();
            Human boxer = new Human(
                "Connor McGregor",
                31,
                1.75,
                73,
                "MMA",
                "Master of martial arts",
                "Champion in middle weight category",
                22
                );

            Console.WriteLine(runner);
            Console.WriteLine(boxer);

            Console.WriteLine(Human.CalculateMassIndex(runner) != 0 ? Human.CalculateMassIndex(runner).ToString() : "No data");
            Console.WriteLine(Human.CalculateMassIndex(boxer));
        }
    }
}
