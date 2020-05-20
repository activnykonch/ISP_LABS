using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
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
    class Human : IComparable, ICloneable
    {
        public string DateOfBirth { get; }
        public string Name { get; }
        public CountryInfo CountryInfo { get; set; }
        public delegate void CountryInfoHandler(CountryInfo countryInfo);
        public event CountryInfoHandler ChangeCountry;

        private int age;
        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                age = value;
            }
        }

        public Human()
        {
            Name = "No data";
            Age = 14;
            DateOfBirth = "No data";
            CountryInfo = new CountryInfo("No data", "No data");
        }
        public Human(string name, int age, string dateOfBirth, CountryInfo countryInfo)
        {
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;
            CountryInfo = countryInfo;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine(Name + " Age: " + Age + " Date of birth: " + DateOfBirth);
        }

        public void SetCountryInfo(CountryInfo countryInfo)
        {
            CountryInfo = countryInfo;
        }
        public void SetChangedCountry(CountryInfo country)
        {
            ChangeCountry?.Invoke(country);
            CountryInfo = country;
        }

        public int CompareTo(object obj)
        {
            if (obj is Human human)
            {
                return this.Age.CompareTo(human.Age);
            }
            else
            {
                throw new ArgumentException("Parameter is not a Human!");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
