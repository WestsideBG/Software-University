 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            var fields = type.GetFields((BindingFlags) 62);

            string input;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                var fieldsToPrint = fields
                    .Where(f => f.Attributes.ToString().ToLower().Replace("family", "protected") == input).ToArray();

                if (input == "all")
                {
                    foreach (var fieldInfo in fields)
                    {
                        Console.WriteLine($"{fieldInfo.Attributes.ToString().ToLower().Replace("family", "protected")} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                }
                else
                {
                    foreach (var fieldInfo in fieldsToPrint)
                    {
                        Console.WriteLine($"{fieldInfo.Attributes.ToString().ToLower().Replace("family", "protected")} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                }

            }
        }
    }
}
