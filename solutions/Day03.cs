using System;
using System.Collections.Generic;
using System.Linq;
using advent2021.utils;

namespace advent2021.solutions
{
    public class Day03 : ISolution
    {
        private List<string> _lines = new();
        private int _lineLength = 0;
        
        public void Part1()
        {
            _lines = FileUtils.ReadAllLines("input/day03.txt").ToList();
            _lineLength = _lines[0].Length;
            
            var onesPerPosition = new Dictionary<int, int>();
            Enumerable.Range(0, _lineLength).ToList().ForEach(i => onesPerPosition[i] = 0);
            
            _lines.ForEach(line =>
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        onesPerPosition[i]++;
                    }
                }
            });

            var mostCommonBitPerPosition = "";
            Enumerable.Range(0, _lineLength).ToList().ForEach(i => mostCommonBitPerPosition += (onesPerPosition[i] >= _lines.Count / 2 ? "1" : "0"));
            var leastCommonBitPerPosition = string.Concat(mostCommonBitPerPosition.Select(c => c == '1' ? '0' : '1'));
            
            var gammaRate = Convert.ToInt32(mostCommonBitPerPosition, 2);
            var epsilonRate = Convert.ToInt32(leastCommonBitPerPosition, 2);
            
            Console.WriteLine(gammaRate * epsilonRate);
        }

        public void Part2()
        {
            var oxygenSearchList = new List<string>(_lines);
            var co2SearchList = new List<string>(_lines);

            for (var i = 0; i < _lineLength; i++)
            {
                if (oxygenSearchList.Count > 1)
                {
                    var mostCommonValue = FindMostCommonValue(oxygenSearchList, i);
                    oxygenSearchList = oxygenSearchList.Where(l => l[i] == mostCommonValue).ToList();
                }

                if (co2SearchList.Count > 1)
                {
                    var leastCommonValue = FindLeastCommonValue(co2SearchList, i);    
                    co2SearchList = co2SearchList.Where(l => l[i] == leastCommonValue ).ToList();
                }
            }

            var oxygenGeneratorRating = Convert.ToInt32(oxygenSearchList.Single(), 2);
            var co2ScrubberRating = Convert.ToInt32(co2SearchList.Single(), 2);

            Console.WriteLine(oxygenGeneratorRating * co2ScrubberRating);
        }

        private char FindMostCommonValue(List<string> oxygenSearchList, int index)
        {
            var numOnes = oxygenSearchList.Count(l => l[index] == '1');
            var numZeroes = oxygenSearchList.Count - numOnes;
            return (numOnes - numZeroes >= 0) ? '1' : '0';
        }

        private char FindLeastCommonValue(List<string> co2SearchList, int index)
        {
            var numOnes = co2SearchList.Count(l => l[index] == '1');
            var numZeroes = co2SearchList.Count - numOnes;
            return (numOnes - numZeroes >= 0) ? '0' : '1';
        }
    }
}