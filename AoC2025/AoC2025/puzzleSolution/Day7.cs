class AoC2025Day7
{
    static char[,] grid;
    static int rows, cols;
    static HashSet<string> timelines = new HashSet<string>();


    public static void Part1()
    {
        int day = 7;
        long answer = 0;

        string[] input = readInput(day, true);

        var processInput = new List<Char[]>();

        for (int i = 0; i < input.Length; i++)
        {
            processInput.Add(input[i].ToCharArray());
        }

        int rows = processInput.Count;
        int columns = processInput[0].Length;

        for (int r = 0; r < rows - 1; r++) //No need to check last row
        {
            if (r == 0)
            {
                //Find Start
                int startIndex = processInput[0].IndexOf("S");
                var reply = CheckForSplitAndUpdate(processInput, r, startIndex);
                processInput = reply.Item1;
                if (reply.Item2)
                {
                    answer++;
                }
            }
            else
            {
                for (int c = 0; c < columns; c++)
                {
                    if (processInput[r][c] == '|')
                    {
                        var reply = CheckForSplitAndUpdate(processInput, r, c);
                        processInput = reply.Item1;
                        if (reply.Item2)
                        {
                            answer++;
                        }
                    }
                }
            }

            Console.WriteLine($"Row {r} answer {answer}");

        }

        Console.WriteLine($"The answer of day {day} = {answer}");

    }
    public static void Part2()
    {
        int day = 7;
        long answer = 0;

        string[] input = readInput(day, false);

        rows = input.Length;
        cols = input[0].Length;
        grid = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = input[r][c];
            }
        }

        int startIndex = input[0].IndexOf("S");

        PathSearch(0, startIndex, new List<(int, int)>());


        Console.WriteLine($"The answer of day {day} = {timelines.Count}");

    }

    static void PathSearch(int r, int c, List<(int, int)> path)
    {
        //Out of bounds or no split
        if (r >= rows || c < 0 || c >= cols)
        {
            return;
        }

        path.Add((r, c));

        //End reached
        if (r == rows - 1)
        {
            string fullPath = string.Join(";", path);
            timelines.Add(fullPath);
            //timelines.Add(fullPath);
            path.RemoveAt(path.Count - 1);
            return;
        }

        if (grid[r, c] == '^')
        {
            // Handle split
            PathSearch(r, c - 1, new List<(int, int)>(path));
            PathSearch(r, c + 1, new List<(int, int)>(path));
        }
        else
        {
            PathSearch(r + 1, c, path);
        }

        path.RemoveAt(path.Count - 1);
    }

    public static (List<Char[]>, bool) CheckForSplitAndUpdate(List<Char[]> fullInput, int row, int index)
    {
        bool isSplit = false;

        if (fullInput[row + 1][index] == '^')
        {
            isSplit = true;
            fullInput[row + 1][index - 1] = '|';
            fullInput[row + 1][index + 1] = '|';
        }
        else
        {
            fullInput[row + 1][index] = '|';
        }

        return (fullInput, isSplit);
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


