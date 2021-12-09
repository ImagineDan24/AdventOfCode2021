using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day9Part2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Test.txt";
            var lines = File.ReadAllLines(fileInput);

            int[][] cave = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                int[] row = new int[lines[0].Length];
                for (int j = 0; j < lines[0].Length; j++)
                {
                    row[j] = lines[i][j] - '0';
                }
                cave[i] = row;
            }

            Console.WriteLine("Answer: ");
        }
    }
}
