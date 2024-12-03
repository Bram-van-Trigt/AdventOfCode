using System;
using System.IO;

public static class AoC2023Day6
{

    public static void Part1() {
        int day = 6;
        int answer = 1;

        string[] input = readInput(day, false);
            
        string[] time = input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] distance = input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        //Skip over "Time:" and "Distance"
        for (int i = 1; i < distance.Length; i++)
        {   
            answer = answer * getNumberOfWins(int.Parse(time[i]), int.Parse(distance[i]));
        }

        Console.WriteLine($"The answer is of day {day} = {answer}");

    }

    public static void Part2()
    {
        int day = 6;


        string[] input = readInput(day, false);

        long time = long.Parse(input[0].Replace(" ", ""));
        long distance= long.Parse(input[1].Replace(" ", ""));

        Console.WriteLine(time);
        Console.WriteLine(distance);

        int answer = getNumberOfWins(time, distance);

        Console.WriteLine($"The answer is of day {day} = {answer}");

    }

    public static string[] readInput(int day, bool example)
    {
        string[] exampleInput = File.ReadAllLines($"./puzzleInputFiles/exampleInputDay{day}.txt");
        string[] puzzleInput = File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay{day}.txt");

        if (example) { return exampleInput; }
        else { return puzzleInput; }
    }

    public static int getNumberOfWins( long time, long distance)
    {
        int subAnswer = 0;

        for (int i = 1; i < time; i++)
        {
            //Speed = i, remaining time = time-i, racedDistance = speed * remaining time
            long racedDistance = (time-i) * i;
                
            if(racedDistance > distance) { subAnswer++; }
        }

        Console.WriteLine($"The subanswer for time {time} = {subAnswer} ");
        return subAnswer;
                       
    }

}

