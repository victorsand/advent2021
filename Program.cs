using System;
using advent2021.solutions;

ISolution solution = SelectSolution(args[0]);

Console.WriteLine("Part 1");
solution.Part1();

Console.WriteLine("Part 2");
solution.Part2();

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