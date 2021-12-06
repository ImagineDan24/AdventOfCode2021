using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day5Part2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\Test.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 3 Part 2...");

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

                    if (slope == 1)
                    {
                        int count = 0;
                        //6,4 -> 2,0
                        if (point1[0] > point2[0])
                        {
                            int[] x = new int[Math.Abs(point1[0] - point2[0]) + 1];
                            int[] y = new int[x.Length];
                            for (int j = point2[0]; j <= point1[0]; j++)
                            {
                                x[count] = j;
                                count++;
                            }
                            count = 0;
                            for(int j = point2[1]; j <= point1[1]; j++)
                            {
                                y[count] = j;
                                count++;
                            }
                            for (int j = 0; j < x.Length; j++)
                            {
                                var newPoint = new int[] { x[j], y[j] , 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                        else
                        {
                            //2,0 -> 6,4
                            int[] x = new int[Math.Abs(point1[0] - point2[0]) + 1];
                            int[] y = new int[x.Length];
                            for (int j = point1[0]; j <= point2[0]; j++)
                            {
                                x[count] = j;
                                count++;
                            }
                            count = 0;
                            for (int j = point1[1]; j <= point2[1]; j++)
                            {
                                y[count] = j;
                                count++;
                            }
                            for (int j = 0; j < x.Length; j++)
                            {
                                var newPoint = new int[] { x[j], y[j], 1 };
                                points = ListContainsAndIncrement(newPoint, points);
                            }
                        }
                    }
                    else
                    {
                        int[] x = new int[Math.Abs(point1[0] - point2[0]) + 1];
                        int count = 0;
                        if (point1[0] > point2[0])
                        {
                            for (int j = point2[0]; j <= point1[0]; j++)
                            {
                                x[count] = j;
                                count++;
                            }
                        }
                        else
                        {
                            for (int j = point1[0]; j <= point2[0]; j++)
                            {
                                x[count] = j;
                                count++;
                            }
                        }

                        int left = 0;
                        int right = x.Length - 1;

                        while (left <= x.Length - 1)
                        {
                            var newPoint = new int[] { x[left], x[right], 1 };
                            points = ListContainsAndIncrement(newPoint, points);
                            left++;
                            right--;
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

