using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class Swimmer: Sportsmen
    {
        private double bestTime;
        public double BestTime
        {
            get => bestTime;
            set => bestTime = value;
        }
        public string SwimmingStyle { get; set; }
        public override string Achievements { get; set; }

        public Swimmer() : base()
        {
            BestTime = 0;
            SwimmingStyle = "No data";
        }
        public Swimmer(string name, int age, string dateOfBirth, CountryInfo countryInfo, double height,
            double weight, string kindOfSport, SportRank sportRank, int bestTime, string swimmingStyle, string achievements)
            : base(name, age, dateOfBirth, countryInfo, height, weight, kindOfSport, sportRank)
        {
            SwimmingStyle = swimmingStyle;
            BestTime = bestTime;
            Achievements = achievements;
        }

        public override void Action()
        {
            Console.WriteLine("Going to the beach");
        }
    }
}
