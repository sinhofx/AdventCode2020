using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem10
    {
        public static int part1(List<string> input)
        {
            int[] arrInput = new int[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                arrInput[i] = Int32.Parse(input.ToArray()[i]);
            }

            int[] voltCounts = new int[] { 0, 0, 0 };
            int currentVolts = 0;
            int currentDiff = 1;

            for (int i = 0; i < arrInput.Length; i++)
            {
                if (arrInput[i] == currentVolts + currentDiff)
                {
                    currentVolts = arrInput[i];
                    voltCounts[currentDiff - 1]++;
                    currentDiff = 1;
                    i = -1;
                }
                if (i + 1 == arrInput.Length && currentDiff < 3)
                {
                    currentDiff++;
                    i = -1;
                }
            }
            voltCounts[2]++;

            return voltCounts[0] * voltCounts[2];
        }

        public static long part2(List<string> input)
        {
            input.Add("0");
            input.Add("156");
            int[] arrInput = new int[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                arrInput[i] = Int32.Parse(input.ToArray()[i]);
            }
            Helper.insertionSort(arrInput);

            Dictionary<long, long> combos = new Dictionary<long, long>();

            foreach (int adapter in arrInput)
            {
                combos.Add(adapter, 0);
            }
            combos[0] = 1;

            foreach (int adapter in arrInput)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (input.Contains((adapter + j).ToString()))
                    {
                        combos[adapter + j] += combos[adapter];
                    }
                }
            }

            return combos[156];
        }

    }

}
