using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem1
    {
        const int year = 2020;
        public static int part1(List<string> input)
        {
            List<int> intInput = new List<int>();
            foreach (string s in input)
            {
                intInput.Add(Int32.Parse(s));
            }
            int[] arrInput = intInput.ToArray();
            Helper.insertionSort(arrInput);
            int i, j;
            j = 0;

            for (i = 0; i < arrInput.Length; i++)
            {
                if (arrInput[i] + arrInput[j] == year)
                {
                    break;
                } else if (arrInput[i] + arrInput[j] > year)
                {
                    i = 0;
                    j++;
                }
            }

            return arrInput[i] * arrInput[j];
        }
        public static int part2(List<string> input)
        {
            List<int> intInput = new List<int>();
            foreach (string s in input)
            {
                intInput.Add(Int32.Parse(s));
            }
            int[] arrInput = intInput.ToArray();
            Helper.insertionSort(arrInput);
            int i, j, k;
            j = 0;
            k = 0;

            for (i = 0; i < arrInput.Length; i++)
            {
                if (arrInput[i] + arrInput[j] + arrInput[k] == year)
                {
                    break;
                }
                else if (arrInput[i] + arrInput[j] + arrInput[k] > year)
                {
                    i = 0;
                    j++;
                    if (j > arrInput.Length)
                    {
                        j = 0;
                        k++;
                        break;
                    } else if (k > arrInput.Length)
                    {
                        break;
                    }
                }
            }

            return arrInput[i] * arrInput[j] * arrInput[k];
        }

    }
}
