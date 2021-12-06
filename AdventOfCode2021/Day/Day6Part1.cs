using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day6Part1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day6.txt";
            var lines = File.ReadAllLines(fileInput);

            var fishList = lines[0].Split(',').Select(int.Parse).ToList();
            int days = 80;
            for (int i = 1; i <= days; i++)
            {
                Console.WriteLine("Currently on Day " + i);
                int length = fishList.Count;
                for (int j = 0; j < length; j++)
                {
                    fishList = UpdateFishList(fishList, j);
                }
            }
            Console.WriteLine("Answer: " + fishList.Count);
        }

        public static List<int> UpdateFishList(List<int> list, int index)
        {
            if (list[index] == 0)
            {
                list[index] = 6;
                list.Add(8);
            }
            else
            {
                list[index]--;
            }

            return list;
        }
    }
}
