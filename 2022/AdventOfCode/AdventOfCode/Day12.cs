using System.Drawing;

namespace AdventOfCode;

public class Day12
{
    private const int Unknown      = 9999999;
    private const int NoDirectPath = 9996999;

    private Map<int> _height;
    private Map<int> _cheapestPath;
    private List<Point> _todo = new List<Point>();
    private List<Point> _hard = new List<Point>();
    private Point Start;
    private Point End;

    private Map<int> Parse(string input)
    {
        _height = Map<int>.Parse(input, x => x);
        _cheapestPath = Map<int>.Parse(input, x => Unknown);
        Start = _height.Find('S').Single();
        End = _height.Find('E').Single();

        // initialize the area around End
        foreach(var from in _height.PointsAround(End))
        {
            if (CanMove(from, End))
            {
                _cheapestPath[from] = 1;
            } else
            {
                _cheapestPath[from] = NoDirectPath;
            }
        }
        _cheapestPath[End] = 0;

        return _height;
    }

    private bool CanMove(Point from, Point to)
    {
        if (_height[from] <= _height[to] + 1)
            return true;
        return false;
    }

    public int Day12Part1(string input)
    {
        var cost = Map<int>.Parse(input, x => -1);
        
        do
        {
            var current = End;
            var area = _height.PointsAround(current);
            
            // try and figure out the unknowns

            // X figure out the current cheapest paths
            // figure the cheapest path to each of these, filling the map
            foreach(var point in area)
            {
                var options = GetCheapestPathsFrom(point);
            }

            for (var y = -1; y <= 1; y++)
            {
                for (var x = -1; x <= 1; x++)
                {
                    current = new Point(x, y);
                    if (CanMove(current, End))
                    {
                        _cheapestPath[current] = 1;
                    }
                    else
                    {
                        _cheapestPath[current] = NoDirectPath;
                    }
                }
            }
        } while (current != Start);

    }

    private IDictionary<Point, int> GetCheapestPathsFrom(Point point)
    {
        return _cheapestPath.Around(point)
            .OrderBy(x => x.Value)
            .GroupBy(x => x.Value)
            .First()
            .ToDictionary(x => x.Key, x => x.Value);
    }

    private void CheckRoute(Point current, Point target)
    {
        var area = map.Around(current);
        var todo = new List<Point>();
        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                current = new Point(x, y);
                if (CanMove(current, End))
                {
                    // those around End cost 1 step to reach the end
                    _cheapestPath[current] = 1;
                }
                else
                {
                    todo.Add(current);
                    _cheapestPath[current] = NoDirectPath;
                }
            }
        }
    }
}