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

                bool decrease = false;
                bool increase = false;
                bool safeReport = true;

                int[] reportValues = report?.Split(' ')?.Select(Int32.Parse)?.ToArray();

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
                    answer ++;
                }
            }

            Console.WriteLine($"The answer is of day {day} = {answer}");
        }

        public static void Part2() {
            int day = 2;
            int answer = 0;

            string[] data = readInput(day, false);

                foreach (string report in data) {
                
                bool decrease = false;
                bool increase = false;
                bool safeReport = true;
                bool skippedOne = false;    

                int[] reportValues = report?.Split(' ')?.Select(Int32.Parse)?.ToArray();
                int[] levelDiffs = new int[reportValues.Length-1];
                
                //calculate diffs
                for (int i = 0; i < (reportValues.Length-1); i++){
                    levelDiffs[i] = reportValues[i+1] - reportValues[i];
                }
             
        
                //check diffs
                for (int i = 0; i < (reportValues.Length-1); i++){
                    int diff = reportValues[i+1] - reportValues[i];

                    

                    //skip difference
                    int skipDiff = 0;
                    if (i < (reportValues.Length-1) && !(i==0)){
                        skipDiff = reportValues[i+1] - reportValues[i-1];
                    }
                   
                    if ( 0 < diff && diff <= 3 && !decrease) {
                        increase = true;      
                    }
                    else if ( -3 <= diff && diff < 0 && !increase){
                        decrease = true;
                    }
                    else {
                        //First level can easily be skipped
                        if (i == 0){
                            skippedOne = true;
                        }
                        //Last can be skipped if no other level has been skipped
                        else if (i == reportValues.Length && !skippedOne){
                            skippedOne = true;
                        }
                        //
                        else if ( 0 < skipDiff && skipDiff <= 3 && !skippedOne) {
                        increase = true;
                        skippedOne = true;      
                        }
                        else if ( -3 <= skipDiff && skipDiff < 0 && !skippedOne){
                        decrease = true;
                        skippedOne = true;
                        }
                     
                        else{
                            safeReport = false;
                        }
                    }              
                }

                if ( (!decrease && increase && safeReport) || (decrease && !increase && safeReport) ) {
                    answer ++;   
                }
                else{
                    Console.WriteLine(report.ToString());
                }
            }

            Console.WriteLine($"The answer is of day {day} part 2 = {answer}");
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
