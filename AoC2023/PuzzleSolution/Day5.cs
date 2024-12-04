using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class AoC2023Day5
{

    public static void Part1() {
        int day = 5;
        int answer = 0;

        string[] data = readInput(day, true);

        //list seeds
        List<string> list = new List<string>(data[0].Split(""));
        List<int> seeds = new List<int>();
        for (int i = 1; i < list.Count; i++) {
            seeds.Add(int.Parse(list[i]));
        }

        //put mapping in dict
        Dictionary<int, int[]> seedSoilMap = new Dictionary<int, int[]>();
        Dictionary<int, int[]> soilToFertilizerMap = new Dictionary<int, int[]>();
        Dictionary<int, int[]> fertilizerToWaterMap = new Dictionary<int, int[]>();
        Dictionary<int, int[]> waterToLightMap = new Dictionary<int, int[]>();
        Dictionary<int, int[]> lightToTemperature = new Dictionary<int, int[]>();
        Dictionary<int, int[]> temperatureToHumidity = new Dictionary<int, int[]>();
        Dictionary<int, int[]> humidityToLocation = new Dictionary<int, int[]>();

        for (int i = 1; i < data.Count(); i++) 
        { 
                

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
