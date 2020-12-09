using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventCode2020
{
    class Problem7
    {
        public struct Bag
        {
            public string name;
            public int number;
            public Dictionary<string, int> children;
            public Bag(string name, int number, Dictionary<string, int> children)
            {
                this.name = name;
                this.number = number;
                this.children = children;
            }
        }
        public static int part1(List<string> input)
        {
            List<Bag> bagList = new List<Bag>();
            foreach (string rule in input)
            {
                bagSorter(rule, bagList);
            }
            List<string> goldList = new List<string>();

            goldSorter(bagList, goldList, "shinygold");

            return goldList.Count;
        }

        public static int part2(List<string> input)
        {
            List<Bag> bagList = new List<Bag>();
            foreach (string rule in input)
            {
                bagSorter(rule, bagList);
            }
            int count = 0;
            goldCounter(bagList, ref count, "shinygold", 1);

            return count;
        }

        private static void goldCounter(List<Bag> bagList, ref int count, string searchTerm, int factor)
        {
            foreach (Bag bag in bagList)
            {
                if (bag.name.Equals(searchTerm))
                {
                    foreach (string child in bag.children.Keys)
                    {
                        count += factor * bag.children[child];
                        goldCounter(bagList, ref count, child, factor * bag.children[child]);
                    }
                }
            }

        }

        static void goldSorter(List<Bag> bagList, List<string> goldList, string searchTerm)
        {
            foreach (Bag bag in bagList)
            {

                if (bag.children.ContainsKey(searchTerm))
                {
                    if (!goldList.Contains(bag.name))
                    {
                        goldList.Add(bag.name);
                    }
                    goldSorter(bagList, goldList, bag.name);
                }
            }

        }

        static void bagSorter(string rule, List<Bag> bagList)
        {
            string[] words = rule.Split(' ');
            string parent = "";
            string child = "";
            int number = 0;
            Dictionary<string, int> childList = new Dictionary<string, int>();
            bool parentFlag = false;
            foreach (string word in words)
            {
                if (word.Contains('.'))
                {
                    childList.Add(child, number);
                    bagList.Add(new Bag(parent, number, new Dictionary<string, int>(childList)));
                    childList.Clear();
                    child = "";
                    parent = "";
                    number = 0;
                }
                else if (word.Contains(','))
                {
                    childList.Add(child, number);
                    child = "";
                    number = 0;
                }
                else if (word.Equals("contain"))
                {
                    parentFlag = true;
                }
                else if (!word.Contains("bag") && !Regex.IsMatch(word, "[0-9]"))
                {
                    if (parentFlag)
                    {
                        child += word;
                    }
                    else
                    {
                        parent += word;
                    }
                }
                else if (Regex.IsMatch(word, "[0-9]"))
                {
                    number = Int32.Parse(word);
                }
            }
        }
    }
}
