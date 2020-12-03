using System;
using System.Collections.Generic;

namespace AdventCode2020
{
    class Problem2
    {

        public static int part1(List<string> input)
        { 
            int one, two, count, validCount;
            string rawOne, rawTwo, password;
            char key;
            bool isValid;

            validCount = 0;
            foreach(string s in input)
            {
                one = 0;
                two = 0;
                rawOne = "";
                rawTwo = "";
                key = '\0';
                password = "";
                isValid = false;

                for(int i = 0; i < s.Length; i++)
                {
                    if (!s[i].Equals('-') && one == 0)
                    {
                        rawOne += s[i];
                    } else if (s[i].Equals('-'))
                    {
                        one = Int32.Parse(rawOne);
                    } else if (!s[i].Equals(' ') && two == 0)
                    {
                        rawTwo += s[i];
                    } else if (s[i].Equals(' ') && two == 0)
                    {
                        two = Int32.Parse(rawTwo);
                    } else if (!s[i].Equals(' ') && !s[i].Equals(':') && !s[i].Equals('-') && key.Equals('\0'))
                    {
                        key = s[i];
                    } else if (!s[i].Equals(' ') && !s[i].Equals(':') && !s[i].Equals('-') && !key.Equals('\0'))
                    {
                        password += s[i];
                    }
                }

                count = 0;
                foreach(char c in password)
                {
                    if (c.Equals(key)) {
                        count++;
                    }
                }
                if (count >= one && count <= two)
                {
                    isValid = true;
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
            int one, two, count, validCount;
            string rawOne, rawTwo, password;
            char key;

            validCount = 0;
            foreach (string s in input)
            {
                one = 0;
                two = 0;
                rawOne = "";
                rawTwo = "";
                key = '\0';
                password = "";

                for (int i = 0; i < s.Length; i++)
                {
                    if (!s[i].Equals('-') && one == 0)
                    {
                        rawOne += s[i];
                    }
                    else if (s[i].Equals('-'))
                    {
                        one = Int32.Parse(rawOne);
                    }
                    else if (!s[i].Equals(' ') && two == 0)
                    {
                        rawTwo += s[i];
                    }
                    else if (s[i].Equals(' ') && two == 0)
                    {
                        two = Int32.Parse(rawTwo);
                    }
                    else if (!s[i].Equals(' ') && !s[i].Equals(':') && !s[i].Equals('-') && key.Equals('\0'))
                    {
                        key = s[i];
                    }
                    else if (!s[i].Equals(' ') && !s[i].Equals(':') && !s[i].Equals('-') && !key.Equals('\0'))
                    {
                        password += s[i];
                    }
                }
                count = 0;
                for(int i = 0; i < password.Length; i++)
                {
                    if (password[i] == key && (one == i + 1 || two == i + 1))
                    {
                        count++;
                    }
                }

                if (count == 1)
                {
                    validCount++;
                }
            }

            return validCount;
        }


    }
}
