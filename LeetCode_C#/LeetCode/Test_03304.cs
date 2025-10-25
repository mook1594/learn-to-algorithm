
using System.Text;

namespace TestProject1
{
    internal class Test03304
    {
        public Test03304()
        {
        }

        internal char KthCharacter(int k)
        {
            return RecursiveKthChracter("a", k);
        }


        private char RecursiveKthChracter(string word, int k)
        {
            if (word.Length >= k)
                return word[k - 1];

            StringBuilder sb = new StringBuilder(word);
            for(int i = 0; i < word.Length; i++)
            {
                int nextCharIdx = (char)word[i].GetHashCode() + 1;
                if (nextCharIdx > 'z'.GetHashCode())
                    nextCharIdx = 'a'.GetHashCode();

                sb.Append((char)nextCharIdx);
            }

            return RecursiveKthChracter(sb.ToString(), k);
        }
    }
}