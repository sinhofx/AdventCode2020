using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Problem8
    {
        public static int part1(List<string> input)
        {
            string[] arrInput = input.ToArray();
            string[] current;
            List<int> executed = new List<int>();
            int accValue = 0;

            for (int i = 0; i < arrInput.Length;)
            {
                if (executed.Contains(i))
                {
                    break;
                }
                else
                {
                    executed.Add(i);
                }
                current = arrInput[i].Split(' ');
                if (current[0].Equals("acc"))
                {
                    accValue += Int32.Parse(current[1]);
                    i++;

                }
                else if (current[0].Equals("jmp"))
                {
                    i += Int32.Parse(current[1]);
                }
                else
                {
                    i++;
                }
            }

            return accValue;
        }

        public static int part2(List<string> input)
        {
            string[] arrInput = input.ToArray();
            string[] current;
            List<int> executed = new List<int>();
            int accValue = 0;

            for (int j = 0; j < arrInput.Length; j++)
            {
                if (accValue != 0)
                {
                    return accValue;
                }
                arrInput = input.ToArray();
                executed.Clear();
                if (arrInput[j].Contains("jmp"))
                {
                    arrInput[j] = arrInput[j].Replace("jmp", "nop");
                }
                else if (arrInput[j].Contains("nop"))
                {
                    arrInput[j] = arrInput[j].Replace("nop", "jmp");
                }

                for (int i = 0; i < arrInput.Length;)
                {
                    if (executed.Contains(i))
                    {
                        accValue = 0;
                        break;
                    }
                    else
                    {
                        executed.Add(i);
                    }
                    current = arrInput[i].Split(' ');
                    if (current[0].Equals("acc"))
                    {
                        accValue += Int32.Parse(current[1]);
                        i++;

                    }
                    else if (current[0].Equals("jmp"))
                    {
                        i += Int32.Parse(current[1]);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return accValue;
        }

    }
}
