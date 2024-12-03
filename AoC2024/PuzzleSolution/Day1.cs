public static class AoC2024Day1
{
    public static void Part1() {
        int day = 1;
        int answer = 0;

        string[] data = readInput(day, true);

        int[] leftRow = new int[data.Length];
        int[] rightRow = new int[data.Length];


        for (int i = 0; i < data.Length; i++)
    {
            string[] row = data[i].Split(" ");
            leftRow[i] = Convert.ToInt32(row[0]);
            rightRow[i] = Convert.ToInt32(row[1]);
        }

        Array.Sort(leftRow);
        Array.Sort(rightRow);

        for (int i = 0; i < leftRow.Length ; i++){
            int distance = rightRow[i] - leftRow[i];
            answer += int.Abs(distance); 
        }

        Console.WriteLine($"The answer is of day {day} = {answer}");
    }

    public static void Part2() {
        int day = 1;
        int answer = 0;

        string[] data = readInput(day, false);

        int[] leftRow = new int[data.Length];
        int[] rightRow = new int[data.Length];


        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(" ");
            leftRow[i] = Convert.ToInt32(row[0]);
            rightRow[i] = Convert.ToInt32(row[1]);
        }

        for (int i = 0; i < leftRow.Length ; i++){
            int[] result = Array.FindAll(rightRow, x => x == leftRow[i]);
            int value = leftRow[i] * result.Length;
            answer += value; 
        }

        Console.WriteLine($"The answer is of day {day} part 2 = {answer}");
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

