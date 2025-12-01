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
            while (position < 0 ) { 
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
            string lineText = line;
            if (line.Contains("L"))
                lineText = line.Replace('L', '-');

            if (line.Contains("R"))
                lineText = line.Replace("R", "");

            int value = Convert.ToInt32(lineText);

            if (value < -99)
            {
                int fullRotations = value / 100;
                int diff = value - (fullRotations * 100);
                answer += Math.Abs(value / 100);
                position += diff;

                if (position == 0)
                {
                    answer++;
                }
            }

            else if (value > 100)
            {
                int fullRotations = value / 100;
                int diff = value - (fullRotations * 100);
                answer += value / 100;
                position += diff;
            }

            else {
                position += value;
            }

            //handle overflow or exact position

            if (position > 99)
            {
                position = position - 100;
                answer++;
            }
            if (position < 0)
            {
                position = 100 + position;
                answer++;
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


