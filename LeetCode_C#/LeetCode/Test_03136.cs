
using System.Runtime.CompilerServices;

namespace TestProject1
{
    internal class Test_03136
    {
        public Test_03136()
        {
        }
        private char[] inavailableChars = ['@', '#', '$'];
        static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        internal bool IsValid(string word)
        {
            if (word.Length < 3)
                return false;

            int numCount = 0;
            int countVowels = 0;
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char ch in word.ToLower())
            {
                if (inavailableChars.Contains(ch))
                    return false;

                bool canConvert = int.TryParse(ch.ToString(), out int convert);
                if (canConvert)
                    numCount += 1;

                if (ch == 'a'
                    || ch == 'e'
                    || ch == 'i'
                    || ch == 'o'
                    || ch == 'u')
                    countVowels++;

                bool canGet = count.TryGetValue(ch, out int value);
                if (canGet)
                    count[ch] = value + 1;
                else
                    count.Add(ch, 1);
            }

            if (countVowels < 1)
                return false;

            if (word.Length - numCount - countVowels < 1)
                return false;

            return true;
        }
    }
}