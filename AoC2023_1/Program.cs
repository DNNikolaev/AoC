using System.Text.RegularExpressions;

TextReader reader = new StreamReader(@"..\..\..\input");
string line;
var stageOneSum = 0;
var validDigits = new Dictionary<string, string>()
{
    { "1", "1" },
    { "2", "2" },
    { "3", "3" },
    { "4", "4" },
    { "5", "5" },
    { "6", "6" },
    { "7", "7" },
    { "8", "8" },
    { "9", "9" },
    { "one", "1" },
    { "two", "2" },
    { "three", "3" },
    { "four", "4" },
    { "five", "5" },
    { "six", "6" },
    { "seven", "7" },
    { "eight", "8" },
    { "nine", "9" }
};
var stageTwoSum = 0;
while ((line = reader.ReadLine()) != null)
{
    var stageOneDigitString = Regex.Replace(line, @"[^\d]", "");
    stageOneSum += int.Parse($"{stageOneDigitString[0]}{stageOneDigitString[^1]}");
    
    var firstDigit = "";
    var firstIndex = line.Length - 1;
    var lastDigit = "";
    var lastIndex = 0;
    foreach (KeyValuePair<string, string> digit in validDigits)
    {
        var indexFromBeginning = line.IndexOf(digit.Key);
        var indexFromEnd = line.LastIndexOf(digit.Key);
        if (indexFromBeginning != -1 && indexFromBeginning <= firstIndex)
        {
            firstIndex = indexFromBeginning;
            firstDigit = digit.Value;
        }
        
        if (indexFromEnd != -1 && indexFromEnd >= lastIndex)
        {
            lastIndex = indexFromEnd;
            lastDigit = digit.Value;
        }
    }
    stageTwoSum += int.Parse($"{firstDigit}{lastDigit}");
}
Console.WriteLine(stageOneSum);
Console.WriteLine(stageTwoSum);

