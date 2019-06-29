﻿namespace Farm.Animals
{
    using System;

    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Gender
        {
            get { return gender; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                gender = value;
            }
        }


        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }



        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Some sound");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }

    }
}
