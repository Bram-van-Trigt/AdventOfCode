using System;
using System.IO;
using System.Linq;

public static class AoC2023Day4
{

    public static void Part1() {
        int day = 4;
        int answer = 0;

        string[] data = readInput(day, false);

        foreach( string line in data)
        {
            int subanswer = 0;
            bool first = true;
            string[] splitCard = line.Split("|");

            string[] winningNumbers = splitCard[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] scratchedNumbers = splitCard[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach(string number in scratchedNumbers)
            {
                    
                if (winningNumbers.Contains(number))
                {
                    if (first) { 
                        subanswer++;
                        first = false;
                    }
                    else { subanswer = subanswer * 2; }
                }
            }

            answer += subanswer;
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2()
    {
        int day = 4;
        int answer = 0;

        string[] data = readInput(day, false);

        int[] cards = new int[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            cards[i]++;
            Console.WriteLine(cards[i]);
                

            string[] splitCard = data[i].Split("|");
            string[] winningNumbers = splitCard[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] scratchedNumbers = splitCard[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int currentCardCount = cards[i];


            for (int j = 1; j <= currentCardCount; j++)
            {
                int updateCard = i;

                foreach (string number in scratchedNumbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        try
                        {
                            updateCard++;
                            cards[updateCard]++;
                        }
                        catch { }
                    }
                }
            }
        }

        answer = cards.Sum();



        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static string[] readInput(int day, bool runExample)
    {
        string[] exampleInput = File.ReadAllLines($"./puzzleInputFiles/exampleInputDay{day}.txt");
        string[] puzzleInput = File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay{day}.txt");

        if (runExample) { return exampleInput; }
        else { return puzzleInput; }
    }
}
