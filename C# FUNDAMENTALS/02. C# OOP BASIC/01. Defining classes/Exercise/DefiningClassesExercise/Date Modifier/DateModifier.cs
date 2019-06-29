using System;
using System.Linq;

namespace DefiningClasses
{
    public class DateModifier
    {  
        private int difference;

        public int Difference
        {
            get { return difference; }
            set { difference = value; }
        }


        public double GetDifference(string firstDate, string secondDate)
        {
            int[] firstDateArgs = firstDate.Split().Select(int.Parse).ToArray();
            int firstDateYear = firstDateArgs[0];
            int firstDateMonth = firstDateArgs[1];
            int firstDateDay = firstDateArgs[2];

            int[] secondDateArgs = secondDate.Split().Select(int.Parse).ToArray();
            int secondDateYear = secondDateArgs[0];
            int secondDateMonth = secondDateArgs[1];
            int secondDateDay = secondDateArgs[2];

            DateTime firstDateTime = new DateTime(firstDateYear, firstDateMonth, firstDateDay);
            DateTime secondDateTime = new DateTime(secondDateYear, secondDateMonth, secondDateDay);

            return (firstDateTime - secondDateTime).TotalDays;
        }

    }
    
}