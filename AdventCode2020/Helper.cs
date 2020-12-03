/*
Advent of Code 2020 Solutions - Doug Day
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2020
{
    class Helper
    {
        static void Main(string[] args)
        {
            List<string> input;

            //input = Helper.Input("D:\\Code\\cs\\AdventCode2020\\AdventCode2020\\input\\problem1.txt");
            //Console.WriteLine(Problem1.part1(input));
            //Console.WriteLine(Problem1.part2(input));

            //input = Helper.Input("D:\\Code\\cs\\AdventCode2020\\AdventCode2020\\input\\problem2.txt");
            //Console.WriteLine(Problem2.part1(input));
            //Console.WriteLine(Problem2.part2(input));
            //Console.Read();

            input = Helper.Input("D:\\Code\\cs\\AdventCode2020\\AdventCode2020\\input\\problem3.txt");
            Console.WriteLine(Problem3.part1(input));
            Console.WriteLine(Problem3.part2(input));
            Console.Read();

        }

        public static void insertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = key;
            }
        }
        public static List<string> Input(string path)
        {
            string line;
            List<string> input = new List<string>();

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();

            return input;
        }


    }
}
