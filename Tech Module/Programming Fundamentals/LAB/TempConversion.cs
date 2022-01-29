using System;

namespace Methods__Debugging_and_Troubleshooting_Code
{
    internal class TempConversion
    {
        internal void Run()
        {
            PrintIntroduction();
            string type = GetType();
            double temp = GetTemperature(type);
            int convertedTemp = ConvertTemp(type, temp);
            PrintTemperature(type,convertedTemp);
        }

        private void PrintTemperature(string type, double convertedTemp)
        {
            if (type == "1")
            {
                Console.WriteLine($"RESULT: {convertedTemp}°F");
            }
            else if (type == "2")
            {
                Console.WriteLine($"RESULT: {convertedTemp}°C");
            }
        }

        private int ConvertTemp(string type, double temp)
        {
            double convertedTemp = 0;
            if (type == "1")
            {
                convertedTemp = (temp - 32) * 5 / 9;
            }
            else if (type == "2")
            {
                convertedTemp = (temp * 9) / 5 + 32;
            }
            
            return (int)Math.Round(convertedTemp,MidpointRounding.AwayFromZero);
        }

        private double GetTemperature(string type)
        {
            double temp = 0;
            if (type == "1")
            {
                Console.WriteLine("Please, provide a temperture in Farenheit:");
                temp = Convert.ToDouble(Console.ReadLine());
            }
            else if (type == "2")
            {
                Console.WriteLine("Please, provide a temperture in Celsius:");
                temp = Convert.ToDouble(Console.ReadLine());
            }
            return temp;
        }

        private new string GetType()
        {
            Console.WriteLine("Select type:");
            Console.WriteLine("01. Farenheit to Celsius");
            Console.WriteLine("02. Ceslius to Farenheit");
            string type = Console.ReadLine();
            if (type.Contains("1"))
            {
                type = "1";
            }
            else if (type.Contains("2"))
            {
                type = "2";
            }

            return type;
        }
        private void PrintIntroduction()
        {
            Console.WriteLine("This method converts temperature from Farenheit to Celsius and vice versa");
        }
    }
}