using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Day15
{
    private const char Empty = '.';
    private const char InSensorRange = '#';
    private const char Beacon = 'B';
    private const char Sensor = 'S';
    private Map<char> _map;

    private Point Origin;

    private Dictionary<Point, Point> _sensors = new Dictionary<Point, Point>();

    private void Parse(string input)
    {
        // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
        var lines = input
            .Split(Environment.NewLine)
            .Select(x => x.Replace("Sensor at ", "")
            .Replace("x=", "")
            .Replace("y=", "")
            .Replace(" closest beacon is at ", "")
            .Split(":"));
        foreach(var line in lines)
        {
            var sensor = line[0].Split(",");
            var beacon = line[1].Split(",");

            _sensors.Add(
                new Point(int.Parse(sensor[0]), int.Parse(sensor[1])),
                new Point(int.Parse(beacon[0]), int.Parse(beacon[1]))
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

        var xSize = 2 + Math.Max(maxBX, maxSX) - Math.Min(minBX, minSX);
        var ySize = 2 + Math.Max(maxBY, maxSY) - Math.Min(minBY, minSY);

        Origin = new Point(xSize, ySize);
        _map = new Map<char>(xSize*4, ySize*4, 2 * xSize , 2 * ySize, Empty);
        _map.AutoCorrection = false;
        _map.Margin = true;

        foreach (var s in _sensors)
        {
            var sensor = s.Key;

            var beacon = s.Value;

            var range = Distance(sensor, beacon);

            for (var x = sensor.X - range; x <= sensor.X + range; x++)
            {
                for (var y = sensor.Y - range; y <= sensor.Y + range; y++)
                {
                    var coord = new Point(x, y);
                    if (Distance(sensor, coord) <= range)
                    {
                        _map[coord] = InSensorRange;
                    }
                }
            }
        }

        foreach (var s in _sensors)
        {
            var sensor = s.Key;
            var beacon = s.Value;
            _map[sensor] = Sensor;
            _map[beacon] = Beacon;

        }
        var item = _map.Row(7);
    }

    private int Distance(Point from, Point to)
    {
        return Math.Abs(to.X - from.X) + Math.Abs(to.Y - from.Y);
    }

    public int Day15Part1(string input, int row)
    {
        Parse(input);
        var r = _map.Row(Origin.Y + row);
        return r.Count(x => x != Empty);
        // ..####B######################..
    }

    public int Day15Part2(string input)
    {
        return 0;
    }
}
