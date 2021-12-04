using System.Collections.Generic;
using System.Linq;

namespace advent2021.utils
{
    public static class FileUtils
    {
        public static string ReadSingleLine(string inputFile, int line)
        {
            return System.IO.File.ReadLines(inputFile).Skip(line-1).Take(1).First();
        }
        
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