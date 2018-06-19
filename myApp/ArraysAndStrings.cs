using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace myApp
{
    class ArraysAndStrings
    {
        public void isPalPermTest()
        {
            string sPalPerm = "hellooh"; // holeloh
            string sNotPalPerm = "welcome";

            Debug.Assert(isPalPerm(sPalPerm) == true);
            Debug.Assert(isPalPerm(sNotPalPerm) == false);
        }

        public bool isPalPerm(string s)
        {
            int countOdd = 0;
            Dictionary<char, int> dict;
            dict = stringToDict(s);

            // Count the number of odd chars.
            foreach (KeyValuePair<char, int> item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    countOdd++;
                }
            }

            if (countOdd == 0 || countOdd == 1)
            {
                return true;
            }
            else { return false; }
        }

        public void URLifyTest()
        {
            string s = "Mr. John Doe  ";
            string sExpected = "Mr.%20John%20Doe";
            Debug.Assert(URLify(s) == sExpected);
        }
        public string URLify(string s)
        {
            return s.Trim().Replace(" ", "%20");
        }
        public void isPermutationTest()
        {
            string s = "hello world!";
            string sSame = "olleh dlrow!";
            string sDifferent = "Hello World!";

            Debug.Assert(isPermutation(s, sSame) == true);
            Debug.Assert(isPermutation(s, sDifferent) == false);

        }

        public bool isPermutation(string s, string s2)
        {
            Dictionary<char, int> dict = stringToDict(s);
            Dictionary<char, int> dict2 = stringToDict(s2);

            foreach (KeyValuePair<char, int> item in dict)
            {
                if (!dict2.ContainsKey(item.Key) ||
                    dict2[item.Key] != item.Value)
                {
                    return false;
                }
            }

            foreach (KeyValuePair<char, int> item in dict2)
            {
                if (!dict.ContainsKey(item.Key) ||
                     dict[item.Key] != item.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<char, int> stringToDict(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]] += 1;
                }
                else
                {
                    dict[s[i]] = 1;
                }
            }
            return dict;
        }

        public bool hasUniqueChars(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                string sub = s.Substring(i + 1);
                if (sub.IndexOf(s[i]) >= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void uniqueCharsTest()
        {
            string s = "supercali";
            string s2 = "supercalifornia";

            Debug.Assert(hasUniqueChars(s) == true);
            Debug.Assert(hasUniqueChars(s2) == false);
        }
    }
}