using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class Runner: Sportsmen
    {
        private double bestTime;
        public double BestTime
        {
            get=>bestTime;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                bestTime = value;
            }
        }
        public string TypeOfDistance { get; set; }
        public override string Achievements { get; set; }

        public Runner():base()
        {
            BestTime = 0;
            TypeOfDistance = "No data";
        }
        public Runner(string name, int age, string dateOfBirth, CountryInfo countryInfo, double height,
            double weight, string kindOfSport, SportRank sportRank, int bestTime, string typeOfDistance, string achievements)
            : base(name, age, dateOfBirth, countryInfo, height, weight, kindOfSport, sportRank)
        {
            TypeOfDistance = typeOfDistance;
            BestTime = bestTime;
            Achievements = achievements;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Best time: " + BestTime.ToString() + "s " + TypeOfDistance + " " + Achievements);
        }
        public override void Action()
        {
            Console.WriteLine("Running for a beer");
        }
    }
}
