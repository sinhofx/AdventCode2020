using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem5
    {
        public static int part1(List<string> input)
        {
            string binRow;
            string binCol;
            int maxID = 0;
            foreach (string pass in input)
            {
                binRow = "";
                binCol = "";
                foreach (char c in pass)
                {
                    switch (c)
                    {
                        case 'F':
                            binRow += '0';
                            break;
                        case 'B':
                            binRow += '1';
                            break;
                        case 'L':
                            binCol += '0';
                            break;
                        case 'R':
                            binCol += '1';
                            break;
                    }
                }
                int row = Convert.ToInt32(binRow, 2);
                int col = Convert.ToInt32(binCol, 2);
                if (row * 8 + col > maxID)
                {
                    maxID = (row * 8 + col);
                }

            }

            return maxID;
        }

        public static int part2(List<string> input)
        {
            string binRow;
            string binCol;
            List<int> seatList = new List<int>();
            foreach (string pass in input)
            {
                binRow = "";
                binCol = "";
                foreach (char c in pass)
                {
                    switch (c)
                    {
                        case 'F':
                            binRow += '0';
                            break;
                        case 'B':
                            binRow += '1';
                            break;
                        case 'L':
                            binCol += '0';
                            break;
                        case 'R':
                            binCol += '1';
                            break;
                    }
                }
                int row = Convert.ToInt32(binRow, 2);
                int col = Convert.ToInt32(binCol, 2);
                seatList.Add(row * 8 + col);
            }
            int[] arrSeatList = seatList.ToArray();
            Helper.insertionSort(arrSeatList);
            for (int i = 0; i < arrSeatList.Length - 1; i++)
            {
                if (arrSeatList[i] + 1 != arrSeatList[i + 1])
                {
                    return arrSeatList[i] + 1;
                }
            }
            return 0;
        }
    }
}
