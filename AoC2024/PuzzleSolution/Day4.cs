using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

public static class AoC2024Day4
{
    public static void Part1()
    {
        int day = 4;
        int answer = 0;

        string[] allLines = readInput(day, false);

        //Horizontal occurance count
        foreach (string line in allLines)
        {
            answer += Regex.Matches(line, "XMAS").Count;
            answer += Regex.Matches(line, "SAMX").Count;
        }

        //Vertical occurance count
        string[] verticalLines = GetVerticalLines(allLines);
        foreach (string line in verticalLines)
        {
            answer += Regex.Matches(line, "XMAS").Count;
            answer += Regex.Matches(line, "SAMX").Count;
        }

        //Diagonal occurance count 
        List<string> diagonalLines = GetAllDiagonalLines(allLines);

        foreach (string line in diagonalLines)
        {
            answer += Regex.Matches(line, "XMAS").Count;
            answer += Regex.Matches(line, "SAMX").Count;
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 4;
        int answer = 0;

        string[] grid = readInput(day, false);

        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        int count = 0;

        for (int i = 1; i < rowCount - 1; i++)
        {
            for (int j = 1; j < colCount - 1; j++)
            {
                
                if (grid[i][j] == 'A')
                {
                    count++;
                    // M S
                    //  A
                    // M S
                    if (grid[i - 1][j - 1] == 'M' && grid[i - 1][j + 1] == 'S' && grid[i + 1][j + 1] == 'S' && grid[i + 1][j - 1] == 'M')
                    {
                        answer++;
                    }

                    //M M
                    // A
                    //S S
                    else if (grid[i - 1][j - 1] == 'M' && grid[i - 1][j + 1] == 'M' && grid[i + 1][j + 1] == 'S' && grid[i + 1][j - 1] == 'S')
                    {
                        answer++;
                    }

                    //S M
                    // A
                    //S M
                    else if (grid[i - 1][j - 1] == 'S' && grid[i - 1][j + 1] == 'M' && grid[i + 1][j + 1] == 'M' && grid[i + 1][j - 1] == 'S')
                    {
                        answer++;
                    }

                    //S S
                    // A
                    //M M
                    else if (grid[i - 1][j - 1] == 'S' && grid[i - 1][j + 1] == 'S' && grid[i + 1][j + 1] == 'M' && grid[i + 1][j - 1] == 'M')
                    {
                        answer++;
                    }
                }
            }
        }
        Console.WriteLine(count);
        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static string[] GetVerticalLines(string[] data)
    {

        int columnCount = data[0].Length;
        string[] verticalLines = new string[columnCount];

        for (int col = 0; col < columnCount; col++)
        {
            verticalLines[col] = string.Concat(data.Select(row => row[col]));
        }

        return verticalLines;
    }

    public static List<string> GetAllDiagonalLines(string[] data)
    {
        List<string> diagonalLines = new List<string>();

        int rowCount = data.Length;
        int colCount = data[0].Length;
        int diagonalCount = rowCount + colCount - 1;

        // Top-left to bottom-right diagonals
        for (int start = 0; start < diagonalCount; start++)
        {
            string diagonal = "";
            for (int i = 0; i < rowCount; i++)
            {
                int j = start - i;
                if (j >= 0 && j < colCount)
                {
                    diagonal += data[i][j];
                }
            }
            if (!string.IsNullOrEmpty(diagonal))
                diagonalLines.Add(diagonal);
        }

        // Bottom-left to top-right diagonals
        for (int start = 0; start < diagonalCount; start++)
        {
            string diagonal = "";
            for (int i = 0; i < rowCount; i++)
            {
                int j = start - (rowCount - 1 - i);
                if (j >= 0 && j < colCount)
                {
                    diagonal += data[i][j];
                }
            }
            if (!string.IsNullOrEmpty(diagonal))
                diagonalLines.Add(diagonal);
        }

        return diagonalLines;
    }


    public static string[] readInput(int day, bool useExample)
    {
        if (useExample)
        {
            return File.ReadAllLines($"./puzzleInputFiles/exampleInputDay{day}.txt");
        }
        else
        {
            return File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay{day}.txt");
        }
    }

}