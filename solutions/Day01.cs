using System;
using System.Linq;
using advent2021.utils;

namespace advent2021.solutions
{
    public class Day01 : ISolution
    {
        public void Part1()
        {
            var lines = FileUtils.ReadAllLinesAsIntegers("input/day01-1.txt").ToList();
            var count = Enumerable.Range(1, lines.Count - 1)
                                  .Select(i => lines[i] > lines[i - 1])
                                  .Count(x => x);
            Console.WriteLine(count);
        }

        public void Part2()
        {
            var lines = FileUtils.ReadAllLinesAsIntegers("input/day01-1.txt").ToList();
            var count = Enumerable.Range(3, lines.Count - 3)
                                  .Select(i => lines[i] + lines[i-1] + lines[i-2]
                                             > lines[i-1] + lines[i-2] + lines[i-3])
                                  .Count(x => x);
            Console.WriteLine(count);
        }
    }
}