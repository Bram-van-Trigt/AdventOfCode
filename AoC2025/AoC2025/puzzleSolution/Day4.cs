using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

class AoC2025Day4
{

    public static void Part1()
    {
        int day = 4;
        long answer = 0;

        string[] input = readInput(day, false);

        //Add outer lines array for easier processing
        var processInput = new List<string>();
        processInput.Add(new string('0', input[0].Length + 2)); //firstline

        foreach (string line in input)
        {
            string extendedLine = "0" + line + "0";
            processInput.Add(extendedLine);
        }
        
        processInput.Add(new string('0', input[0].Length + 2)); //lastline

        //Process updated input

        for (int i = 0; i < processInput.Count - 1; i++)
        {
            for (int j = 0; j < processInput[i].Length - 1; j++)
            {
                char currentChar = processInput[i][j];
                              
                if (currentChar == '@')
                {
                    int startIndexCheck = j - 1;
                    string aboveLine = processInput[i - 1].Substring(startIndexCheck, 3);
                    string belowLine = processInput[i + 1].Substring(startIndexCheck, 3);
                    string currentLine = processInput[i].Substring(startIndexCheck, 3);

                    string combinedText = aboveLine + belowLine + currentLine;

                    if (combinedText.Count(c => c == '@') < 5) //Including itself max value is 5
                    {
                        answer++;
                    }
                }
            }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 4;
        long answer = 0;

        string[] input = readInput(day, false);

        //Add outer lines array for easier processing
        var processInput = new List<string>();
        processInput.Add(new string('0', input[0].Length + 2)); //firstline

        foreach (string line in input)
        {
            string extendedLine = "0" + line + "0";
            processInput.Add(extendedLine);
        }

        processInput.Add(new string('0', input[0].Length + 2)); //lastline

        //Process updated input

        answer = 0;
        long lastAnswer = -1;

        while (lastAnswer != answer)
        {
            lastAnswer = answer;

            for (int i = 0; i < processInput.Count - 1; i++)
            {
                for (int j = 0; j < processInput[i].Length - 1; j++)
                {
                    char currentChar = processInput[i][j];

                    if (currentChar == '@')
                    {
                        int startIndexCheck = j - 1;
                        string aboveLine = processInput[i - 1].Substring(startIndexCheck, 3);
                        string belowLine = processInput[i + 1].Substring(startIndexCheck, 3);
                        string currentLine = processInput[i].Substring(startIndexCheck, 3);

                        string combinedText = aboveLine + belowLine + currentLine;

                        if (combinedText.Count(c => c == '@') < 5) //Including itself max value is 5
                        {
                            processInput[i] = processInput[i].Remove(j, 1).Insert(j, "0");
                            answer++;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static string[] readInput(int day, bool useExample)
    {
        if (useExample)
        {
            string[] exampleInput = File.ReadAllLines($"./puzzleInputFiles/exampleInputDay{day}.txt");
            return exampleInput;
        }
        else
        {
            string[] puzzleInput = File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay{day}.txt");
            return puzzleInput;
        }
    }

}


