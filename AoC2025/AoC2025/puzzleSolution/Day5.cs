
class AoC2025Day5
{

    public static void Part1()
    {
        int day = 5;
        long answer = 0;

        string[] input = readInput(day, false);

        var ranges = new List<Range>();
        

        foreach (string line in input)
        {
            if (line.Contains('-'))
            {
                string[] values = line.Split('-');
                ranges.Add(new Range(long.Parse(values[0]), long.Parse(values[1])));
            }

            else
            {
                long value = long.Parse(line);

                foreach (var range in ranges)
                {
                    if (value >= range.start && value <= range.end)
                    {
                        answer++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 5;
        long answer = 0;

        string[] input = readInput(day, false);

        var ranges = new List<Range>();


        foreach (string line in input)
        {
            if (line.Contains('-'))
            {
                string[] values = line.Split('-');
                ranges.Add(new Range(long.Parse(values[0]), long.Parse(values[1])));
            }
        }

        ranges = ranges.OrderBy(x => x.start).ToList();

        var checkedRanges = new List<int>();
        var mergedRanges = new List<Range>();

        for(int i = 0; i < ranges.Count; i++ )
        {
            if (checkedRanges.Contains(i))
                continue;

            Range range = ranges[i];

            for (int j = 0; j < ranges.Count; j++)
            {
                if ( i == j)
                    continue;

                if (checkedRanges.Contains(j))
                    continue;

                Range validateRange = ranges[j];
                if (validateRange.start >= range.start && validateRange.end <= range.end)
                {
                    checkedRanges.Add(j);
                }
                else if (validateRange.start >= range.start && validateRange.start <= range.end)
                {
                    range.end = validateRange.end;
                    checkedRanges.Add(j);
                }
            }

            mergedRanges.Add(range);
        }

        foreach (Range range in mergedRanges)
        {
            long subAnswer = range.end - range.start +1;
            answer += subAnswer;
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

public class Range
{
    public long start, end;
    public Range(long start, long end)
    {
        this.start = start;
        this.end = end;
    }
}


