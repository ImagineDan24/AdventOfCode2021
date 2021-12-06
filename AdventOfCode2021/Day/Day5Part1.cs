using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day5Part1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day5.txt";
            var lines = File.ReadAllLines(fileInput);

            //check first if the line is horizontal or vertical (if x1=x2 or y1=y2)
            //add all the points from x1,y1 to x2,y2 to an array(ex: 1,1 -> 1,3 then add 1,1 1,2 and 1,3)
            //add a counter on each point and if it comes up multiple times then you increment the counter
            //search for all points that have their counter >= 2

            Console.WriteLine("Commencing Day 5 Part A...");

            List<int[]> points = new List<int[]>();
            
            for (int i = 0; i < lines.Length; i++)
            {
                //point = (x, y)
                int[] point1 = new int[] { int.Parse(lines[i].Split(" -> ")[0].Split(',')[0]), int.Parse(lines[i].Split(" -> ")[0].Split(',')[1])};
                int[] point2 = new int[] { int.Parse(lines[i].Split(" -> ")[1].Split(',')[0]), int.Parse(lines[i].Split(" -> ")[1].Split(',')[1])};

                //check if the line will be horizontal or vertical
                if (point1[0] == point2[0] || point1[1] == point2[1])
                {
                    if (point1[0] == point2[0]) //vertical
                    {
                        //check which y value is greater
                        if (point1[1] > point2[1])
                        {
                            for (int j = point2[1]; j <= point1[1]; j++)
                            {
                                var newPoint = new int[] { point1[0], j, 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                        else if (point1[1] < point2[1])
                        {
                            for (int j = point1[1]; j <= point2[1]; j++)
                            {
                                var newPoint = new int[] { point1[0], j, 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                        else //singular point
                        {
                            var newPoint = new int[] { point1[0], point1[1], 1 };
                            points = ListContainsAndIncrement(newPoint, points);
                        }
                    }
                    else if (point1[1] == point2[1]) //horizontal
                    {
                        //check which x value is greater
                        if (point1[0] > point2[0])
                        {
                            for (int j = point2[0]; j <= point1[0]; j++)
                            {
                                var newPoint = new int[] { j, point1[1], 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                        else if (point1[0] < point2[0])
                        {
                            for (int j = point1[0]; j <= point2[0]; j++)
                            {
                                var newPoint = new int[] { j, point1[1], 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                    }
                }
            }

            int counter = 0;
            foreach (var point in points)
            {
                if (point[2] >= 2)
                {
                    counter++;
                }
            }



            Console.WriteLine("Answer: " + counter);

            Console.WriteLine("Commencing Day 3 Part B...");


            Console.WriteLine("Answer: ");
        }

        public static List<int[]> ListContainsAndIncrement(int[] point, List<int[]> list)
        {
            
            if (list.FindIndex(x => x[0] == point[0] && x[1] == point[1]) != -1)
            {
                list[list.FindIndex(x => x[0] == point[0] && x[1] == point[1])][2]++;
            }
            else
            {
                list.Add(point);
            }
            return list;
        }
    }
}

