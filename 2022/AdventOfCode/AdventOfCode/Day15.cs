using System.Drawing;
using System.Text;

namespace AdventOfCode;

public class Day15
{
    private const char Empty = '.';
    private const char InSensorRange = '#';
    private const char Beacon = 'B';
    private const char Sensor = 'S';

    //private HashSet<Point> _map = new HashSet<Point>(100000);

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
        foreach (var line in lines)
        {
            var sensor = line[0].Split(",");
            var beacon = line[1].Split(",");

            _sensors.Add(
                new Point(int.Parse(sensor[0]), int.Parse(sensor[1])),
                new Point(int.Parse(beacon[0]), int.Parse(beacon[1]))
            );
        }


    }

    private int Distance(Point from, Point to)
    {
        return Math.Abs(to.X - from.X) + Math.Abs(to.Y - from.Y);
    }

    public int Day15Part1(string input, int rowNr)
    {
        Parse(input);

        var covered = new HashSet<Point>();

        foreach (var s in _sensors)
        {
            var sensor = s.Key;
            var beacon = s.Value;

            if (sensor.Y == rowNr)
            {
                covered.Add(sensor);
                continue;
            }

            if (beacon.Y == rowNr)
            {
                covered.Add(beacon);
                continue;
            }

            var range = Distance(sensor, beacon);
            var y = rowNr;

            for (var x = sensor.X - range; x <= sensor.X + range; x++)
            {
                //for (var y = sensor.Y - range; y <= sensor.Y + range; y++)
                //{
                var coord = new Point(x, y);
                if (Distance(sensor, coord) <= range)
                {
                    covered++;
                }
                //}
            }
        }
        return covered;

    }

    //public string ShowMap()
    //{
    //    var minX = _map.Min(p => p.X);
    //    var maxX = _map.Max(p => p.X);
    //    var minY = _map.Min(p => p.Y);
    //    var maxY = _map.Max(p => p.Y);
    //    var sb = new StringBuilder();

    //    var points = _map.OrderBy(p => p.Y).ThenBy(p => p.X).ToArray();
    //    var pIndex = 0;

    //    var p = points[pIndex++];
    //    for (var y = minY; y < maxY; y++)
    //    {
    //        for (var x = minX; x < maxX; x++)
    //        {
    //            if (p.Y == y && p.X == x)
    //            {
    //                var S = (_sensors.Keys.Any(s => s == p));
    //                var B = (_sensors.Values.Any(b => b == p));
    //                sb.Append(S ? Sensor : B ? Beacon : InSensorRange);
    //                p = points[pIndex++];
    //            }
    //            else
    //            {
    //                sb.Append(Empty);
    //            }
    //        }
    //        sb.AppendLine();
    //    }

    //    return sb.ToString();
    //}

    public int Day15Part2(string input)
    {
        return 0;
    }
}
