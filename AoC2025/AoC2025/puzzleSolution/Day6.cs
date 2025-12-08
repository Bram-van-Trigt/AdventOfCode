class AoC2025Day6
{

    public static void Part1()
    {
        int day = 6;
        long answer = 0;

        string[] input = readInput(day, false);

        var processInput = new List<List<string>>();

        for (int i = 0; i < input.Length; i++)
        {
            List<string> splitLine = input[i].Split(' ').ToList<string>();
            splitLine.RemoveAll(s => s == "");
            processInput.Add(splitLine);
        }

        int rows = processInput.Count;
        int columns = processInput[0].Count;

        for (int c = 0; c < columns; c++)
        {
            long subAnswer = 0;
            string action = processInput[rows - 1][c];
            if (action == "*")
            {
                subAnswer = 1;
            }

            for (int r = 0; r < rows - 1; r++) //skip last row 
            {
                if (action == "*")
                {
                    subAnswer *= long.Parse(processInput[r][c]);
                }
                else
                {
                    subAnswer += long.Parse(processInput[r][c]);
                }
            }

            answer += subAnswer;
        }



        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 6;
        long answer = 0;

        string[] input = readInput(day, false);

        var processInput = new List<List<string>>();

        int rows = input.Length;
        int columns = input[0].Length;

        long subAnswer = 0;
        char action = ' ';

        for (int c = 0; c < columns; c++)
        {
            string subValue = "";

            //check action
            if (input[rows - 1][c] != ' ')
            {
                action = input[rows - 1][c];
                if (action == '*') subAnswer = 1;
                else subAnswer = 0;
            }

            //Get values or split string
            //Skip last row, already checked above
            for (int r = 0; r < rows - 1; r++)
            {
                if (input[r][c] != ' ')
                {
                    subValue = subValue + input[r][c];
                }
            }

            Console.WriteLine($"SubValue == {subValue}");

            if (int.TryParse(subValue, out int value))
            {
                if (action == '*')
                {
                    subAnswer *= value;
                }
                else
                {
                    subAnswer += value;
                }

                if (c == columns - 1)
                {
                    answer += subAnswer;
                }
            }
            else
            {
                Console.WriteLine($"sub answer = {subAnswer}");
                answer += subAnswer;
                subAnswer = 0;

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


