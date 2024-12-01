using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
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


            Console.WriteLine($"The answer is of day {day} = {answer}");
        }

        public static string[] readInput(int day, bool useExample)
        {
            if (useExample)
            {
                string[] exampleInput = File.ReadAllLines($"C:/Users/bramv/source/repos/Bram-van-Trigt/AdventOfCode2022/AdventOfCode2022/puzzleInputFiles/exampleInputDay{day}.txt");
                return exampleInput;
            }
            else
            {
                string[] puzzleInput = File.ReadAllLines($"C:/Users/bramv/source/repos/Bram-van-Trigt/AdventOfCode2022/AdventOfCode2022/puzzleInputFiles/puzzleInputDay{day}.txt");
                return puzzleInput;
            }
        }

    }
}
