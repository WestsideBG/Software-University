using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListIterator
{
    public class ListIterator<T> : IListIterator<T>
    {
        private int index;
        private T[] list;

        public ListIterator(params T[] elements)
        {
            this.Create(elements);
        }

        private void Create(params T[] elements)
        {
            list = elements;
        }

        public bool Move()
        {
            if (this.index < this.list.Length - 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (list.Any())
            return $"{this.list[this.index]}";

            throw new InvalidOperationException("Invalid Operation!");
        }

        public bool HasNext()
        {
            if (this.index < this.list.Length - 1)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}