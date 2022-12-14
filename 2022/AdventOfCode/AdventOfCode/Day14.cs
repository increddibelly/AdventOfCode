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

    private void Parse(string input)
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
        var minX = points.SelectMany(p => p.Select(q => q.X)).Min();
        var maxX = points.SelectMany(p => p.Select(q => q.X)).Max();
        var minY = points.SelectMany(p => p.Select(q => q.Y)).Min();
        var maxY = points.SelectMany(p => p.Select(q => q.Y)).Max();
        BottomLeft = new Point(minX, maxY);
        BottomRight = new Point(maxX, maxY);
        var topLeft = new Point(minX - 1, -1);

        _map = new Map<string>(maxX - minX + 2, maxY + 2, topLeft.X, topLeft.Y, Empty);

        DrawLines(points);
    }

    private void DrawLines(List<List<Point>> zigzags)
    {
        foreach(var target in zigzags)
        {
            var current = target[0];
            for(var i = 1; i<target.Count; i++)
            {
                var x = current.X;
                var y = current.Y;
                for (x = current.X;
                    x != target[i].X || y != target[i].Y; )
                {
                    for (y = current.Y; 
                        y != target[i].Y || x != target[i].X; )
                    {
                        _map[x, y] = Rock;

                        if (x != target[i].X)
                        {
                            x = Step(x, current.X, target[i].X);
                        } else
                        {
                            if (y != target[i].Y)
                            {
                                y = Step(y, current.Y, target[i].Y);
                            }
                        }
                    }
                }
                _map[target[i].X, target[i].Y] = Rock;
                current = target[i];
            }

            _map[target.Last().X, target.Last().Y] = Rock;
        }
    }

    private int Step(int x, int x1, int x2)
    {
        if (x2 > x1) return x + 1;
        if (x2 < x1) return x - 1;
        return x;
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
        do
        {
            grains++;
            sand = DropSand();
            _map[sand] = Sand;
        } while (WithinBounds(sand));

        return grains;
    }

    public int Day14Part2(string input)
    {
        return 0;
    }
}
