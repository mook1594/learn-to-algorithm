
namespace TestProject1
{
    internal class Test_00594
    {
        internal int FindLHS(int[] nums)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                bool canGetNumFromNumCount = numCount.TryGetValue(nums[i], out int countValue);
                if (canGetNumFromNumCount)
                    numCount[nums[i]] = countValue + 1;
                else
                    numCount.Add(nums[i], 1);
            }

            int maxValue = 0;
            foreach (int num in numCount.Keys)
            {
                int value = numCount[num];

                bool canGetValue = numCount.TryGetValue(num + 1, out int nextValue);
                if (canGetValue && value + nextValue > maxValue)
                    maxValue = value + nextValue;

                canGetValue = numCount.TryGetValue(num - 1, out int prevValue);
                if (canGetValue && value + prevValue > maxValue)
                    maxValue = value + prevValue;
            }


            return maxValue;
        }
    }
}