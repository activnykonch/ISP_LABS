using System;
using System.Collections.Generic;
using System.Text;

namespace lab5
{
    abstract class Human
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
    }
}
