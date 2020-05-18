using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    struct CountryInfo
    {
        public string Country { get; }
        public string OriginCountry { get; }

        public CountryInfo(string country, string originCountry)
        {
            Country = country;
            OriginCountry = originCountry;
        }
    }
    enum SportRank
    {
        NoRank,
        ThirdClassSportsman,
        SecondClassSportsman,
        FirstClassSportsman,
        CandidateForMasterOfSport,
        MasterOfSport
    }
    class Sportsmen: Human
    {
        private double height;
        private double weight;
        public virtual string Achievements { get; set; }
        public string KindOfSport { get; set; }
        public CountryInfo CountryInfo { get; set; }
        public SportRank SportRank { get; set; }
        public double Weight
        {
            get => weight;
            set => weight = value > 0 ? value : 0;
        }

        public double Height
        {
            get => height;
            set => height = value > 0 ? value : 0;
        }

        public Sportsmen() :base()
        {
            Height = 0;
            Weight = 0;
            KindOfSport = "No data";
            CountryInfo = new CountryInfo("", "");
            SportRank = SportRank.NoRank;
        }

        public Sportsmen(string name, int age, string dateOfBirth, CountryInfo countryInfo, double height,
            double weight, string kindOfSport, SportRank sportRank) : base(name, age, dateOfBirth)
        {
            Height = height;
            Weight = weight;
            KindOfSport = kindOfSport;
            SportRank = sportRank;
            CountryInfo = countryInfo;
        }

        public void SetCountryInfo(CountryInfo countryInfo)
        {
            CountryInfo = countryInfo;
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
    }
}
