using QuickGraph;
using QuickGraph.Algorithms;
using System.Numerics;


class AoC2025Day8
{
    public static void Part1()
    {
        int day = 8;
        bool example = false;

        string[] input = readInput(day, example);

        var jbs = new List<JunctionBox>();

        foreach (string box in input)
        {
            jbs.Add(new JunctionBox(box));
        }
        Console.WriteLine($"Created {jbs.Count} junction boxes");

        // Calculate all distances
        var distances = new List<(string A, string B, double Dist)>();
        for (int i = 0; i < jbs.Count; i++)
        {
            for (int j = i + 1; j < jbs.Count; j++)
            {
                double dist = CalculateDistance(jbs[i], jbs[j]);
                distances.Add((jbs[i].name, jbs[j].name, dist));
            }
        }

        // Sort for shortest distance
        distances.Sort((e1, e2) => e1.Dist.CompareTo(e2.Dist));

        var graph = new UndirectedGraph<string, Edge<string>>(false);
        foreach (var jb in jbs) graph.AddVertex(jb.name);

        int attemptedConnections;
        if (example) attemptedConnections = 10;
        else attemptedConnections = 1000;

        for (int n = 0; n < attemptedConnections; n++)
        {
            var e = distances[n];
            graph.AddEdge(new Edge<string>(e.A, e.B));
        }

        // Get connected junction boxes
        var componentMap = new Dictionary<string, int>();
        int componentCount = graph.ConnectedComponents(componentMap);

        // Compute component sizes from the mapping
        var sizes = new Dictionary<int, int>();
        foreach (var jb in componentMap)
        {
            int component = jb.Value;
            if (!sizes.TryGetValue(component, out var count)) sizes[component] = 1;
            else sizes[component] = count + 1;
        }

        var result = sizes.Values.OrderByDescending(x => x).Take(3).ToList();
        long answer = 1;
        
        foreach (var s in result)
        {
            answer *= s;
        }

        Console.WriteLine($"Biggest Circuits: {string.Join(", ", result)}");
        Console.WriteLine($"Answer of day{day} = {answer}");
    }

    public static void Part2()
    {
        int day = 8;
        bool example = false;

        string[] input = readInput(day, example);

        var jbs = new List<JunctionBox>();

        foreach (string box in input)
        {
            jbs.Add(new JunctionBox(box));
        }
        Console.WriteLine($"Created {jbs.Count} junction boxes");

        // Calculate all distances
        var distances = new List<(string A, string B, double Dist)>();
        for (int i = 0; i < jbs.Count; i++)
        {
            for (int j = i + 1; j < jbs.Count; j++)
            {
                double dist = CalculateDistance(jbs[i], jbs[j]);
                distances.Add((jbs[i].name, jbs[j].name, dist));
            }
        }

        // Sort for shortest distance
        distances.Sort((e1, e2) => e1.Dist.CompareTo(e2.Dist));
        var jbByName = jbs.ToDictionary(x => x.name);

        var graph = new UndirectedGraph<string, Edge<string>>(false);
        foreach (var jb in jbs) graph.AddVertex(jb.name);

        string? lastA = null;
        string? lastB = null;

        // Add edges one by one
        for (int n = 0; n < distances.Count; n++)
        {
            var e = distances[n];
            graph.AddEdge(new Edge<string>(e.A, e.B));

            var componentMap = new Dictionary<string, int>();
            int componentCount = graph.ConnectedComponents(componentMap);

            if (componentCount == 1)
            {
                lastA = e.A;
                lastB = e.B;
                break;
            }
        }

        if (lastA is null || lastB is null)
        {
            Console.WriteLine("Did not reach a single component.");
            return;
        }

        long x1 = jbByName[lastA].posX;
        long x2 = jbByName[lastB].posX;
        long answer = x1 * x2;

        Console.WriteLine($"Last connected: {lastA} - {lastB}");
        Console.WriteLine($"Answer of day{day} = {answer}");
    }

    public static double CalculateDistance(JunctionBox jb1, JunctionBox jb2)
    {
        Vector3 point1 = new Vector3(jb1.posX, jb1.posY, jb1.posZ);
        Vector3 point2 = new Vector3(jb2.posX, jb2.posY, jb2.posZ);
        return Vector3.Distance(point1, point2);  
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

class JunctionBox
{
    public string name;
    public int posY, posX, posZ;

    public JunctionBox(string name)
    {
        string[] positions = name.Split(',').ToArray();

        this.name = name;
        this.posX = int.Parse(positions[0]);
        this.posY = int.Parse(positions[1]);
        this.posZ = int.Parse(positions[2]);
    }
}









