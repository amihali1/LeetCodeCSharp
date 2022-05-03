// See https://aka.ms/new-console-template for more information
using RomanToInt;

var solution = new Solution();

Console.WriteLine("Testing string \"III\"");
var result = solution.RomanToInt("III");
Console.WriteLine($"Expected Result: 3   | Actual Result: {result}");

Console.WriteLine("Testing string \"LVIII\"");
result = solution.RomanToInt("LVIII");
Console.WriteLine($"Expected Result: 58   | Actual Result: {result}");

Console.WriteLine("Testing string \"MCMXCIV\"");
result = solution.RomanToInt("MCMXCIV");
Console.WriteLine($"Expected Result: 1994   | Actual Result: {result}");
