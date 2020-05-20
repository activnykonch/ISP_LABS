using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    enum SportRank
    {
        NoRank,
        ThirdClassSportsman,
        SecondClassSportsman,
        FirstClassSportsman,
        CandidateForMasterOfSport,
        MasterOfSport
    }
    class Sportsmen: Human, ICompetitionPreparation
    {
        private double height;
        private double weight;
        public virtual string Achievements { get; set; }
        public string KindOfSport { get; set; }
        public SportRank SportRank { get; set; }
        public event EventHandler Preporation;
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                weight = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                height = value;
            }
        }

        public Sportsmen() :base()
        {
            Height = 0;
            Weight = 0;
            KindOfSport = "No data";
            SportRank = SportRank.NoRank;
        }

        public Sportsmen(string name, int age, string dateOfBirth, CountryInfo countryInfo, double height,
            double weight, string kindOfSport, SportRank sportRank) : base(name, age, dateOfBirth, countryInfo)
        {
            Height = height;
            Weight = weight;
            KindOfSport = kindOfSport;
            SportRank = sportRank;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(CountryInfo.OriginCountry + " " + Height + "m " + Weight + "kg " + KindOfSport + " " + SportRank);
        }

        public void Prepare()
        {
            Preporation?.Invoke(this, EventArgs.Empty);
        }

        private double GetSquareheight()
        {
            return System.Math.Pow(Height * Height, -1);
        }

        public static double CalculateMassIndex(Sportsmen sportsman)
        {
            if (sportsman.Height == 0) return 0;
            else return sportsman.Weight * sportsman.GetSquareheight();
        }

        public virtual void Action()
        {
            Console.WriteLine("Doing action");
        }

        public void Weighing()
        {
            Console.WriteLine("The control weight of {0} is {1} kg", Name, Weight);
        }

        public void WarmingUp()
        {
            Action();
        }

        public void DefiningMood()
        {
            Console.WriteLine("My coach said that I AM THE MACHINE!!!!");
        }
    }
}
