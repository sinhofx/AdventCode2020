using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem9
    {
        public static long part1(List<string> input)
        {
            bool match = false;
            long[] arrInput = new long[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                arrInput[i] = Int64.Parse(input.ToArray()[i]);
            }

            for (int i = 25; i < arrInput.Length; i++)
            {
                match = false;
                for (int j = i - 25; j < i; j++)
                {
                    for (int k = i - 25; k < i; k++)
                    {
                        if ((arrInput[j] + arrInput[k] == arrInput[i]) && j != k)
                        {
                            match = true;
                        }
                    }
                }
                if (!match)
                {
                    return arrInput[i];
                }
            }
            return 0;
        }

        public static long part2(List<string> input)
        {
            long[] arrInput = new long[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                arrInput[i] = Int64.Parse(input.ToArray()[i]);
            }

            long currentIndex = 0;
            long sum = 0;
            long goal = 25918798;
            List<long> numbers = new List<long>();

            for (long i = 0; i < arrInput.Length;)
            {
                sum += arrInput[i];
                numbers.Add(arrInput[i]);
                if (sum == goal)
                {
                    break;
                }
                if (i + 1 == arrInput.Length)
                {
                    numbers.Clear();
                    currentIndex++;
                    i = currentIndex;
                    sum = 0;
                }
                else
                {
                    i++;
                }
            }
            long low = numbers.ToArray()[0];
            long high = numbers.ToArray()[0];
            foreach (long l in numbers)
            {
                if (l < low)
                {
                    low = l;
                }
                if (l > high)
                {
                    high = l;
                }
            }
            return low + high;

        }
    }
}
