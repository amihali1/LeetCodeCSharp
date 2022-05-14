﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern132
{
    internal class Solution
    {
        internal bool Find132Pattern(int[] nums)
        {
            if (nums.Length == 3)
            {
                if (nums[0] < nums[2] && nums[2] < nums[1])
                    return true;
                else
                    return false;
            }

            var leftMins = new Stack<int>();
            leftMins.Push(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                leftMins.Push(Math.Min(nums[i - 1], nums[i]));
            }

            var rightMins = new Stack<int>();

            for (int i = nums.Length - 1; i > 0; i--)
            {
                var leftMin = leftMins.ElementAt(i - 1);
                var middleNum = nums[i];

                while (rightMins.Any() && rightMins.Peek() <= leftMin)
                    rightMins.Pop();

                if (rightMins.Any() && rightMins.Peek() < middleNum)
                    return true;

                rightMins.Push(nums[i]);
            }
            return false;
        }

        // Linq solution: Also too slow...
        //internal bool Find132Pattern(int[] nums)
        //{
        //    var indexByValue = new Dictionary<int, List<int>>();
        //    var numsHash = new HashSet<(int? num, int index)>();

        //    numsHash.Add((nums[0], 0));
        //    indexByValue[nums[0]] = new List<int>() { 0 };

        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        if (nums[i - 1] != nums[i])
        //        {
        //            numsHash.Add((nums[i], i));

        //            if (indexByValue.ContainsKey(nums[i]))
        //                indexByValue[nums[i]].Add(i);
        //            else
        //                indexByValue[nums[i]] = new List<int>() { i };
        //        }
        //    }

        //    var orderedNums = nums.OrderByDescending(n => n);
        //    var orderedDistinctNums = orderedNums.Distinct();

        //    if (orderedDistinctNums.Count() < 3)
        //        return false;

        //    for (int o_k = 0; o_k < orderedNums.Count(); o_k++)
        //    {
        //        int n_k = orderedNums.ElementAt(o_k);
        //        var kList = indexByValue[n_k];

        //        var iPairs = numsHash.Where(i => i.num.HasValue && i.num < n_k && kList.Any(k => i.index < k));

        //        if (iPairs.Any())
        //        {
        //            foreach (var iPair in iPairs.Where(ip => ip.num.HasValue))
        //            {
        //                int i = iPair.index;
        //                int n_i = iPair.num.Value;
        //                var jPair = numsHash.Where(j => n_i < n_k && n_k < j.num && i < j.index && kList.Any(k => j.index < k));

        //                if (jPair.Any())
        //                    return true;
        //            }
        //        }

        //    }
        //    return false;
        //}

        // Brute force solution: Too slow
        //public bool Find132pattern(int[] nums)
        //{
        //    for (int i = 0; i < nums.Length - 2; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length - 1; j++)
        //        {
        //            if (nums[i] < nums[j])
        //            {
        //                for (int k = j + 1; k < nums.Length; k++)
        //                {

        //                    if (nums[j] > nums[k] && nums[k] > nums[i])
        //                        return true;

        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}
