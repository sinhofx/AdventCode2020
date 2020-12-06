using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventCode2020
{
    class Problem4
    {
        public static int part1(List<string> input)
        {
            string[] arrInput = input.ToArray();
            List<string> fInput = new List<string>();
            string passport = "";
            for (int i = 0; i < arrInput.Length; i++)
            {
                passport += arrInput[i];
                if (arrInput[i].Equals("") || i == arrInput.Length - 1)
                {
                    fInput.Add(passport);
                    passport = "";
                }
            }

            int validCount = 0;
            bool isValid;
            string[] validList = new string[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            foreach (string p in fInput)
            {
                isValid = true;
                foreach (string field in validList)
                {
                    if (!p.Contains(field))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    validCount++;
                }
            }

            return validCount;

        }

        public static int part2(List<string> input)
        {
            string[] arrInput = input.ToArray();
            List<string> fInput = new List<string>();
            string passport = "";

            for (int i = 0; i < arrInput.Length; i++)
            {
                if (passport.Equals(""))
                {
                    passport += arrInput[i];
                }
                else
                {
                    passport += " " + arrInput[i];
                }

                if (arrInput[i].Equals("") || i == arrInput.Length - 1)
                {
                    fInput.Add(passport);
                    passport = "";
                }
            }
            int validCount = 0;
            foreach (string p in fInput)
            {
                if (parameterHandler(p))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        static bool parameterHandler(string passport)
        {
            string[] parameters = passport.Split(' ');
            int validCount = 0;
            foreach (string parameter in parameters)
            {
                if (parameter.Contains("byr"))
                {
                    if (yearHandler(parameter, 1920, 2002))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("iyr"))
                {
                    if (yearHandler(parameter, 2010, 2020))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("eyr"))
                {
                    if (yearHandler(parameter, 2020, 2030))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("hgt"))
                {
                    if (heightHandler(parameter))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("hcl"))
                {
                    if (hairHandler(parameter))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("ecl"))
                {
                    if (eyeHandler(parameter))
                    {
                        validCount++;
                    }
                }
                else if (parameter.Contains("pid"))
                {
                    if (pidHandler(parameter))
                    {
                        validCount++;
                    }
                }
            }
            return validCount == 7;

        }
        static bool yearHandler(string parameter, int low, int high)
        {
            string year = "";
            for (int i = 4; i < parameter.Length; i++)
            {
                year += parameter[i];
            }
            return Int32.Parse(year) >= low && Int32.Parse(year) <= high;
        }
        static bool heightHandler(string parameter)
        {
            string height = "";
            for (int i = 4; i < parameter.Length - 2; i++)
            {
                height += parameter[i];
            }

            if (parameter.Contains("cm"))
            {
                return (Int32.Parse(height) >= 150 && Int32.Parse(height) <= 193);
            }
            else if (parameter.Contains("in"))
            {
                return (Int32.Parse(height) >= 59 && Int32.Parse(height) <= 76);
            }
            return false;
        }

        static bool hairHandler(string parameter)
        {
            string color = "";
            int count = 0;
            for (int i = 4; i < parameter.Length; i++)
            {
                color += parameter[i];
            }
            if (!color.Contains('#'))
            {
                return false;
            }
            foreach (char c in color)
            {
                count++;
                if (!Regex.IsMatch(c.ToString(), "[a-f]") && !Regex.IsMatch(c.ToString(), "[0-9]") && !c.Equals('#'))
                {
                    return false;
                }
            }

            return count == 7;
        }

        static bool eyeHandler(string parameter)
        {
            string[] validList = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            foreach (string color in validList)
            {
                if (parameter.Contains(color))
                {
                    return true;
                }
            }

            return false;
        }

        static bool pidHandler(string parameter)
        {
            int count = 0;
            for (int i = 4; i < parameter.Length; i++)
            {
                count++;
                if (!Regex.IsMatch(parameter[i].ToString(), "[0-9]"))
                {
                    return false;
                }
            }
            return count == 9;
        }


    }
}
