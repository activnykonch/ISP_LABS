using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Human : IComparable, ICloneable
    {
        public string DateOfBirth { get; }
        public string Name { get; }

        private int age;
        public int Age
        {
            get => age;
            set => age = value;
        }

        public Human()
        {
            Name = "No data";
            Age = 0;
            DateOfBirth = "No data";
        }
        public Human(string name, int age, string dateOfBirth)
        {
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine(Name + " Age: " + Age + " Date of birth: " + DateOfBirth);
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
