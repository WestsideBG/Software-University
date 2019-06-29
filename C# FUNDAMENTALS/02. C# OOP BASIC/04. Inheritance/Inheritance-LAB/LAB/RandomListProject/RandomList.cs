using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random Random { get; set; }

        public RandomList()
        {
            Random = new Random();
        }

        public string GetRandomString()
        {
            var index = Random.Next(0, this.Count - 1);
            string result = this[index];
            RemoveAt(index);
            return result;
        }
    }
}
