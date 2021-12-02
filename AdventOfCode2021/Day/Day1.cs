using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\day1.txt";
            List<int> list = new List<int>();
            var lines = File.ReadAllLines(fileInput);

            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(int.Parse(lines[i]));
            }

            Console.WriteLine("Commencing Day 1 Part A...");

            int counter = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > list[i - 1]) counter++;
            }

            Console.WriteLine("Answer: " + counter);
            Console.WriteLine("Commencing Day 1 Part B...");

            counter = 0;
            for (int i = 0; i < list.Count - 3; i++)
            {
                if (list[i + 1] + list[i + 2] + list[i + 3] > list[i] + list[i + 1] + list[i + 2]) counter++;
            }
            Console.WriteLine("Answer: " + counter);
        }
    }
}

