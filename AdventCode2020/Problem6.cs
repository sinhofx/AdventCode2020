using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventCode2020
{
    class Problem6
    {
        public static int part1(List<string> input)
        {
            string[] arrInput = input.ToArray();
            List<string> answers = new List<string>();
            List<string> groups = new List<string>();
            string group = "";
            for (int i = 0; i < arrInput.Length; i++)
            {
                group += arrInput[i];
                if (arrInput[i].Equals("") || i + 1 == arrInput.Length)
                {
                    groups.Add(group);
                    group = "";
                }
            }

            int count = 0;
            int sum = 0;
            foreach (string g in groups)
            {
                foreach (char answer in g)
                {
                    if (!answers.Contains(answer.ToString()))
                    {
                        answers.Add(answer.ToString());
                        count++;
                    }
                }
                sum += count;
                count = 0;
                answers.Clear();
            }

            return sum;
        }

        public static int part2(List<string> input)
        {
            string[] arrInput = input.ToArray();
            Dictionary<string, int> answers = new Dictionary<string, int>();
            List<string> groups = new List<string>();
            string group = "";
            int people = 0;
            for (int i = 0; i < arrInput.Length; i++)
            {
                group += arrInput[i];
                if (!arrInput[i].Equals(""))
                {
                    people++;
                }
                if (arrInput[i].Equals("") || i + 1 == arrInput.Length)
                {
                    group += people;
                    groups.Add(group);
                    group = "";
                    people = 0;
                }
            }

            int count = 0;
            int sum = 0;
            foreach (string g in groups)
            {
                foreach (char answer in g)
                {
                    if (!answers.ContainsKey(answer.ToString()) && !Regex.IsMatch(answer.ToString(), "[0-9]"))
                    {
                        answers.Add(answer.ToString(), 1);
                    }
                    else if (answers.ContainsKey(answer.ToString()))
                    {
                        answers[answer.ToString()]++;
                    }
                    else if (Regex.IsMatch(answer.ToString(), "[0-9]"))
                    {
                        foreach (string key in answers.Keys)
                        {
                            if (answers[key] == Int32.Parse(answer.ToString()))
                            {
                                count++;
                            }
                        }
                    }
                }
                sum += count;
                count = 0;
                answers.Clear();
            }

            return sum;
        }
    }
}
