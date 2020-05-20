using System;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryInfo country = new CountryInfo("Belarus", "Ireland");
            Boxer boxer = new Boxer("Conor McGregor", 31, "14.07.1988", country, 1.75, 73, "MMA", 
            SportRank.MasterOfSport, 26, 22, "Champion");
            CountryInfo newCountry = new CountryInfo("USA", "Ireland");

            boxer.ChangeCountry += o =>
            {
                Console.WriteLine("{0} Previous country: {1}\n{0} Current country: {2}\n", boxer.Name, boxer.CountryInfo.Country, o.Country);
            };

            boxer.SetChangedCountry(newCountry);

            boxer.Preporation += delegate (object sender, EventArgs e)
            {
                if (sender is Sportsmen sportsmen)
                {
                    sportsmen.Weighing();
                    sportsmen.WarmingUp();
                    sportsmen.DefiningMood();
                }
            };
            boxer.Prepare();

            //Demonstration of excaption
            object a = 1;
            Human human = new Human();
            Console.WriteLine();

            try
            {
                human.CompareTo(a);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
