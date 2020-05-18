using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab2
{
    class Functions
    {

        public string Invert(string s)
        {
            string[] temp = s.Split(' ');
            s = "";
            for (int i = temp.Length - 1, k = 0; i >= 0; i--, k++)
            {
                s += temp[i] + " ";
            }
            return s;
        }

        public string FindNonEnglishCapitalLetters(string s)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string output = "";
            for (int i = 0; i<s.Length; i++)
            {
                if (char.IsUpper(s[i]) && !alphabet.Contains(s[i])) output += s[i];
            }
            return output;
        }
        private bool IsVowel(char c)
        {
            return "aeiouAEIOU".Contains(c);
        }
        private char GetNextLetter(char c)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (alphabet.IndexOf(c) == 25)
            {
                return alphabet[0];
            }
            else if (alphabet.IndexOf(c) == 51)
            {
                return alphabet[26];
            }
            return alphabet[alphabet.IndexOf(c) + 1];
        }

        public string ReplaceLetters(string s)
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (i != 0)
                {
                    if (IsVowel(s[i - 1]))
                    {
                        resultString.Append(GetNextLetter(s[i]));
                        continue;
                    }
                }

                resultString.Append(s[i]);
            }

            return resultString.ToString();
        }
    }
}
