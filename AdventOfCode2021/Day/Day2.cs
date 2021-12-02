using System;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\day2.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 2 Part A...");
            
            int horizontal = 0;
            int depth = 0;
            foreach (var line in lines)
            {
                var command = line.Split(' ')[0];
                var amount = int.Parse(line.Split(' ')[1]);
                if (command == "forward") horizontal += amount;
                if (command == "up") depth -= amount;
                if (command == "down") depth += amount;
            }
            Console.WriteLine("Answer: " + (depth * horizontal));


            Console.WriteLine("Commencing Day 2 Part B...");

            horizontal = 0;
            depth = 0;
            int aim = 0;
            foreach (var line in lines)
            {
                var command = line.Split(' ')[0];
                var amount = int.Parse(line.Split(' ')[1]);
                if (command == "down") aim += amount;
                if (command == "up") aim -= amount;
                if (command == "forward")
                {
                    horizontal += amount;
                    depth += (aim * amount);
                } 
            }
            Console.WriteLine("Answer: " + (depth * horizontal));
        }
    }
}

