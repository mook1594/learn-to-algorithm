
namespace TestProject1
{
    internal class Test_03330
    {
        public Test_03330()
        {
        }

        internal int PossibleStringCount(string word)
        {
            int result = 0;

            int charGroupDupleCount = 0;
            int lastDupleCharIdx = 0;
            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == word[lastDupleCharIdx])
                    charGroupDupleCount++;
                else
                    lastDupleCharIdx = i;
            }

            return charGroupDupleCount + 1;
        }
    }
}