using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleDatabase
{
    public class Database
    {
        private const int Capacity = 16;
        private Person[] db;
        private int index;

        public Database(params Person[] data)
        {
            if (data.Length > Capacity)
            {
                throw new InvalidOperationException();
            }

            db = new Person[Capacity];

            this.index = -1;

            foreach (var person in data)
            {
                this.Add(person);
            }
        }

        public void Add(Person person)
        {
            if (index == -1)
            {
                this.db[++index] = person;
            }
            else
            {
                if (index + 1 == Capacity)
                {
                    throw new InvalidOperationException("Database is full!");
                }

                for (int i = 0; i <= index; i++)
                {
                    if (db[i].Id == person.Id || db[i].Username == person.Username)
                    {
                        throw new InvalidOperationException();
                    }
                }

                this.db[++index] = person;
            }     
        }

        public Person Remove()
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            var result = this.db[this.index];
            this.db[this.index] = default(Person);
            this.index--;

            return result;
        }

        public Person FindByUsername(string username)
        {
            if (username is null)
            {
                throw new InvalidOperationException("Username is not valid!");
            }

            if (!this.db.Any(p => p != null && p.Username == username))
            {
                throw new InvalidOperationException($"{username} is not found!");
            }

            return this.db.First(p => p != null && p.Username == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Id is not valid!");
            }

            if (!this.db.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException($"{id} is not found!");
            }

            return this.db.First(p => p != null && p.Id == id);
        }

        public Person[] Fletch()
        {
            return this.db.Take(index+1).ToArray();
        }
    }
}