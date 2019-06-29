using System;

namespace GenericBox
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    where T : IComparable<T>
    {
        public Box(List<T> messages)
        {
            this.Messages = messages;
        }

        public List<T> Messages { get; set; }

        public int Compare(T item)
        {
            int count = 0;
            foreach (var message in Messages)
            {
                if (message.CompareTo(item) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var message in this.Messages)
            {
                sb.AppendLine($"{message.GetType().FullName}: {message}");
            }

            return sb.ToString().Trim();
        }
    }
}