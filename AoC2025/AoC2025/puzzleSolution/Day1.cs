class AoC2025Day1
{

    public static void Part1()
    {
        int day = 1;
        int answer = 0;

        string[] input = readInput(day, false);

        int position = 50;

        foreach (var line in input)
        {
            string lineText = line;
            if (line.Contains("L"))
                lineText = line.Replace('L', '-');

            if (line.Contains("R"))
                lineText = line.Replace("R", "");

            int value = Convert.ToInt32(lineText);

            position += value;

            // handle overflow
            while (position < 0)
            {
                position = 100 + position;

            }
            while (position > 99)
            {
                position = position - 100;
            }

            Console.WriteLine(position);

            // check for correct position
            if (position == 0) { answer++; }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 1;
        int answer = 0;

        string[] input = readInput(day, false);

        int position = 50;

        foreach (var line in input)
        {
            int start = position;

            string lineText = line;
            if (line.Contains("L"))
                lineText = line.Replace('L', '-');

            if (line.Contains("R"))
                lineText = line.Replace("R", "");

            int value = Convert.ToInt32(lineText);

            int fullRotations = value / 100;
            int diff = value - (fullRotations * 100);
            answer += Math.Abs(value / 100);
            int end = start + diff;

            //handle overflow or exact position
            //if (end == 0)
            //{
            //    answer++;
            //    position = end;
            //}
            if (end > 99)
            {
                position = end - 100;
                answer++;
            }
            else if (end < 0)
            {
                position = 100 + end;
                answer++;
            }
            else
            {
                position = end;
            }

            Console.WriteLine($"position {position}");
            Console.WriteLine($"answer {answer}");

        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static string[] readInput(int day, bool useExample)
    {
        if (useExample)
        {
            string[] exampleInput = File.ReadAllLines($"./puzzleInputFiles/exampleInputDay1.txt");
            return exampleInput;
        }
        else
        {
            string[] puzzleInput = File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay1.txt");
            return puzzleInput;
        }
    }

}


