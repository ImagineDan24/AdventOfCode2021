using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public static class Day4Part1
    {
        public static void Main()
        {

            // ***DISCLAIMER: This code is absolute garbage and should not even be looked at I am so sorry.***

            var fileInput = @"..\..\..\Data\Day4.txt";
            var lines = File.ReadAllLines(fileInput);

            Console.WriteLine("Commencing Day 4 Part 1...");

            //read all the bingo numbers first and put them in an array
            var bingoNumbers = lines[0].Split(',').Select(Int32.Parse).ToList();
            
            int[][][] WinningCard = new int[5][][];
            int NumOfBingoNumbers = 99;
            int isBingo = 0;

            int j = 2; //start of first card
            while (j < lines.Length)
            {
                //make the bingo card into an array of arrays (also make a check to see if the number is marked)
                int[][] row = new int[5][];
                int[][][] card = new int[5][][];

                //create the card (I am having difficulty and this code makes me sad inside, please don't judge)
                var row0 = Regex.Replace(lines[j], @"\s+", " ").TrimStart(' ').Split(' ').Select(Int32.Parse).ToList();
                var row1 = Regex.Replace(lines[j + 1], @"\s+", " ").TrimStart(' ').Split(' ').Select(Int32.Parse).ToList();
                var row2 = Regex.Replace(lines[j + 2], @"\s+", " ").TrimStart(' ').Split(' ').Select(Int32.Parse).ToList();
                var row3 = Regex.Replace(lines[j + 3], @"\s+", " ").TrimStart(' ').Split(' ').Select(Int32.Parse).ToList();
                var row4 = Regex.Replace(lines[j + 4], @"\s+", " ").TrimStart(' ').Split(' ').Select(Int32.Parse).ToList();

                int[][] rowZero = new int[5][];
                int[][] rowOne = new int[5][];
                int[][] rowTwo = new int[5][];
                int[][] rowThree = new int[5][];
                int[][] rowFour = new int[5][];

                for (int n = 0; n < 5; n++)
                {
                    rowZero[n] = new int[] { row0[n], 0 };
                    rowOne[n] = new int[] { row1[n], 0 };
                    rowTwo[n] = new int[] { row2[n], 0 };
                    rowThree[n] = new int[] { row3[n], 0 };
                    rowFour[n] = new int[] { row4[n], 0 };
                }

                card[0] = rowZero;
                card[1] = rowOne;
                card[2] = rowTwo;
                card[3] = rowThree;
                card[4] = rowFour;

                //Check off marked numbers in the card one by one, after each number check for a bingo
                int count = 0;
                foreach (var number in bingoNumbers)
                {
                    if (isBingo == 1)
                    {
                        break;
                    }
                    count++;
                    for (int r = 0; r < card.Length; r++)
                    {
                        for (int n = 0; n < card[r].Length; n++)
                        {
                            if (card[r][n][0] == number)
                            {
                                card[r][n][1] = 1;
                            }
                        }
                    }

                    //check horizontal bingo
                    for (int r = 0; r < card.Length; r++)
                    {
                        int counter = 0;
                        for (int n = 0; n < card[r].Length; n++)
                        {
                            if (card[r][n][1] == 1)
                            {
                                counter++;
                            }
                        }
                        if (counter == 5)
                        {
                            isBingo = 1;
                        }
                    }
                    
                    //check vertical bingo
                    for (int r = 0; r < card.Length; r++)
                    {
                        int counter = 0;
                        for (int n = 0; n < card[r].Length; n++)
                        {
                            if (card[n][r][1] == 1)
                            {
                                counter++;
                            }
                        }
                        if (counter == 5)
                        {
                            isBingo = 1;
                        }
                    }
                }
                if (isBingo == 1)
                {
                    if (count < NumOfBingoNumbers)
                    {
                        WinningCard = card;
                        NumOfBingoNumbers = count;
                    }
                    isBingo = 0;
                }
                j += 6;
            }

            //bingo has been found, we have the card saved
            //find sum of all unmarked numbers on the card
            int sum = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int n = 0; n < 5; n++)
                {
                    if (WinningCard[r][n][1] == 0)
                    {
                        sum += WinningCard[r][n][0];
                    }
                }
            }

            Console.WriteLine("Answer: " + (sum * bingoNumbers[NumOfBingoNumbers - 1]));
        }
    }
}

