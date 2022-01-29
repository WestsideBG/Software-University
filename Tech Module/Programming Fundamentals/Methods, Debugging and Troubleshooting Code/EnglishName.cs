namespace Methods__Debugging_and_Troubleshooting_Code
{
    using System;
    internal class EnglishName
    {
        public EnglishName()
        {
        }
        
        internal void Run()
        {
            int inputNumber = GetInputNumber();
            int lastDigit = GetLastDigit(inputNumber);
            string englishName = GetEnglishName(lastDigit);
            PrintOutput(englishName);
        }

        private void PrintOutput(string englishName)
        {
            Console.WriteLine($"The English name of the last digit is: {englishName}");
        }

        private string GetEnglishName(int lastDigit)
        {
            switch (lastDigit)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
            }
            return "Error";
        }

        private int GetInputNumber()
        {
            Console.WriteLine("This method returns a English name of the last digit of number.");
            Console.WriteLine("Please, provide a number:");
            int number = int.Parse(Console.ReadLine());
            return number;

        }

        private int GetLastDigit(int number)
        {
            return number % 10;
        }
    }
}