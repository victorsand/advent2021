using System.Collections.Generic;
using System.Linq;

namespace advent2021.common
{
    public class Point
    {
        public int X { get; init; }
        public int Y { get; init; }
    }

    public class Line
    {
        public Point A { get; init; } = new();
        public Point B { get; init; } = new();

        public List<Point> GetCoveredPoints(bool includeDiagonal)
        {
            var points = new List<Point>();

            if (A.X == B.X)
            {
                var y = A.Y;
                var direction = B.Y - A.Y > 0 ? 1 : -1;
                while (y != B.Y)
                {
                    points.Add(new Point
                    {
                        X = A.X,
                        Y = y
                    });
                    y += direction;
                }
            }
            else if (A.Y == B.Y)
            {
                var x = A.X;
                var direction = B.X - A.X > 0 ? 1 : -1;
                while (x != B.X)
                {
                    points.Add(new Point
                    {
                        X = x,
                        Y = A.Y
                    });
                    x += direction;
                }
            }
            else
            {
                if (!includeDiagonal)
                {
                    return points;
                }
                
                var x = A.X;
                var y = A.Y;
                var xDirection = B.X - A.X > 0 ? 1 : -1;
                var yDirection = B.Y - A.Y > 0 ? 1 : -1;
                while (x != B.X)
                {
                    points.Add(new Point
                    {
                        X = x,
                        Y = y
                    });
                    x += xDirection;
                    y += yDirection;
                }
            }

            points.Add(B);
            return points;
        }

    }

    public class Grid
    {
        public List<Line> Lines { get; init; } = new();

        public int GetNumAtLeastTwo(bool includeDiagonal)
        {
            var coveredPoints = new Dictionary<int, Dictionary<int, int>>();

            foreach (var line in Lines)
            {
                var linePoints = line.GetCoveredPoints(includeDiagonal);
                
                foreach (var linePoint in linePoints)
                {
                    if (!coveredPoints.ContainsKey(linePoint.X))
                    {
                        coveredPoints[linePoint.X] = new Dictionary<int, int>();
                    }

                    if (coveredPoints[linePoint.X].ContainsKey(linePoint.Y))
                    {
                        coveredPoints[linePoint.X][linePoint.Y]++;
                    }
                    else
                    {
                        coveredPoints[linePoint.X][linePoint.Y] = 1;
                    }
                }
            }

            return coveredPoints.SelectMany(xDict => xDict.Value).Count(yDict => yDict.Value > 1);

        }
    }

}