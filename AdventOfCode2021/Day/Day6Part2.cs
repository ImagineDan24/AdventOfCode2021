using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day6Part2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day6.txt";
            var input = File.ReadAllLines(fileInput)[0].Split(',').Select(int.Parse).ToList();

            long[] fishies = new long[9];
            int days = 256;

            for(int i = 0; i < input.Count; i++)
            { 
                fishies[input[i]]++;
            }

            for(int i = 0; i < days; i++)
            {
                long tmpFish = fishies[0];
                Array.Copy(fishies, 1, fishies, 0, fishies.Length - 1);

                fishies[6] += tmpFish;
                fishies[8] = tmpFish;
            }

            long count = 0;
            for (int i = 0; i < fishies.Length; i++)
            { 
                count += fishies[i];
            }

            Console.WriteLine("Answer: " + count);
        }
    }
}
