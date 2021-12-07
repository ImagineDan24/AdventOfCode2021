using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day7Part1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day7.txt";
            var input = File.ReadAllLines(fileInput)[0].Split(',').Select(int.Parse).ToList();

            int bestFuel = 1000000000;
            for (int i = 0; i < input.Max(); i++)
            {
                int fuel = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    int low; int high;
                    if (input[j] > i) { low = i; high = input[j]; }
                    else { low = input[j]; high = i; }

                    for (int k = low; k < high; k++)
                    {
                        fuel += 1;
                    }
                }

                if (fuel < bestFuel) { bestFuel = fuel; }
            }

            Console.WriteLine("Answer: " + bestFuel);
        }
    }
}
