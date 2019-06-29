namespace CustomList
{
    using System;
    using System.Collections;
    using System.Text;
    using CustomList.Contracts;

    public class CustomList<T> : ICustomList<T>, IEnumerable
        where T : IComparable<T>

    {
        private const int defaultCapacity = 4;

        public int Count { get; private set; }
        private T[] array;

        public CustomList()
        {
            array = new T[defaultCapacity];
        }

        public void Add(T element)
        {
            if (array.Length == this.Count)
            {
                Resize();
            }

            this.array[this.Count++] = element;
        }

        public T Remove(int index)
        {
            T item = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            if (this.array.Length != this.Count)
            {
                this.array[this.Count] = default(T);
            }

            return item;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int index1, int index2)
        {
            T tempValue = this.array[index1];

            this.array[index1] = this.array[index2];
            this.array[index2] = tempValue;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element) > 0)
                    counter++;
            }

            return counter;
        }

        public T Max()
        {
            T maxValue = default(T);

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxValue) > 0)
                    maxValue = this.array[i];
            }

            return maxValue;
        }

        public T Min()
        {
            T minValue = this.array[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minValue) < 0)
                    minValue = this.array[i];
            }

            return minValue;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (this.array[i].CompareTo(this.array[j]) > 0)
                    {
                        T tempValue = this.array[i];

                        this.array[i] = this.array[j];
                        this.array[j] = tempValue;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(this.array[i].ToString());
            }

            return sb.ToString().Trim();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.array[i];
            }

            this.array = tempArray;
        }
    }
}