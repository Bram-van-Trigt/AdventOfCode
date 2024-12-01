using System;
using System.Linq;
using System.Reflection;


namespace AoC2024
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int year = 2024;
            int overrideDay = 0;

            int day = GetPuzzleDay(overrideDay);
            Console.WriteLine($"Puzzle day loaded is {day}");

            Assembly assembly = Assembly.LoadFrom("./AoC2024.dll"); // Get your assembly
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
                DateTime startDate = DateTime.Parse("2024/12/01");
                return (DateTime.Today - startDate).Days + 1;
            }
            else
            {
                return day;
            }
        }
    }
}
 