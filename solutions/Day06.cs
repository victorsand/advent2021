using System;
using System.Collections.Generic;
using System.Linq;
using advent2021.utils;
#pragma warning disable 8618

namespace advent2021.solutions
{
    public class Day06 : ISolution
    {
        private List<int> _input;

        public void Part1()
        {
            _input = FileUtils.ReadAllLines("input/day06.txt").First().Split(",").Select(int.Parse).ToList();
            Console.WriteLine(NumFishLarge(_input, 80));
        }

        public void Part2()
        {
            Console.WriteLine(NumFishLarge(_input, 256));
        }

        private ulong NumFishLarge(List<int> input, int numDays)
        {
            var numFishPerAge = new Dictionary<int, ulong>();

            for (var i = 0; i < 9; i++)
            {
                numFishPerAge[i] = 0;
            }
            
            foreach (var val in input)
            {
                numFishPerAge[val]++;
            }

            for (var i = 0; i < numDays; i++)
            {
                numFishPerAge[-1] = numFishPerAge[0];
                numFishPerAge[0] = numFishPerAge[1];
                numFishPerAge[1] = numFishPerAge[2];
                numFishPerAge[2] = numFishPerAge[3];
                numFishPerAge[3] = numFishPerAge[4];
                numFishPerAge[4] = numFishPerAge[5];
                numFishPerAge[5] = numFishPerAge[6];
                numFishPerAge[6] = numFishPerAge[7];
                numFishPerAge[7] = numFishPerAge[8];
                numFishPerAge[8] = numFishPerAge[-1];
                numFishPerAge[6] += numFishPerAge[-1];
            }

            ulong numFish = 0;
            for (var i = 0; i < 9; i++)
            {
                numFish += numFishPerAge[i];
            }

            return numFish;
        }
    }
}