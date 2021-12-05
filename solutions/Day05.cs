using System;
using System.Collections.Generic;
using advent2021.common;
using advent2021.utils;
#pragma warning disable 8602

namespace advent2021.solutions
{
    public class Day05 : ISolution
    {
        private Grid? _grid;
        
        public void Part1()
        {
            var inputLines = FileUtils.ReadAllLines("input/day5.txt");
            var lines = new List<Line>();
            foreach (var line in inputLines)
            {
                var cleaned = line.Replace(" -> ", ",");
                var digits = cleaned.Split(',');
                
                var x1 = int.Parse(digits[0]);
                var y1 = int.Parse(digits[1]);
                var x2 = int.Parse(digits[2]);
                var y2 = int.Parse(digits[3]);
                
                lines.Add(new Line
                {
                    A = new Point
                    {
                        X = x1,
                        Y = y1
                    },
                    B = new Point
                    {
                        X = x2,
                        Y = y2
                    }
                });
            }

            _grid = new Grid
            {
                Lines = lines
            };

            Console.WriteLine(_grid.GetNumAtLeastTwo(false));
        }

        public void Part2()
        {
            Console.WriteLine(_grid.GetNumAtLeastTwo(true));
        }
    }
}