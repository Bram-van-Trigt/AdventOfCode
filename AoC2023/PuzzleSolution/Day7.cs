using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public static class AoC2023Day7
{
    public static void Part1()
    {
        int day = 7;
        int answer = 0;

        string[] data = readInput(day, false);

        List<Hand> fiveOfKindHands = new List<Hand>();
        List<Hand> fourOfKindHands = new List<Hand>();
        List<Hand> fullHouseHands = new List<Hand>();
        List<Hand> threeOfKindHands = new List<Hand>();
        List<Hand> twoPairHands = new List<Hand>();
        List<Hand> onePairHands = new List<Hand>();
        List<Hand> highCardHands = new List<Hand>();

        string[] fiveOfKind = ["AAAAA", "BBBBB", "CCCCC", "DDDDD", "EEEEE", "FFFFF", "GGGGG", "HHHHH", "IIIII", "LLLLL", "MMMMM", "NNNNN", "OOOOO"];
        string[] fourOfKind = ["AAAA", "BBBB", "CCCC", "DDDD", "EEEE", "FFFF", "GGGG", "HHHH", "IIII", "LLLL", "MMMM", "NNNN", "OOOO"];
        string[] threeOfKind = ["AAA", "BBB", "CCC", "DDD", "EEE", "FFF", "GGG", "HHH", "III", "LLL", "MMM", "NNN", "OOO"];
        string[] pair = ["AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "II", "LL", "MM", "NN", "OO"];

        foreach (string line in data)
        {
            Hand hand = new Hand(line.Split(" ")[0], int.Parse(line.Split(" ")[1]), 1);
            string sortedCards = string.Concat(hand.Cards.OrderBy(c => c));

            Debug.WriteLine(hand);

            if (fiveOfKind.Any(s => sortedCards.Contains(s)))
            {
                fiveOfKindHands.Add(hand);
            }
            else if (fourOfKind.Any(s => sortedCards.Contains(s)))
            {
                fourOfKindHands.Add(hand);
            }
            else if (threeOfKind.Any(s => sortedCards.Contains(s)))
            {
                if (hand.Cards.Distinct().Count() == 2)
                {
                    fullHouseHands.Add(hand);
                }
                else
                {
                    threeOfKindHands.Add(hand);
                }
            }
            else if (pair.Any(s => sortedCards.Contains(s)))
            {
                if (hand.Cards.Distinct().Count() == 3)
                {
                    twoPairHands.Add(hand);
                }
                else
                {
                    onePairHands.Add(hand);
                }
            }
            else
            {
                highCardHands.Add(hand);
            }
        }

        //Order all list by cards for ranks
        fiveOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        fourOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        fullHouseHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        threeOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        twoPairHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        onePairHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        highCardHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));

        //Combine lists in one for total ranks
        List<Hand> rank = new List<Hand>();
        rank.AddRange(fiveOfKindHands);
        rank.AddRange(fourOfKindHands);
        rank.AddRange(fullHouseHands);
        rank.AddRange(threeOfKindHands);
        rank.AddRange(twoPairHands);
        rank.AddRange(onePairHands);
        rank.AddRange(highCardHands);

        for (int i = 0; i < rank.Count(); i++)
        {
            Console.WriteLine(rank[i].Cards);
            int subAnswer = rank[i].Bid * (rank.Count() - i);
            answer += subAnswer;
        }

        Console.WriteLine($"The answer of day {day} = {answer}");
    }

    public static void Part2() {
        int day = 7;
        int answer = 0;

        string[] data = readInput(day, false);

        List<Hand> fiveOfKindHands = new List<Hand>();
        List<Hand> fourOfKindHands = new List<Hand>();
        List<Hand> fullHouseHands = new List<Hand>();
        List<Hand> threeOfKindHands = new List<Hand>();
        List<Hand> twoPairHands = new List<Hand>();
        List<Hand> onePairHands = new List<Hand>();
        List<Hand> highCardHands = new List<Hand>();

        string[] fiveOfKind = ["AAAAA", "BBBBB", "CCCCC", "DDDDD", "EEEEE", "FFFFF", "GGGGG", "HHHHH", "IIIII", "LLLLL", "MMMMM", "NNNNN", "OOOOO", "PPPPP"];
        string[] fourOfKind = ["AAAA", "BBBB", "CCCC", "DDDD", "EEEE", "FFFF", "GGGG", "HHHH", "IIII", "LLLL", "MMMM", "NNNN", "OOOO", "PPPP"];
        string[] threeOfKind = ["AAA", "BBB", "CCC", "DDD", "EEE", "FFF", "GGG", "HHH", "III", "LLL", "MMM", "NNN", "OOO", "PPP"];
        string[] pair = ["AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "II", "LL", "MM", "NN", "OO", "PP"];

        foreach (string line in data)
        {
            Hand hand = new Hand(line.Split(" ")[0], int.Parse(line.Split(" ")[1]), 2);
            string sortedCards = string.Concat(hand.Cards.OrderBy(c => c));

            if (fiveOfKind.Any(s => sortedCards.Contains(s)))
            {
                fiveOfKindHands.Add(hand);
            }
            else if (fourOfKind.Any(s => sortedCards.Contains(s)))
            {
                if (sortedCards.Contains("P") ) //Check for Joker card this increases hand to five of a kind. (four Jokers wil also change hand to five of a kind)
                {
                    fiveOfKindHands.Add(hand);
                }
                else
                {
                    fourOfKindHands.Add(hand);
                }
            }
            else if (threeOfKind.Any(s => sortedCards.Contains(s)))
            {
                if (sortedCards.Contains("P") && sortedCards.Distinct().Count() == 2) //Check for multiple Joker cards, this increases hand to five of a kind
                {
                    fiveOfKindHands.Add(hand);
                } 
                else if (sortedCards.Contains("P") && sortedCards.Distinct().Count() == 3)
                {
                    fourOfKindHands.Add(hand);
                }
                else if(hand.Cards.Distinct().Count() == 2)
                {
                    fullHouseHands.Add(hand);
                }
                else
                {
                    threeOfKindHands.Add(hand);
                }
            }
            else if (pair.Any(s => sortedCards.Contains(s)))
            {
                if (sortedCards.Contains("P") && sortedCards.Distinct().Count() == 3)
                {
                    if (sortedCards.Count(x => x == 'P') == 1)
                    {
                        fullHouseHands.Add(hand);
                    }
                    else
                    {
                        fourOfKindHands.Add(hand); //Check for Joker card, this increases hand to three of a kind
                    }
                        
                }
                else if(sortedCards.Contains("P") && sortedCards.Distinct().Count() == 4)
                {
                    threeOfKindHands.Add(hand);
                }
                else if(hand.Cards.Distinct().Count() == 3)
                {
                    twoPairHands.Add(hand);
                }
                else
                { 
                    onePairHands.Add(hand);
                }
            }
            else
            {
                if (sortedCards.Contains("P")) //Check for Joker card, this increases hand to one pair
                {
                    onePairHands.Add(hand);
                }
                else 
                {
                    highCardHands.Add(hand);
                }
            }
        }

        //Order all list by cards for ranks
        fiveOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        fourOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        fullHouseHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        threeOfKindHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        twoPairHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        onePairHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));
        highCardHands.Sort((x, y) => string.Compare(x.Cards, y.Cards));

        //Combine lists in one for total ranks
        List<Hand> rank = new List<Hand>();
        rank.AddRange(fiveOfKindHands);
        rank.AddRange(fourOfKindHands);
        rank.AddRange(fullHouseHands);
        rank.AddRange(threeOfKindHands);
        rank.AddRange(twoPairHands);
        rank.AddRange(onePairHands);
        rank.AddRange(highCardHands);

        for ( int i = 0; i < rank.Count(); i++)
        {
            int subAnswer = rank[i].Bid * (rank.Count() - i);
            answer += subAnswer;
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

    public struct Hand
    {
        public string Cards;
        public int Bid;

        public Hand(string Cards, int Bid, int Part)
        {
            if (Part == 1)
            {
                this.Cards = Cards
                    .Replace("K", "B")
                    .Replace("Q", "C")
                    .Replace("J", "D")
                    .Replace("T", "E")
                    .Replace("9", "F")
                    .Replace("8", "G")
                    .Replace("7", "H")
                    .Replace("6", "I")
                    .Replace("5", "L")
                    .Replace("4", "M")
                    .Replace("3", "N")
                    .Replace("2", "O");
            }
            else if (Part == 2)
            {
                this.Cards = Cards
                    .Replace("K", "B")
                    .Replace("Q", "C")
                    .Replace("J", "P")
                    .Replace("T", "E")
                    .Replace("9", "F")
                    .Replace("8", "G")
                    .Replace("7", "H")
                    .Replace("6", "I")
                    .Replace("5", "L")
                    .Replace("4", "M")
                    .Replace("3", "N")
                    .Replace("2", "O");
            }

            this.Bid = Bid;
        }
    }
}
