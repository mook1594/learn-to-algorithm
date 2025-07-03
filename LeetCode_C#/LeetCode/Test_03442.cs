
namespace TestProject1
{
    internal class Test_03442
    {
        internal int MaxDifference(string s)
        {
            Dictionary<char, int> keyValue = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if(keyValue.TryGetValue(c, out int value))
                    keyValue[c] = value + 1;
                else
                    keyValue.Add(c, 1);
            }
            int oddMax = keyValue.Values.Where(s => s % 2 == 1).Max();
            int evenMax = keyValue.Values.Where(s => s % 2 == 0).Min();

            int result = oddMax - evenMax;

            return result;
        }
    }
}