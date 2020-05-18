using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryInfo country = new CountryInfo("Belarus", "Ireland");
            Sportsmen boxer = new Boxer("Conor McGregor", 31, "14.07.1988", country, 1.75, 73, "MMA", 
            SportRank.MasterOfSport, 26, 2, "Champion");
            boxer.Action();
        }
    }
}
