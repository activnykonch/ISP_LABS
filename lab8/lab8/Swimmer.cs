using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class Swimmer: Sportsmen
    {
        private double bestTime;
        public double BestTime
        {
            get => bestTime;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                bestTime = value;
            }
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

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(BestTime.ToString() + "s " + SwimmingStyle + " " + Achievements);
        }
        public override void Action()
        {
            Console.WriteLine("Going to the beach");
        }

    }
}
