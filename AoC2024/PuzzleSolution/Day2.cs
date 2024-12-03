using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    public static class AoC2024Day2
    {

        public static void Part1() {
            int day = 2;
            int answer = 0;

            string[] data = readInput(day, false);
            
            foreach (string report in data) {
                int[] reportValues = report.Split(' ')?.Select(Int32.Parse)?.ToArray()!;
                bool isSafe = validate(reportValues);
                
                if (isSafe) { answer++; }
            }

            Console.WriteLine($"The answer is of day {day} = {answer}");
        }

        public static void Part2() {
            int day = 2;
            int answer = 0;

            string[] data = readInput(day, false);

            foreach (string report in data) {
                    
                int[] reportValues = report?.Split(' ')?.Select(Int32.Parse)?.ToArray()!;
                bool isSafe = false;

                //check report without skip
                if (validate(reportValues)){
                    answer++;
                    continue;
                }
                else {
                    isSafe = false;

                    for (int i = 0; i < reportValues.Length; i++) {
                        if ( i == 0)
                        {
                            //skip first level
                            isSafe = validate(reportValues.Skip(1).ToArray());    
                        }
                        else if ( i == reportValues.Length - 1 )
                        {
                            //skip last level
                            isSafe = validate(reportValues.Skip(0).Take(reportValues.Length - 1).ToArray());
                        }
                        else{
                            int[] partOne = reportValues.Skip(0).Take(i).ToArray();
                            int[] partTwo = reportValues.Skip(i+1).Take(reportValues.Length - i - 1).ToArray();
                            Console.WriteLine($"{partOne.Concat(partTwo).ToArray()}" , reportValues.Length-1);
                            isSafe = validate(partOne.Concat(partTwo).ToArray());
                        } 
                        if (isSafe) { 
                                answer++;
                                break;
                        }
                    }   
                }
            }
            Console.WriteLine($"The answer is of day {day} part 2 = {answer}");
        }

        private static bool validate(int[] reportValues) {
                
                bool decrease = false;
                bool increase = false;
                bool safeReport = true;

                for (int i = 0; i < (reportValues.Length-1); i++){
                    int diff = reportValues[i+1] - reportValues[i];

                    //check for increase/ decrease and stepsize
                    if ( 0 < diff && diff <= 3 ) {
                        increase = true;
                    }
                    else if ( -3 <= diff && diff < 0){
                        decrease = true;
                    }
                    else {
                        safeReport = false;
                        break;
                    }                    
                }

                if ( (!decrease && increase && safeReport) || (decrease && !increase && safeReport) ) {
                    return true;
                }
                else {
                    return false;
                }
        }       

        public static string[] readInput(int day, bool useExample)
        {
            if (useExample)
            {
                string[] exampleInput = File.ReadAllLines($"C:/Users/bramv/source/repos/Bram-van-Trigt/AdventOfCode/AoC2024/puzzleInputFiles/exampleInputDay{day}.txt");
                return exampleInput;
            }
            else
            {
                string[] puzzleInput = File.ReadAllLines($"C:/Users/bramv/source/repos/Bram-van-Trigt/AdventOfCode/AoC2024/puzzleInputFiles/puzzleInputDay{day}.txt");
                return puzzleInput;
            }
        }

    }
}
