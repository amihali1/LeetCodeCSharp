using System;
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
                var leftMin = leftMins.ElementAt(i-1);
                var middleNum = nums[i];

                while (rightMins.Any() && rightMins.Peek() <= leftMin) 
                    rightMins.Pop();
                
                if (rightMins.Any() && rightMins.Peek() < middleNum) 
                    return true;
                
                rightMins.Push(nums[i]);
            }
            return false;
        }

        // TOO SLOW
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
