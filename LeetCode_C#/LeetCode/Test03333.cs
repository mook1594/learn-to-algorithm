
namespace TestProject1
{
    internal class Test03333
    {
        Dictionary<string, long> memo = new Dictionary<string, long>();
        private int[] minPossibleFromIndex;
        private int[] maxPossibleFromIndex;
        public Test03333()
        {
        }

        internal int PossibleStringCount(string word, int k)
        {

            List<int> groups = new List<int>();

            int currentCount = 1;
            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == word[i - 1])
                    currentCount++;
                else
                {
                    groups.Add(currentCount);
                    currentCount = 1;
                }
            }
            groups.Add(currentCount);

            int[] nums = groups.ToArray();
            //PrecomputeMinMaxSums(nums);
            //long result = Test3333_recursive(nums, k, 0, 0);

            long MOD = ((long)Math.Pow(10, 9)) + 7L;

            int maxPossibleSum = nums.Sum();

            long[] dp = new long[maxPossibleSum + 1];

            dp[0] = 1;
            foreach (long maxValue in nums)
            {
                for (long currentSum = maxPossibleSum; currentSum >= 0; currentSum--)
                {
                    if (dp[currentSum] == 0)
                        continue;

                    for (int num = 1; num <= maxValue; num++)
                        if (currentSum + num <= maxPossibleSum)
                            dp[currentSum + num] += dp[currentSum] % MOD;
                    dp[currentSum] = 0;
                }
            }

            long result = 0;
            for (int i = k; i <= maxPossibleSum; i++)
            {
                result += dp[i];
            }

            return (int)(result % MOD);
        }


        private void PrecomputeMinMaxSums(int[] nums)
        {
            int length = nums.Length;
            minPossibleFromIndex = new int[length + 1];
            maxPossibleFromIndex = new int[length + 1];

            for (int i = length - 1; i >= 0; i--)
            {
                minPossibleFromIndex[i] = minPossibleFromIndex[i + 1] + 1;
                maxPossibleFromIndex[i] = maxPossibleFromIndex[i + 1] + nums[i];
            }
        }

        private long Test3333_recursive(int[] nums, int k, int idx, int currentSum)
        {
            long MOD = ((long)Math.Pow(10, 9)) + 7L;

            if (idx == nums.Length)
                return currentSum >= k ? 1 : 0;

            if (currentSum + maxPossibleFromIndex[idx] < k)
            {
                return 0;
            }

            if (currentSum + minPossibleFromIndex[idx] >= k)
            {
                long rs = 1;
                for (int i = idx; i < nums.Length; i++)
                {
                    rs = (rs * nums[i]) % MOD;
                }
                return rs;
            }

            string key = $"{idx}_{currentSum}";
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            long count = 0;
            for (int i = 1; i <= nums[idx]; i++)
            {
                count = (count + Test3333_recursive(nums, k, idx + 1, currentSum + i)) % MOD;
            }

            memo[key] = count;
            return count;
        }

    }
}