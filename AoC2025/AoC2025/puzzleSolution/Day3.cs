using System.Diagnostics.CodeAnalysis;

class AoC2025Day3
{

    public static void Part1()
    {
        int day = 3;
        long answer = 0;

        string[] input = readInput(day, false);

        foreach (string line in input)
        {
            int[] values = line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

            int firstMaxValue = values.SkipLast(1).Max(); //we need two batteries
            int firstMaxIndex = Array.IndexOf(values, firstMaxValue); 

            //check subset of array
            int[] subset = values.Skip(firstMaxIndex + 1).ToArray();
            int secondMaxValue = subset.Max();

            int result = int.Parse(firstMaxValue.ToString() + secondMaxValue.ToString());

            answer += result;
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 3;
        long answer = 0;

        string[] input = readInput(day, false);

        foreach (string line in input)
        {
            int[] values = line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

            int firstMaxValue = values.SkipLast(11).Max(); //we need 12 batteries
            int firstMaxIndex = Array.IndexOf(values, firstMaxValue);

            int[] subset = values.Skip(firstMaxIndex + 1).ToArray();
            string subResult = firstMaxValue.ToString();

            //check subset of array
            for (int i = 1; i < 12; i++)
            {
                int nextMaxValue = subset.SkipLast(11-i).Max();
                int nextMaxIndex = Array.IndexOf(subset, nextMaxValue);

                subset = subset.Skip(nextMaxIndex + 1).ToArray();
                subResult += nextMaxValue.ToString();
            }

            long result = long.Parse(subResult);
            Console.WriteLine($"Intermediate result: {result}");
            answer += result;
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


