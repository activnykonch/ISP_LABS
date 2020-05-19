using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryInfo country = new CountryInfo("Belarus", "Ireland");
            Sportsmen boxer = new Boxer("Conor McGregor", 31, "14.07.1988", country, 1.75, 73, "MMA", 
            SportRank.MasterOfSport, 26, 22, "Champion");
            boxer.ShowInfo();
            boxer.Action();
            Boxer b = (Boxer)boxer;
            Console.WriteLine("Wins amount: {0}", b.WinsAmount);

            boxer.Weighing();
            boxer.WarmingUp();
            boxer.DefiningMood();

            Console.WriteLine("");

            Human human = new Human("Valeriy Petrovich Gromov", 67, "23.01.1953");
            human.ShowInfo();

            Console.WriteLine("");

            if (human.CompareTo(boxer) > 0)
            {
                Console.WriteLine("{0} is older than {1}", human.Name, boxer.Name);
            }
            else
            {
                Console.WriteLine("{0} is older than {1}", boxer.Name, human.Name);
            }

            Console.WriteLine("");

            b = (Boxer)boxer.Clone();
            b.Achievements = "No longer a champion";
            Console.WriteLine("{0} {1}", b.Name, b.Achievements);

        }
    }
}
