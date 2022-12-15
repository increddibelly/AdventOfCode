using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day15
{
    private Map<char> _map;

    private Dictionary<Point, Point> _sensors = new Dictionary<Point, Point>();

    private void Parse(string input)
    {
        // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
        var lines = input
            .Split(Environment.NewLine)
            .Select(x => x.Replace("Sensor at x=", "")
            .Replace("y=", "")
            .Replace(" closest beacon is at ", "")
            .Split(":"));
        foreach(var line in lines)
        {
            _sensors.Add(
                new Point(int.Parse(line[0]), int.Parse(line[1])),
                new Point(int.Parse(line[2]), int.Parse(line[3]))
                );
        }

        var minSX = _sensors.Keys.Min(x => x.X);
        var minBX = _sensors.Values.Min(x => x.X);
        var maxSX = _sensors.Keys.Max(x => x.X);
        var maxBX = _sensors.Values.Max(x => x.X);

        var minSY = _sensors.Keys.Min(x => x.Y);
        var minBY = _sensors.Values.Min(x => x.Y);
        var maxSY = _sensors.Keys.Max(x => x.Y);
        var maxBY = _sensors.Values.Max(x => x.Y);

        var xSize = Math.Max(maxBX, maxSX) - Math.Min(minBX, minSX);
        var ySize = Math.Max(maxBY, maxSY) - Math.Min(minBY, minSY);

        _map = new Map<char>(xSize, ySize, 0, 0, '.');
        foreach(var s in _sensors)
        {
            //deltaX, delta Y = range
            //blot out range
        }
    }

    private bool BeaconBetween(Point a, Point b)
    {
        return _sensors.Values.Any(b => b.X )
    }

    public int Day15Part1(string input)
    {
        Parse(input);

    }

    public int Day15Part2(string input)
    {
        return 0;
    }
}
