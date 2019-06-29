namespace Stack
{
    using System.Collections;
    using System.Collections.Generic;
    using System;


    public class Stack<T> : IEnumerable<T>
    {

        private Node<T> topElement;

        public Stack()
        {
            this.topElement = null;
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.Element = element;
                this.Previous = null;
            }

            public T Element { get; set; }
            public Node<T> Previous { get; set; }
        }

        public void Push(T element)
        {
            Node<T> newElement = new Node<T>(element);

            if (this.topElement == null)
            {
                this.topElement = newElement;
            }
            else
            {
                Node<T> prevElement = this.topElement;
                this.topElement = newElement;
                this.topElement.Previous = prevElement;
            }
        }

        public T Pop()
        {
            if (this.topElement == null)
            {
                throw new InvalidOperationException("No elements");
            }

            T returnValue = this.topElement.Element;
            Node<T> currentTopElement = this.topElement;
            this.topElement = currentTopElement.Previous;
            currentTopElement = null;
            return returnValue;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.topElement;

            while (current != null)
            {
                yield return current.Element;

                current = current.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}