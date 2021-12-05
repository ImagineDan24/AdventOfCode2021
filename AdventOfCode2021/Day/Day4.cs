using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day4
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\test.txt";
            var lines = File.ReadAllLines(fileInput);

            //This is a guess on how to complete this question:
            //read all the bingo numbers first and put them in an array
            //go through each table, put into an array of arrays and check off all the numbers until there is a bingo (horizontal or vertical)
            //count how many bingo numbers it takes for that card to get a bingo
            //if it takes a lower amount of bingo numbers to get the bingo, then store that card and mark down the number it takes for bingo
            //continue through each card until the end
            //then calculate the answer

            Console.WriteLine("Commencing Day 4 Part A...");


            Console.WriteLine("Answer: ");

            Console.WriteLine("Commencing Day 4 Part B...");


            Console.WriteLine("Answer: ");
        }
    }
}

