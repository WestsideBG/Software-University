namespace CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CustomList<string> customList = new CustomList<string>();

            string element = "";

            string[] args = Console.ReadLine().Split();

            while (args[0] != "END")
            {
                string command = args[0];
                switch (command)
                {
                    case "Add":
                        element = args[1];
                        customList.Add(element);
                        break;
                    case "Remove":
                        int index = int.Parse(args[1]);
                        customList.Remove(index);
                        break;
                    case "Contains":
                        element = args[1];
                        Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        int index1 = int.Parse(args[1]);
                        int index2 = int.Parse(args[2]);
                        customList.Swap(index1, index2);
                        break;
                    case "Greater":
                        element = args[1];
                        Console.WriteLine(customList.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Sort":
                        customList.Sort();
                        break;
                    case "Print":
                        foreach (var item in customList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }

                args = Console.ReadLine().Split();
            }
        }
    }
}
