using System;
using System.Linq;

namespace Snowman
{
    class Program
    {
        static void Main(string[] args)
        {
            var snowmans = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (snowmans.Count > 1)
            {
                for (int i = 0; i < snowmans.Count; i++)
                {

                    if (snowmans.Count(x => x != -1) == 1)
                    {
                        break;
                    }

                    if (snowmans[i] == -1)
                    {
                        continue;
                    }

                    int attacker = i;
                    int target = snowmans[i] % snowmans.Count;

                    int diff = Math.Abs(attacker - target);

                    if (attacker == target)
                    {
                        //suicides
                        snowmans[attacker] = -1;
                        Console.WriteLine($"{attacker} performed harakiri");
                    }
                    else if (diff % 2 == 0)
                    {
                        //attacker wins
                        snowmans[target] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                    }
                    else 
                    {
                        // target wins
                        snowmans[attacker] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                    }
  
                }
                snowmans = snowmans.Where(x => x != -1).ToList();
            }
        }
    }
}
