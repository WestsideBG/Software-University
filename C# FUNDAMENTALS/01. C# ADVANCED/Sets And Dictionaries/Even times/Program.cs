using System;
using System.Collections.Generic;

namespace Even_times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(currNum))
                {
                    nums.Add(currNum, 0);
                }

                nums[currNum]++;
            }

            foreach (var num in nums)
            {

                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    return;
                }

            }
        }
    }
}
