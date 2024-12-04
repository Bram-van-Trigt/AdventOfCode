using System;
using System.IO;

namespace AdventOfCode
{
    public static class AoC2023Day0
    {

        public static void Part1() {
            int day = 0;
            int answer = 0;

            string[] data = readInput(day, true);

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
}
