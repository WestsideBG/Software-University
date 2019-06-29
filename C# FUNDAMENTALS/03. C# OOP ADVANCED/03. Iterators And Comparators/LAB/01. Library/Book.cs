using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
    {
        public string Title { get; private set; }
        public int Year { get; private set; }
        private List<string> Authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}