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
            
            // n[k] can never be the int.MinValue
            int n_k = int.MinValue;
            int n_j;
            int n_i;

            // Reverse through the list to ensure index condition 
            // Index condition is ensured because n_j and n_k can only be set in the stack after index i
            for (int i = nums.Count() - 1; i >= 0; i--)
            {
                // nums[i] is only in the 1 position of 132 at the beginning of this loop
                n_i = nums[i];

                // This condition must be met to satisfy 132 pattern.
                // n_k can only be set if there is a value in the stack greater than it (n_j)
                if (n_i < n_k)
                    return true;

                // If the above condition isn't met, we check to see if nums[i] could be the n_j or 3 in the 132 pattern
                n_j = n_i;

                // n_k can only be set if it is less than n_j. Thus this actually checks the n_k < n_j condition
                while (stack.Any() && stack.First() < n_j)
                    n_k = stack.Pop();

                // At this point nums[i] could be the a valid n_j or 3 in the 132 pattern so we push it into the stack.
                // Only valid n_j values should be left in the stack in the end. All others get popped out
                stack.Push(n_j);
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

        // Brute force solution: Too easy, too slow
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
