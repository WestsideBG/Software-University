using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class SignOfNum
    {
        public SignOfNum()
        {
        }

        internal void Run()
        {
            int num = GetNum();
            string sign = GetSign(num);
            PrintSign(sign);
        }

        private void PrintSign(string sign)
        {
            Console.WriteLine($"The sign of the provided number is: {sign}");
        }

        private string GetSign(int num)
        {
            if (num < 0)
            {
                return "NEGATIVE";
            }
            else if(num > 0)
            {
                return "POSITIVE";
            }
            else
            {
                return "ZERO";
            }
        }

        private int GetNum()
        {
            Console.WriteLine("This method returns the sign of the provided number. (POSITIVE/NEGATIVE/ZERO)");
            Console.WriteLine("Please, provide a number:");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
    }
}