using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var instance = Activator.CreateInstance(type, true);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string methodName = input.Split("_")[0];
                int value = int.Parse(input.Split("_")[1]);

                var method = type.GetMethods((BindingFlags) 62).First(m => m.Name == methodName);

                method.Invoke(instance, new Object[] {value});

                var result = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "innerValue").GetValue(instance);

                Console.WriteLine(result);
            }
        }
    }
}
