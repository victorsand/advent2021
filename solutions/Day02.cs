using System;
using System.Linq;
using advent2021.common;
using advent2021.utils;

namespace advent2021.solutions
{
    public class Day02 : ISolution
    {
        public void Part1()
        {
            var lines = FileUtils.ReadAllLines("input/day02-1.txt");
            var commands = lines.Select(SubmarineCommand.ParseCommand).ToList();
            var position = new SubmarinePosition();
            commands.ForEach(c => position.ApplyCommand(c));
            var answer = position.Depth * position.HorizontalPosition;
            Console.WriteLine(answer);
        }

        public void Part2()
        {
            var lines = FileUtils.ReadAllLines("input/day02-1.txt");
            var commands = lines.Select(SubmarineCommand.ParseCommand).ToList();
            var position = new SubmarinePosition();
            commands.ForEach(c => position.ApplyCommand(c, true));
            var answer = position.Depth * position.HorizontalPosition;
            Console.WriteLine(answer);
        }

    }
}