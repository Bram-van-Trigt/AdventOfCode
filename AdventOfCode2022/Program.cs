using System;
using System.Linq;
using System.Reflection;


namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int year = 2023;
            int overrideDay = 4;

            int day = GetPuzzleDay(overrideDay);
            Console.WriteLine($"Puzzle day loaded is {day}");

            Assembly assembly = Assembly.LoadFrom("./AdventOfCode.dll"); // Get your assembly
            TypeInfo type = assembly.DefinedTypes
                .Where(t => t.Name.ToUpper() == $"AOC{year}DAY{day}")
                .FirstOrDefault();
            _ = type.DeclaredMethods
                .Where(t => t.Name.ToUpper().StartsWith("PART"))
                .OrderByDescending(m => m.Name.Last())
                .FirstOrDefault()
                .Invoke(null, null);
        }

        static int GetPuzzleDay(int day)
        {
            if (day == 0)
            {
                DateTime startDate = DateTime.Parse("2023/12/01");
                return (DateTime.Today - startDate).Days;
            }
            else
            {
                return day;
            }
        }
    }
}
 