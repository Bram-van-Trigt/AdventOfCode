using System.Data;

public static class AoC2024Day5
{
    public static void Part1()
    {
        int day = 5;
        int answer = 0;
        bool useExample = true;

        List<int[]> orderRules = readOrderingRules(day, useExample);
        List<int[]> pages = readPagesToProduce(day, useExample);

        foreach (int[] pageLine in pages){
            bool isValid = validateOrder(pageLine, orderRules);
            if (isValid){
                answer += pageLine[pageLine.Length/2];
            }
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static bool validateOrder(int[]pageLine, List<int[]> orderRules){
        bool valid = true;

        foreach (int[] rule in orderRules){

            int indexBefore = Array.IndexOf(pageLine, rule[0]);
            int indexAfter = Array.IndexOf(pageLine, rule[1]);

            if(indexBefore > indexAfter && !(indexBefore == -1) && !(indexAfter == -1)){
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