using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day5Part2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Day5.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 5 Part 2...");

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
                else if (((point2[1] - point1[1]) / (point2[0] - point1[0])) == 1 || ((point2[1] - point1[1]) / (point2[0] - point1[0])) == -1) //diagonal
                {
                    var slope = (point2[1] - point1[1]) / (point2[0] - point1[0]);

                    /*
                     * Diagonal Cases
                     * 
                     * bottom left to top right (slope == 1)
                     * (2,0) -> (6,4)
                     *                                          (2,0) (3,1) (4,2) (5,3) (6,4)
                     * top right to bottom left (slope == 1)
                     * (6,4) -> (2,0)
                     * 
                     * bottom right to top left (slope == -1)
                     * (9,7) -> (7,9)
                     *                                          (7,9) (8,8) (9,7)
                     * top left to bottom right (slope == -1)
                     * (7,9) -> (9,7)
                     */
                    if (slope == 1)
                    {
                        if (point1[0] > point2[0])
                        {
                            int x = point2[0];
                            int y = point2[1];
                            while (x <= point1[0])
                            {
                                var newPoint = new int[] { x , y , 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                                x++;
                                y++;
                            }
                        }
                        else
                        {
                            int x = point1[0];
                            int y = point1[1];
                            while (x <= point2[0])
                            {
                                var newPoint = new int[] { x, y, 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                                x++;
                                y++;
                            }
                        }
                    }
                    else
                    {
                        if (point1[0] > point2[0])
                        {
                            int x = point2[0];
                            int y = point2[1];
                            while (x <= point1[0])
                            {
                                var newPoint = new int[] { x, y, 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                                x++;
                                y--;
                            }
                        }
                        else
                        {
                            int x = point1[0];
                            int y = point1[1];
                            while (x <= point2[0])
                            {
                                var newPoint = new int[] { x, y, 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                                x++;
                                y--;
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
