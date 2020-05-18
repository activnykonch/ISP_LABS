using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    class Boxer: Sportsmen
    {
        private int roundsAmount;
        private int winsAmount;
        public int RoundsAmount {
            get => roundsAmount;
            set => roundsAmount = value > 0 ? value : 0;
        }
        public int WinsAmount
        {
            get => winsAmount;
            set => winsAmount = value > 0 ? value : 0;
        }
        public override string Achievements { get; set; }

        public Boxer(): base()
        {
            RoundsAmount = 0;
            WinsAmount = 0;
            Achievements = "No data";
        }
        public Boxer(string name, int age, string dateOfBirth, CountryInfo countryInfo, double height,
            double weight, string kindOfSport, SportRank sportRank, int roundsAmount, int winsAmount, string achievements)
            : base(name, age, dateOfBirth, countryInfo, height, weight, kindOfSport, sportRank)
        {
            RoundsAmount = roundsAmount;
            WinsAmount = winsAmount;
            Achievements = achievements;
        }

        public override void Action()
        {
            Console.WriteLine("Looking for a sparring partner");
        }
    }
}
