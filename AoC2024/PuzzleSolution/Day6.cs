public static class AoC2024Day6
{
    public static void Part1()
    {
        int day = 6;
        int answer = 0;
        bool useExample = true;

        string[] input = readInput(day, useExample);
        List<char[]> arrea = new List<char[]>();

        for (int i = 0; i < input.Length; i++)
        {
            arrea.Add(input[i].ToCharArray());
        }
        Console.WriteLine("arrea created");

        //Find starting point
        int south = 0;
        int east = 0;

        for (int s = 0; s < arrea.Count; s++)
        {
            for (int e = 0; e < arrea[s].Length; e++)
            {
                if (arrea[s][e] == '^')
                {
                    south = s;
                    east = e;
                    break;
                }
            }

            if (south != 0)
            {
                break;
            }
        }

        Console.WriteLine($"Startingpoint: {south},{east}");

        //Move further in direction
        while (south < arrea.Count && east < arrea[east].Length)
        {
            Console.WriteLine($"location: {south}, {east}");

            switch (arrea[south][east])
            {
                case '^':
                    //move north if free space
                    try
                    {
                        if (arrea[south - 1][east] == '#')
                        {
                            //switch direction
                            arrea[south][east] = '>';
                        }
                        else
                        {
                            //mark new location
                            arrea[south - 1][east] = '^';
                            //mark passed true
                            arrea[south][east] = 'X';
                            south--;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Out of bounds north side");
                        south--;
                        break;
                    }
                    break;

                case 'v':
                    //move south if free space
                    try
                    {
                        if (arrea[south + 1][east] == '#')
                        {
                            //switch direction
                            arrea[south][east] = '<';
                        }
                        else
                        {
                            //mark new location
                            arrea[south + 1][east] = 'v';
                            //mark passed true
                            arrea[south][east] = 'X';
                            south++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Out of bounds north side");
                        south++;
                        break;
                    }
                    break;

                case '>':
                    //move east if free space
                    try
                    {
                        if (arrea[south][east + 1] == '#')
                        {
                            //switch direction
                            arrea[south][east] = 'v';
                        }
                        else
                        {
                            //mark new location
                            arrea[south][east + 1] = '>';
                            //mark passed true
                            arrea[south][east] = 'X';
                            east++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Out of bounds north side");
                        east++;
                        break;
                    }
                    break;

                case '<':
                    //move west if free space
                    try
                    {
                        if (arrea[south][east - 1] == '#')
                        {
                            //switch direction
                            arrea[south][east] = '^';
                        }
                        else
                        {
                            //mark new direction
                            arrea[south][east - 1] = '<';
                            //mark passed true
                            arrea[south][east] = 'X';
                            east--;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Out of bounds north side");
                        east--;
                        break;
                    }
                    break;
            }
        }

        foreach (char[] line in arrea){
            answer += line.Count(s => s == 'X');
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
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