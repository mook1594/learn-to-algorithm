
using System.Text;

namespace TestProject1
{
    internal class Test_03307
    {
        public Test_03307()
        {
        }

        internal char KthCharacter2(long k, int[] operations)
        {
            return RecursiveKthChracter(k, operations);
        }

        private char RecursiveKthChracter(long k, int[] operations)
        {
            if (k == 1) return 'a';

            int idx = (int)(Math.Log2(k));
            long n = k % (long)Math.Pow(2, idx);
            if (n == 0)
            {
                idx -= 1;
                n = (long)Math.Pow(2, idx);
            }
            

            return Operate(RecursiveKthChracter(n, operations), operations[idx]);

            //if (k == 1) return 'a';
            //if (k == 2) return Operate(RecursiveKthChracter(1, operations), operations[0]);
            //if (k == 3) return Operate(RecursiveKthChracter(1, operations), operations[1]);
            //if (k == 4) return Operate(RecursiveKthChracter(2, operations), operations[1]);
            //if (k == 5) return Operate(RecursiveKthChracter(1, operations), operations[2]);
            //if (k == 6) return Operate(RecursiveKthChracter(2, operations), operations[2]);
            //if (k == 7) return Operate(RecursiveKthChracter(3, operations), operations[2]);
            //if (k == 8) return Operate(RecursiveKthChracter(4, operations), operations[2]);
            //if (k == 9) return Operate(RecursiveKthChracter(1, operations), operations[3]);
            //if (k == 10) return Operate(RecursiveKthChracter(2, operations), operations[3]);
            //if (k == 11) return Operate(RecursiveKthChracter(3, operations), operations[3]);
            //if (k == 12) return Operate(RecursiveKthChracter(4, operations), operations[3]);
            //if (k == 13) return Operate(RecursiveKthChracter(5, operations), operations[3]);
            //if (k == 14) return Operate(RecursiveKthChracter(6, operations), operations[3]);
            //if (k == 15) return Operate(RecursiveKthChracter(7, operations), operations[3]);
            //if (k == 16) return Operate(RecursiveKthChracter(8, operations), operations[3]);
        }

        internal char KthCharacter(long k, int[] operations)
        {
            string word = "a";

            for(int i = 0; i < operations.Length; i++)
            {
                int op = operations[i];
                if (word.Length * 2 >= k)
                {
                    int halfIdx = (int)k % word.Length;
                    if(op == 0 && halfIdx == 0)
                    {
                        return 'a';
                    }
                    else if (op == 0)
                    {
                        return word[halfIdx-1];
                    }
                    else if (op == 1)
                    {
                        int nextCharIdx = (char)word[halfIdx-1].GetHashCode() + 1;
                        if (nextCharIdx > 'z'.GetHashCode())
                            nextCharIdx = 'a'.GetHashCode();
                        return (char)nextCharIdx;
                    }
                }

                (bool isNeedBreak, word) = RecursiveKthChracter(word, k, op);
                if (isNeedBreak)
                    break;
            }
            
            return word[(int)k - 1];
        }

        private char Operate(char c, int op)
        {
            if (op == 0)
                return c;
            else if (op == 1)
            {
                int nextCharIdx = c.GetHashCode() + 1;
                if (nextCharIdx > 'z'.GetHashCode())
                    nextCharIdx = 'a'.GetHashCode();
                return (char)nextCharIdx;
            }
            return c;
        }

        private (bool, string) RecursiveKthChracter(string word, long k, int op)
        {
            StringBuilder sb = new StringBuilder(word);
            if (op == 0)
            {
                sb.Append(word);
            }
            else if(op == 1)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int nextCharIdx = (char)word[i].GetHashCode() + 1;
                    if (nextCharIdx > 'z'.GetHashCode())
                        nextCharIdx = 'a'.GetHashCode();

                    sb.Append((char)nextCharIdx);
                }
            }

            return (false, sb.ToString());
        }
    }
}