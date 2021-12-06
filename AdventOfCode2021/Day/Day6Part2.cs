using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day6Part2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Test.txt";
            var lines = File.ReadAllLines(fileInput);

            var fishList = lines[0].Split(',').Select(int.Parse).ToList();

            //I can't do it ;(

            Console.WriteLine("Answer: " + fishList.Length);
        }
    }
}
