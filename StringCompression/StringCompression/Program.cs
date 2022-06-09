﻿using StringCompression;

//Given an array of characters chars, compress it using the following algorithm:

//Begin with an empty string s. For each group of consecutive repeating characters in chars:

//If the group"s length is 1, append the character to s.
//Otherwise, append the character followed by the group"s length.
//The compressed string s should not be returned separately, but instead, be stored in the input character array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.

//After you are done modifying the input array, return the new length of the array.

//You must write an algorithm that uses only constant extra space.

var solution = new Solution();

var input = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
var output = solution.Compress(input);
var inputString = string.Concat(input);
if (inputString == "a2b2c3" && output == 6)
    Console.WriteLine("Success");
else
    Console.WriteLine("Fail");

input = new char[] { 'a'};
output = solution.Compress(input);
inputString = string.Concat(input);
if (inputString == "a" && output == 1)
    Console.WriteLine("Success");
else
    Console.WriteLine("Fail");

input = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
output = solution.Compress(input);
inputString = string.Concat(input);
if (inputString == "ab12" && output == 4)
    Console.WriteLine("Success");
else
    Console.WriteLine("Fail");
