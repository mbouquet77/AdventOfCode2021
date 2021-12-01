using AOC2021Day1;

namespace AdventOfCode1
{
    class Program
    {

        static void Main()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\input.txt");

            var depthsList = lines.Select(int.Parse).ToList();
            Part1(depthsList);
            Console.WriteLine("");
            Part2(depthsList);
        }

        private static void Part1(List<int> depthsList)
        {
            var depths = new Depths(depthsList);
            var result = depths.CountDepthIncrement();
            Console.WriteLine(result);
        }
        private static void Part2(List<int> depthsList)
        {
            var depths = new Depths(depthsList);
            var result = depths.CountDepthIncrementWithThreeMeasurementWindow();
            Console.WriteLine(result);
        }
    }
}