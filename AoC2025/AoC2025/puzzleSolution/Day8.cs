using System.Numerics;

class AoC2025Day8
{
    static char[,] grid;
    static int rows, cols;
    static HashSet<string> timelines = new HashSet<string>();

    public static void Part1()
    {
        int day = 8;
        long answer = 0;

        string[] input = readInput(day, true);

        var junctionBoxes = new List<JunctionBox>();

        // Get a nearestJb for every jb
        for (int i = 0; i < input.Length; i++)
        {
            var junctionBox = new JunctionBox(input[i]);

            for (int j = 0; j < input.Length; j++)
            {
                if (i == j) continue;

                double dist = CalculateDistance(junctionBox, new JunctionBox(input[j]));
                if (junctionBox.distance == null || junctionBox.distance < dist)
                {
                    junctionBox.distance = dist;
                    junctionBox.nearestJB = input[j];
                }
            }

            junctionBoxes.Add(junctionBox);
        }

        var orderedJunctionBoxes = junctionBoxes.OrderBy(junctionBox => junctionBox.distance);

        Console.WriteLine($"The answer of day {day} = {answer}");

    }
    //public static void Part2()
    //{

    //}

    public static double CalculateDistance(JunctionBox jb1, JunctionBox jb2)
    {
        Vector3 pos1 = new Vector3(jb1.posX, jb1.posY, jb1.posZ);
        Vector3 pos2 = new Vector3(jb2.posX, jb2.posY, jb2.posZ);

        return Vector3.Distance(pos1, pos2);
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

struct JunctionBox
{

    public string name;
    public int posY, posX, posZ;
    public string? nearestJB;
    public double? distance;

    public JunctionBox(string name)
    {
        string[] positions = name.Split(',').ToArray();

        this.name = name;
        this.posX = int.Parse(positions[0]);
        this.posY = int.Parse(positions[1]);
        this.posZ = int.Parse(positions[2]);
    }
}

    


