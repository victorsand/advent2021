using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using advent2021.utils;

namespace advent2021.common
{
    public class BingoDraw
    {
        public List<int> Numbers { get; set; } = new List<int>();

        public static BingoDraw FromInput(string input)
        {
            return new BingoDraw
            {
                Numbers = input.Split(",").Select(int.Parse).ToList()
            };
        }
    }

    public class BingoNumber
    {
        public int Value { get; set; }
        
        public bool Checked { get; set; }
    }

    public class BingoLine
    {
        public List<BingoNumber> Numbers { get; set; } = new();

        public bool IsComplete => Numbers.All(x => x.Checked);

        public void CheckValue(int value)
        {
            Numbers.Where(x => x.Value == value).ToList().ForEach(x => x.Checked = true);
        }
    }

    public class BingoBoard
    {
        public List<BingoLine> Lines { get; set; } = new List<BingoLine>();

        public bool IsWinner()
        {
            if (Lines.Any(x => x.IsComplete)) return true;

            var numColumns = Lines.First().Numbers.Count;

            for (var i = 0; i < numColumns; i++)
            {
                var all = true;
                foreach (var line in Lines)
                {
                    if (!line.Numbers[i].Checked)
                    {
                        all = false;
                        break;
                    }
                }

                if (all) return true;
            }

            return false;
        }

        public int WinOrder { get; set; } = -1;
        
        public int WinningNumber { get; set; } = -1;

        public void RegisterNumber(int value)
        {
        
            Lines.ForEach(x => x.CheckValue(value));
        }
        
        public int CalculateScore()
        {
            var sum = 0;
            Lines.ForEach(line =>
            {
                sum += line.Numbers.Where(n => !n.Checked).Sum(l => l.Value);
            });
            return sum * WinningNumber;
        }

        public static List<BingoBoard> ParseFile(string file)
        {
            var lines = FileUtils.ReadAllLines(file).ToList();

            var boards = new List<BingoBoard>();
            var board = new BingoBoard();
            for (var line=2; line<lines.Count(); line++)
            {
                if (lines[line] == "")
                {
                    boards.Add(board);
                    board = new BingoBoard();
                    line++;
                }

                if (line == lines.Count) break;

                var cleanedLine = lines[line].Replace("  ", " ").Trim();

                board.Lines.Add(new BingoLine
                {
                    Numbers = cleanedLine.Split(" ").Select(x => new BingoNumber
                    {
                        Value = int.Parse(x),
                        Checked = false
                    }).ToList()
                });
            }
            boards.Add(board);

            return boards;
        }

    }
}