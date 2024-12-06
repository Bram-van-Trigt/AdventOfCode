using System;
using System.Data;
using QuickGraph;
using QuickGraph.Algorithms;

public static class AoC2024Day5
{
    public static void Part1()
    {
        int day = 5;
        int answer = 0;
        bool useExample = false;

        List<int[]> orderRules = readOrderingRules(day, useExample);
        List<int[]> pages = readPagesToProduce(day, useExample);

        foreach (int[] pageLine in pages)
        {
            bool isValid = validateOrder(pageLine, orderRules);
            if (isValid)
            {
                answer += pageLine[pageLine.Length / 2];
            }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 5;
        int answer = 0;
        bool useExample = false;

        List<int[]> orderRules = readOrderingRules(day, useExample);
        List<int[]> pages = readPagesToProduce(day, useExample);

        

        foreach (int[] pageLine in pages)
        {
            bool isValid = validateOrder(pageLine, orderRules);
            if (!isValid)
            {   
                List<int[]> tempRules = new List<int[]>();

                foreach ( int[] rule in orderRules){
                    if (pageLine.Contains(rule[0])){
                        tempRules.Add(rule);
                    }
                }

                var graphOrder = CreateGraph(tempRules);

                var newPageList = graphOrder.Where(node => pageLine.Contains(node)).ToArray();
                answer += newPageList[newPageList.Count() / 2];
            }
        }
        Console.WriteLine($"The answer of day {day} = {answer}");
    }


    public static int[] CreateGraph(List<int[]> rules)
    {

        var graph = new AdjacencyGraph<int, Edge<int>>();

        foreach (int[] rule in rules)
        {
            if (!graph.ContainsVertex(rule[0]))
            {
                graph.AddVertex(rule[0]);
            }
            if (!graph.ContainsVertex(rule[1]))
            {
                graph.AddVertex(rule[1]);
            }
            if (!graph.ContainsEdge(rule[0], rule[1]))
            {
                graph.AddEdge(new Edge<int>(rule[0], rule[1]));
            }
        }

        var sortedOrder = graph.TopologicalSort().ToArray();
        return sortedOrder;
    }

    public static bool validateOrder(int[] pageLine, List<int[]> orderRules)
    {
        bool valid = true;

        foreach (int[] rule in orderRules)
        {

            int indexBefore = Array.IndexOf(pageLine, rule[0]);
            int indexAfter = Array.IndexOf(pageLine, rule[1]);

            if (indexBefore > indexAfter && !(indexBefore == -1) && !(indexAfter == -1))
            {
                valid = false;
            }
        }

        return valid;
    }

    public static List<int[]> readOrderingRules(int day, bool useExample)
    {
        string fileName;
        if (useExample)
        {
            fileName = "example";
        }
        else
        {
            fileName = "puzzle";
        }

        string[] file = File.ReadAllLines($"./puzzleInputFiles/{fileName}InputDay{day}A.txt");

        List<int[]> result = new List<int[]>();
        for (int i = 0; i < file.Length; i++)
        {
            result.Add(file[i].Split('|').Select(int.Parse).ToArray());
        }

        return result;
    }

    public static List<int[]> readPagesToProduce(int day, bool useExample)
    {
        string fileName;
        if (useExample)
        {
            fileName = "example";
        }
        else
        {
            fileName = "puzzle";
        }

        string[] file = File.ReadAllLines($"./puzzleInputFiles/{fileName}InputDay{day}B.txt");

        List<int[]> result = new List<int[]>();
        for (int i = 0; i < file.Length; i++)
        {
            result.Add(file[i].Split(',').Select(int.Parse).ToArray());
        }

        return result;
    }
}