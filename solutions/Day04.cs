using System;
using System.Linq;
using advent2021.common;
using advent2021.utils;

namespace advent2021.solutions
{
    public class Day04 : ISolution
    {
        public void Part1()
        {
            var draw = BingoDraw.FromInput(FileUtils.ReadSingleLine("input/day04.txt", 1));
            var boards = BingoBoard.ParseFile("input/day04.txt");

            foreach (var drawNumber in draw.Numbers)
            {
                foreach (var board in boards)
                {
                    board.RegisterNumber(drawNumber);
                    if (!board.IsWinner()) continue;
                    board.WinningNumber = drawNumber;
                    Console.WriteLine(board.CalculateScore());
                    return;
                }
            }
        }

        public void Part2()
        {
            var draw = BingoDraw.FromInput(FileUtils.ReadSingleLine("input/day04.txt", 1));
            var boards = BingoBoard.ParseFile("input/day04.txt");

            var winOrder = 0;
            
            foreach (var drawNumber in draw.Numbers)
            {
                foreach (var board in boards.Where(x => x.WinOrder == -1))
                {
                    board.RegisterNumber(drawNumber);
                    if (board.IsWinner())
                    {
                        board.WinOrder = winOrder++;
                        board.WinningNumber = drawNumber;
                    }
                }
            }

            var score = boards.Where(x => x.WinOrder != -1)
                              .OrderByDescending(x => x.WinOrder)
                              .First()
                              .CalculateScore();

            Console.WriteLine(score);
        }
    }
}