using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {

            int[] inputNums = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] numsInJagged = new int[3][];
            List<int> zero = new List<int>();
            List<int> one = new List<int>();
            List<int> two = new List<int>();
            
            for (int i = 0; i < inputNums.Length; i++)
            {
                int currentNum = inputNums[i];
                if (Math.Abs(currentNum) % 3 == 0)
                {
                    zero.Add(currentNum); 
                }
                else if (Math.Abs(currentNum) % 3 == 1)
                {
                    one.Add(currentNum);

                }
                else if (Math.Abs(currentNum) % 3 == 2)
                {
                    two.Add(currentNum);
                }
            }

            numsInJagged[0] = zero.ToArray();
            numsInJagged[1] = one.ToArray();
            numsInJagged[2] = two.ToArray();


            Console.WriteLine(String.Join(" ",numsInJagged[0]));
            Console.WriteLine(String.Join(" ",numsInJagged[1]));
            Console.WriteLine(String.Join(" ",numsInJagged[2]));


            //int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //int[] zero = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            //int[] one = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            //int[] two = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            //Console.WriteLine(string.Join(" ", zero));
            //Console.WriteLine(string.Join(" ", one));
            //Console.WriteLine(string.Join(" ", two));
        }
    }
}
