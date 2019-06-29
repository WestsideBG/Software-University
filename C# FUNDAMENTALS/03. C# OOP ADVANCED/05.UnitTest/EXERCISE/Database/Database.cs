using System;
using System.Linq;

namespace Database
{
    public class Database
    {
        private const int Capacity = 16;
        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[Capacity];

            this.index = -1;
        }

        public Database(int[] inputData) : this()
        {
            if (inputData.Length > Capacity)
            {
                throw new InvalidOperationException("Data is too long!");
            }

            for (int i = 0; i < inputData.Length; i++)
            {
                this.data[i] = inputData[i];
                this.index++;
            }
        }

        public void Add(int number)
        {
            if (this.index + 1 == Capacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.data[++index] = number;
        }

        public void Remove()
        {
            if (this.index == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[index] = 0;
            this.index--;
        }

        public int[] Fetch()
        { 
            return this.data.Take(this.index + 1).ToArray();   
        }
    }
}