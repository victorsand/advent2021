using System;
using System.Diagnostics;
using advent2021.solutions;

ISolution solution = SelectSolution(args[0]);

var stopWatch = new Stopwatch();

Console.WriteLine("Part 1");
stopWatch.Start();
solution.Part1();
stopWatch.Stop();
Console.WriteLine($"{stopWatch.ElapsedMilliseconds} ms");

Console.WriteLine("\nPart 2");
stopWatch.Start();
solution.Part2();
stopWatch.Stop();
Console.WriteLine($"{stopWatch.ElapsedMilliseconds} ms");

return 1;

ISolution SelectSolution(string arg)
{
    return arg switch
    {
        "1" => new Day01(),
        "2" => new Day02(),
        "3" => new Day03(),
        "4" => new Day04(),
        "5" => new Day05(),
        "6" => new Day06(),
        "7" => new Day07(),
        _ => throw new ArgumentException("No solution")
    };
}