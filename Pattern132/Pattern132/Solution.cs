using Nito.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern132
{
    internal class Solution
    {

        //Stack solution: Works in O(n). Yay!
        internal bool Find132Pattern(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            int two = int.MinValue;
            for (int i = nums.Count() - 1; i >= 0; i--)
            {
                if (two > nums[i])
                    return true;
                while (stack.Any() && nums[i] > stack.First())
                    two = stack.Pop();

                stack.Push(nums[i]);
            }
            return false;
        }

        // Linq solution: Also too slow...
        internal bool Find132PatternLinq(int[] nums)
        {
            var indexByValue = new Dictionary<int, List<int>>();
            var numsHash = new HashSet<(int? num, int index)>();

            numsHash.Add((nums[0], 0));
            indexByValue[nums[0]] = new List<int>() { 0 };

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    numsHash.Add((nums[i], i));

                    if (indexByValue.ContainsKey(nums[i]))
                        indexByValue[nums[i]].Add(i);
                    else
                        indexByValue[nums[i]] = new List<int>() { i };
                }
            }

            var orderedNums = nums.OrderByDescending(n => n);
            var orderedDistinctNums = orderedNums.Distinct();

            if (orderedDistinctNums.Count() < 3)
                return false;

            for (int o_k = 0; o_k < orderedDistinctNums.Count(); o_k++)
            {
                int n_k = orderedDistinctNums.ElementAt(o_k);
                var kList = indexByValue[n_k];

                var iPairs = numsHash.Where(i => i.num.HasValue && i.num < n_k && kList.Any(k => i.index < k));

                if (iPairs.Any())
                {
                    foreach (var iPair in iPairs.Where(ip => ip.num.HasValue))
                    {
                        int i = iPair.index;
                        int n_i = iPair.num.Value;
                        var jPair = numsHash.Where(j => n_i < n_k && n_k < j.num && i < j.index && kList.Any(k => j.index < k));

                        if (jPair.Any())
                            return true;
                    }
                }

            }
            return false;
        }

        // Brute force solution: Too slow
        public bool Find132patternBrute(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        for (int k = j + 1; k < nums.Length; k++)
                        {

                            if (nums[j] > nums[k] && nums[k] > nums[i])
                                return true;

                        }
                    }
                }
            }
            return false;
        }
    }
}
