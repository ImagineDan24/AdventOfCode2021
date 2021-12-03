using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021
{
    public static class Day3
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\test.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 3 Part A...");
            var bits = lines[0].Length;
            var zeroCount = new int[bits];
            var oneCount = new int[bits];

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '0') { zeroCount[i]++; }
                    else { oneCount[i]++; }
                }
            }

            var gammaBin = "";
            var epsilonBin = "";
            for (int i = 0; i < bits; i++)
            {
                if (zeroCount[i] > oneCount[i])
                {
                    gammaBin += '0';
                    epsilonBin += '1';
                }
                else
                {
                    gammaBin += '1';
                    epsilonBin += '0';
                }
            }

            Console.WriteLine("Answer: " + (Convert.ToInt32(gammaBin, 2) * Convert.ToInt32(epsilonBin, 2)));
            Console.WriteLine("Commencing Day 3 Part B...");


            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            foreach (var line in lines) 
            { 
                list.Add(line);
                list2.Add(line);
            }
            
            //oxygen generator rating calculation
            for (int i = 0; i < bits; i++)
            {
                if (list.Count == 1) break;

                int zeros = 0;
                int ones = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j][i] == '0') { zeros++; }
                    else { ones++; }
                }

                if (zeros > ones)
                {
                    int j = 0;
                    while (j < list.Count)
                    {
                        if (list[j][i] != '0')
                        {
                            list.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
                else if (zeros < ones)
                {
                    int j = 0;
                    while (j < list.Count)
                    {
                        if (list[j][i] != '1')
                        {
                            list.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
                else
                {
                    int j = 0;
                    while (j < list.Count)
                    {
                        if (list[j][i] != '1')
                        {
                            list.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
            }

            //CO2 scrubber Rating calculation
            for (int i = 0; i < bits; i++)
            {
                if (list2.Count == 1) break;

                int zeros = 0;
                int ones = 0;
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list2[j][i] == '0') { zeros++; }
                    else { ones++; }
                }

                if (zeros > ones)
                {
                    int j = 0;
                    while (j < list2.Count)
                    {
                        if (list2[j][i] != '1')
                        {
                            list2.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
                else if (zeros < ones)
                {
                    int j = 0;
                    while (j < list2.Count)
                    {
                        if (list2[j][i] != '0')
                        {
                            list2.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
                else
                {
                    int j = 0;
                    while (j < list2.Count)
                    {
                        if (list2[j][i] != '0')
                        {
                            list2.RemoveAt(j);
                            j--;
                        }
                        j++;
                    }
                }
            }
            Console.WriteLine("Answer: " + (Convert.ToInt32(list[0], 2) * Convert.ToInt32(list2[0], 2)));
        }
    }
}

