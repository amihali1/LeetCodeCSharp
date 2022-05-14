/*
Given an array of n integers nums, 
a 132 pattern is a subsequence of three integers
nums[i], nums[j] and nums[k] such that 
i < j < k and nums[i] < nums[k] < nums[j].

Return true if there is a 132 pattern in nums, otherwise, return false.
*/

using Pattern132;

var solution = new Solution();

Console.WriteLine("Testing [1,2,3,4]");
Console.WriteLine("Expected Result: False | Actual Result: " + solution.Find132Pattern(new int[] { 1, 2, 3, 4 }));

Console.WriteLine("Testing [3,1,4,2]");
Console.WriteLine("Expected Result: True | Actual Result: " + solution.Find132Pattern(new int[] { 3, 1, 4, 2 }));

Console.WriteLine("Testing [-1,3,2,0]");
Console.WriteLine("Expected Result: True | Actual Result: " + solution.Find132Pattern(new int[] { -1, 3, 2, 0 }));

Console.WriteLine("Testing [1,3,2,4,5,6,7,8,9,10]");
Console.WriteLine("Expected Result: True | Actual Result: " + solution.Find132Pattern(new int[] { 1, 3, 2, 4, 5, 6, 7, 8, 9, 10 }));

Console.WriteLine("Testing [3,5,0,3,4]");
Console.WriteLine("Expected Result: True | Actual Result: " + solution.Find132Pattern(new int[] { 3, 5, 0, 3, 4 }));

Console.WriteLine("Testing [1,0,1,-4,-3]");
Console.WriteLine("Expected Result: False | Actual Result: " + solution.Find132Pattern(new int[] { 1, 0, 1, -4, -3 }));
