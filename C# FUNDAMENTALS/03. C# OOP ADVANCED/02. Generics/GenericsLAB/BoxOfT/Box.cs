using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Insert(0, element);
        }

        public T Remove()
        {
            var element = elements[0];
            elements.RemoveAt(0);
            return element;
        }
    }
}