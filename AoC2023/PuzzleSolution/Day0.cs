using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public static class AoC2023Day0
    {

        public static void Part1() {
            int day = 0;
            int answer = 0;

            string[] data = readInput(day, true);

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
