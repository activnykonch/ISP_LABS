using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    class Human
    {
        private int age;
        private double height;
        private double weight;
        private int winsAmount;

        public string Name { get; set; }
        public string KindOfSport { get; set; }
        public string SkillLevel { get; set; }
        public string Achievements { get; set; }

        public int Age
        {
            get => age;
            set => age = value > 0 ? value : 0;
        }

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

        public int WinsAmount
        {
            get => winsAmount;
            set => winsAmount = value > 0 ? value : 0;
        }

        public Human()
        {
            Name = "No info";
            KindOfSport = "No info";
            SkillLevel = "No info";
            Achievements = "No info";
            Age = 0;
            Height = 0;
            Weight = 0;
            WinsAmount = 0;
        }

        public Human(string name, int age, double height, double weight, string kindOfSport, 
            string skillLevel, string achievements, int winsAmount)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            KindOfSport = kindOfSport;
            SkillLevel = skillLevel;
            Achievements = achievements;
            WinsAmount = winsAmount;
        }

        private double GetSquareheight()
        {
            return System.Math.Pow(Height * Height, -1);
        }

        public static double CalculateMassIndex(Human human)
        {
            if (human.Height == 0) return 0;
            else return human.Weight * human.GetSquareheight();
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Age: " + Age + ", Height: " + Height + " m, Weight: " + Weight +
                " kg, Mass index: " + ", Kind of sport: " + KindOfSport + 
                ", Skill level: " + SkillLevel + ", Achievements: "
                + Achievements + ", Wins amount: " + WinsAmount;
        }
    }
}
