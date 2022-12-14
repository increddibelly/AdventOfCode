using System.Drawing;

namespace AdventOfCode;

public class Day14
{
    private Map<string> _map;

    private const string Empty = " ";
    private const string Rock = "#";
    private const string Sand = "o";

    private Point BottomLeft;
    private Point BottomRight;

    private void Parse(string input, int horizontalMargin = 0, int verticalMargin = 0)
    {
        var lines = input.Split(Environment.NewLine);
        var pointsPerLine = lines
            .Select(l => l.Split(" -> ")).ToArray();
        var points = new List<List<Point>>();
        foreach(var line in pointsPerLine)
        {
            points.Add(line
                .Select(p => p.Split(","))
                .Select(p => new Point(int.Parse(p[0]), int.Parse(p[1])))
                .ToList());
        }
        var minX = points.SelectMany(p => p.Select(q => q.X)).Min() - horizontalMargin;
        var maxX = points.SelectMany(p => p.Select(q => q.X)).Max() + horizontalMargin;
        var minY = points.SelectMany(p => p.Select(q => q.Y)).Min();
        var maxY = points.SelectMany(p => p.Select(q => q.Y)).Max() + verticalMargin;
        BottomLeft = new Point(minX, maxY);
        BottomRight = new Point(maxX, maxY);
        var topLeft = new Point(minX - 1, -1);

        _map = new Map<string>(maxX - minX + 2, maxY + 2, topLeft.X, topLeft.Y, Empty);

        DrawLines(points);
    }

    private void DrawLines(List<List<Point>> zigzags)
    {
        foreach(var targets in zigzags)
        {
            var current = targets[0];
            for(var i = 1; i<targets.Count; i++)
            {
                var target = targets[i];

                while (current != target)
                {
                    _map[current] = Rock;
                    current = Step(current, target);
                }
                _map[target] = Rock;
                current = target;
            }
        }
    }

    private Point Step(Point current, Point target)
    {
        var x = Step(current.X, target.X);
        var y = Step(current.Y, target.Y);
        current.X = x;
        current.Y = y;
        return current;
    }

    private int Step(int x1, int x2)
    {
        if (x2 > x1) return x1 + 1;
        if (x2 < x1) return x1 - 1;
        return x1;
    }

    private bool WithinBounds(Point p)
    {
        return 
            p.X > BottomLeft.X &&
            p.X < BottomRight.X &&
            p.Y < BottomLeft.Y;
    }

    private Point DropSand()
    {
        var canMove = true;
        var sand = new Point(500, 0);
        do
        {
            if (!WithinBounds(sand))
            {
                break;
            }

            // drop down?
            if (_map[sand.X, sand.Y + 1] == Empty)
            {
                sand.Y++;
                continue;
            }

            // drop down LEFT?
            if (_map[sand.X - 1, sand.Y + 1] == Empty)
            {
                sand.Y++;
                sand.X--;
                continue;
            }

            // drop down RIGHT?
            if (_map[sand.X + 1, sand.Y + 1] == Empty)
            {
                sand.Y++;
                sand.X++;
                continue;
            }

            // this is our spot.
            canMove = false;

        } while (canMove);
        return sand;
    }

    public int Day14Part1(string input)
    {
        Parse(input);
        var grains = 0;
        var sand = new Point(500, 0);
        while (WithinBounds(sand))
        {
            grains++;
            sand = DropSand();
            _map[sand] = Sand;
        }

        return grains;
    }

    public int Day14Part2(string input)
    {
        Parse(input, 500, 1);
        var grains = 0;
        var sand = new Point(500, 0);
        while (true)
        {
            grains++;
            sand = DropSand();
            _map[sand] = Sand;
            if (sand.X == 500 && sand.Y == 0) 
                return grains;
        }
    }
}
