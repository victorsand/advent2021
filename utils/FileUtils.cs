using System.Collections.Generic;
using System.Linq;

namespace advent2021.utils
{
    public static class FileUtils
    {
        public static IEnumerable<string> ReadAllLines(string inputFile)
        {
            return System.IO.File.ReadLines(inputFile);
        }

        public static IEnumerable<int> ReadAllLinesAsIntegers(string inputFile)
        {
            return System.IO.File.ReadLines(inputFile).Select(int.Parse);
        }
    }
}