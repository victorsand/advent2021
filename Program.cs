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
        _ => throw new ArgumentException("No solution")
    };
}