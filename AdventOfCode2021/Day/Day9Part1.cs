using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public static class Day9Part1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day9.txt";
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

            int risk = 0;

            //go through each int in the cave and compare the int's above, below, and to the sides
            //if it is the lowest, then that is a 'low point' and we add this int + 1 to a running risk level counter
            for (int i = 0; i < cave.Length; i++)
            {
                for (int j = 0; j < cave[0].Length; j++)
                {
                    var current = cave[i][j];

                    //regular Case
                    if (i != 0 && i != cave.Length - 1 && j != 0 && j != cave[0].Length - 1)
                    {
                        var above = cave[i - 1][j];
                        var below = cave[i + 1][j];
                        var left = cave[i][j - 1];
                        var right = cave[i][j + 1];
                        
                        if (current < above && current < below && current < left && current < right)
                        {
                            risk += current + 1;
                        }
                    }

                    //special cases
                    else
                    {
                        //edge case: left side (not corners)
                        if (i != 0 && i != cave.Length - 1 && j == 0)
                        {
                            var above = cave[i - 1][j];
                            var below = cave[i + 1][j];
                            var right = cave[i][j + 1];

                            if (current < above && current < below && current < right)
                            {
                                risk += current + 1;
                            }
                        }

                        //edge case: right side (not corners)
                        if (i != 0 && i != cave.Length - 1 && j == cave[0].Length - 1)
                        {
                            var above = cave[i - 1][j];
                            var below = cave[i + 1][j];
                            var left = cave[i][j - 1];

                            if (current < above && current < below && current < left)
                            {
                                risk += current + 1;
                            }
                        }

                        //edge case: top row
                        if (i == 0)
                        {
                            var below = cave[i + 1][j];

                            //edge case: middle
                            if (j != 0 && j != cave[0].Length - 1)
                            {
                                var right = cave[i][j + 1];
                                var left = cave[i][j - 1];

                                if (current < below && current < right && current < left)
                                {
                                    risk += current + 1;
                                }
                            }

                            //edge case: left side
                            if (j == 0)
                            {
                                var right = cave[i][j + 1];

                                if (current < below && current < right)
                                {
                                    risk += current + 1;
                                }
                            }

                            //edge case: right side
                            else if (j == cave[0].Length - 1)
                            {
                                var left = cave[i][j - 1];

                                if (current < below && current < left)
                                {
                                    risk += current + 1;
                                }
                            }

                        }

                        //edge case: bottom row
                        else if (i == cave.Length - 1)
                        {
                            var above = cave[i - 1][j];

                            //edge case: middle
                            if (j != 0 && j != cave[0].Length - 1)
                            {
                                var right = cave[i][j + 1];
                                var left = cave[i][j - 1];

                                if (current < above && current < right && current < left)
                                {
                                    risk += current + 1;
                                }
                            }

                            //edge case: left side
                            if (j == 0)
                            {
                                var right = cave[i][j + 1];

                                if (current < above && current < right)
                                {
                                    risk += current + 1;
                                }
                            }

                            //edge case: right side
                            else if (j == cave[0].Length - 1)
                            {
                                var left = cave[i][j - 1];

                                if (current < above && current < left)
                                {
                                    risk += current + 1;
                                }
                            }
                        }
                    }
                }
            }


            Console.WriteLine("Answer: " + risk);
        }
    }
}
