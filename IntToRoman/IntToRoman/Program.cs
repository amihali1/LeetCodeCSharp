// See https://aka.ms/new-console-template for more information
using IntToRoman;

var solution = new Solution();

Console.WriteLine("Testing string \"3\"");
var result = solution.IntToRoman(3);
Console.WriteLine($"Expected Result: III   | Actual Result: {result}");

Console.WriteLine("Testing string \"58\"");
result = solution.IntToRoman(58);
Console.WriteLine($"Expected Result: LVIII   | Actual Result: {result}");

Console.WriteLine("Testing string \"1994\"");
result = solution.IntToRoman(1994);
Console.WriteLine($"Expected Result: MCMXCIV   | Actual Result: {result}");
