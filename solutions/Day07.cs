using System;
using System.Linq;
using advent2021.utils;

namespace advent2021.solutions
{
    public class Day07 : ISolution
    {
        public void Part1()
        {
            var input = FileUtils.ReadSingleLine("input/day07.txt", 0);
            var positions = input.Split(",").Select(int.Parse).ToList();

            var min = positions.Min();
            var max = positions.Max();
            var minFuel = int.MaxValue;

            for (var i = min; i <= max; i++)
            {
                var fuel = 0;
                foreach (var pos in positions)
                {
                    fuel += Math.Abs(i - pos);
                }
                minFuel = Math.Min(minFuel, fuel);
            }
            Console.WriteLine(minFuel);
        }

        public void Part2()
        {
            var input = FileUtils.ReadSingleLine("input/day07.txt", 0);
            var positions = input.Split(",").Select(int.Parse).ToList();

            var min = positions.Min();
            var max = positions.Max();
            var minFuel = int.MaxValue;

            for (var i = min; i <= max; i++)
            {
                var fuel = 0;
                foreach (var pos in positions)
                {
                    fuel += ArithmeticSum(1, Math.Abs(i - pos));
                }
                minFuel = Math.Min(minFuel, fuel);
            }
            Console.WriteLine(minFuel);
        }

        // a_n and n are the same when increment is 1
        private int ArithmeticSum(int a1, int an)
        {
            return an * (a1 + an) / 2;
        }
    }
}