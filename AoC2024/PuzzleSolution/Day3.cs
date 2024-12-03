using System.Text.RegularExpressions;

public static class AoC2024Day3
{
    public static void Part1() {
        int day = 3;
        int answer = 0;

        string data = readInput(day, true);    
        answer += RegexFind(data);

        Console.WriteLine($"The answer is of day {day} = {answer}");
    }

    public static void Part2() {
        int day = 3;
        int answer = 0;

        string data = readInput(day, true);

        string[] doSplit = data.Split("do()");
        foreach (string startDo in doSplit) {
            string[] dontSplit = startDo.Split("don't()");
            answer += RegexFind(dontSplit[0]);
        }

        Console.WriteLine($"The answer is of day {day} = {answer}");
    }   

    public static int RegexFind(string search){
        int subAnswer = 0;

        //Regex setup
        string pattern = @"mul\((\d+),(\d+)\)";
        Regex regex= new Regex(pattern);
        MatchCollection mulMatches = regex.Matches(search);            
        
        foreach (Match match in mulMatches) {
            if (match.Value.Length <= 12) {
                int multiplication = int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                subAnswer += multiplication;
            }
        }

        return subAnswer;
    }

    public static string readInput(int day, bool useExample)
    {
        if (useExample)
        {
            string exampleInput = File.ReadAllText($"./puzzleInputFiles/exampleInputDay{day}.txt");
            return exampleInput;
        }
        else
        {
            string puzzleInput = File.ReadAllText($"./puzzleInputFiles/puzzleInputDay{day}.txt");
            return puzzleInput;
        }
    }

}