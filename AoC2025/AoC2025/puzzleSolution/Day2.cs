class AoC2025Day2
{

    public static void Part1()
    {
        int day = 2;
        long answer = 0;

        string[] input = readInput(day, false);

        string[] idRanges = input[0].Split(',');

        foreach (var idRange in idRanges)
        {
            string[] bounds = idRange.Split('-');
            long lowerBound = long.Parse(bounds[0]);
            long upperBound = long.Parse(bounds[1]);

            for (long i = lowerBound; i <= upperBound; i++)
            {
                string id = i.ToString();
                int idLength = id.Length;
                int halfLength = idLength / 2;

                //Odd id lengths can be skipped
                if (idLength % 2 == 0)
                {
                    string firstHalf = id.Substring(0, halfLength);
                    string secondHalf = id.Substring(halfLength, halfLength);

                    if (firstHalf == secondHalf)
                    {
                        answer += i;
                    }
                }
            }

            Console.WriteLine($" sum = {answer}");
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 2;
        long answer = 0;

        string[] input = readInput(day, false);

        string[] idRanges = input[0].Split(',');

        foreach (var idRange in idRanges)
        {
            string[] bounds = idRange.Split('-');
            long lowerBound = long.Parse(bounds[0]);
            long upperBound = long.Parse(bounds[1]);


            for (long i = lowerBound; i <= upperBound; i++)
            {
                string id = i.ToString();
                int idLength = id.Length;
                
                for (int splitPos = 1; splitPos < idLength; splitPos++)
                {
                    if(idLength % splitPos != 0) continue; // must divide evenly
                    
                    string pattern = id.Substring(0, splitPos);
                    string repeatedPattern = string.Concat(Enumerable.Repeat(pattern, idLength / splitPos));
                    //Console.WriteLine($"Checking id {id} with pattern {pattern} gives {repeatedPattern}");

                    if (id == repeatedPattern)
                    {
                        Console.WriteLine($" Found matching id {id} with pattern {pattern}");
                        answer += i;
                        break; // no need to check this id further
                    }
                }
            }

            Console.WriteLine($" sum = {answer}");
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


