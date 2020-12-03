using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem3
    {
        public static int part1(List<string> input)
        {
            string[] arrInput = input.ToArray();
            char[,] map = new char[arrInput[0].Length, arrInput.Length];
            for (int y = 0; y < arrInput.Length; y++)
            {
                for (int x = 0; x < arrInput[0].Length; x++)
                {
                    map[x, y] = arrInput[y][x];
                }
            }

            int count = 0;
            int xPos = 0;
            for (int y = 1; y < arrInput.Length; y++)
            {
                xPos = (xPos + 3) % arrInput[0].Length;
                if (map[xPos, y].Equals('#'))
                {
                    count++;
                }

            }

            return count;
        }
        public static long part2(List<string> input)
        {
            string[] arrInput = input.ToArray();
            char[,] map = new char[arrInput[0].Length, arrInput.Length];
            for (int y = 0; y < arrInput.Length; y++)
            {
                for (int x = 0; x < arrInput[0].Length; x++)
                {
                    map[x, y] = arrInput[y][x];
                }
            }

            int[,] factors = new int[,] {{1, 1}, {3, 1}, {5, 1}, {7, 1}, {1, 2}};
            int count;
            long result = 1;
            int xPos;

            for (int f = 0; f < 5; f++)
            {
                count = 0;
                xPos = 0;
                for (int y = factors[f, 1]; y < arrInput.Length; y += factors[f, 1])
                {
                    xPos = (xPos + factors[f, 0]) % arrInput[0].Length;
                    if (map[xPos, y].Equals('#'))
                    {
                        count++;
                    }
                }
                result *= count;
            }

            return result;
        }


    }
}
