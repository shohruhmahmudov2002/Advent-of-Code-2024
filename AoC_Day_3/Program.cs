using System.Text.RegularExpressions;
namespace Aoc_Day_3;
internal class Program
{
    static void Main(string[] args)
    {
        string path = "D:\\C# darslar\\AoC event\\Aoc_Day_3\\AoC3.txt";
        //if (!File.Exists(path)) { File.Create(path); }
        MatchCollection matches = ReadText(path);
        int sum = 0;
        foreach (Match match in matches) 
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);
            sum += num1 * num2;
        }
        Console.WriteLine(sum); //Part 1 result
        Console.WriteLine(ReadTextCase(path));  //Part2 result
    }
    static MatchCollection ReadText(string path)
    {
        string pattern = @"mul\((\d+),(\d+)\)";
        using var sr = new StreamReader(path);
        return Regex.Matches(sr.ReadToEnd(), pattern, RegexOptions.Multiline);
    }
    static int ReadTextCase(string path)
    {
        string pattern = @"(do\(\)|don't\(\)|mul\((\d+),(\d+)\))";
        bool isEnabled = true;
        int sum = 0;
        using var sr = new StreamReader(path);
        MatchCollection matches = Regex.Matches(sr.ReadToEnd(), pattern, RegexOptions.Multiline);
        foreach (Match match in matches) 
        {
            if (match.Value.StartsWith("do()"))
                isEnabled = true;
            else if(match.Value.StartsWith("don't()"))
                isEnabled = false;
            else if(match.Value.StartsWith("mul(") && isEnabled)
            {
                int num1 = int.Parse(match.Groups[2].Value);
                int num2 = int.Parse(match.Groups[3].Value);
                sum += num1 * num2;
            }
        }
        return sum;
    }
}

