using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Test_00001
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[] { 99, 99 };

            Dictionary<int, List<int>> indexNumMap = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                bool isCanGet = indexNumMap.TryGetValue(nums[i], out List<int> indexies);
                if (isCanGet)
                    indexies.Add(i);
                else
                    indexNumMap.Add(nums[i], new List<int>() { i });
            }

            foreach (int num in indexNumMap.Keys)
            {
                int subValue = target - num;

                if (indexNumMap.ContainsKey(subValue))
                {
                    int firstIndex = indexNumMap[num].First();

                    foreach (int val in indexNumMap[subValue])
                    {
                        if (val != firstIndex)
                        {
                            result = [firstIndex, val];
                            break;
                        }
                    }
                }
            }
            Array.Sort(result);
            return result;
        }
    }
}
