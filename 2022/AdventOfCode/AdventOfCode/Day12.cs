using System.Drawing;

namespace AdventOfCode;

public class Day12
{
    private const int Unknown      = 9990999;
    private const int NoDirectPath = 9991999;

    private Map<int> _height;
    private Map<int> _costMap;
    private Point Start;
    private Point End;

    private Map<int> Parse(string input)
    {
        _height = Map<int>.Parse(input, x => x);
        _costMap = Map<int>.Parse(input, x => Unknown);
        Start = _height.Find('S').Single();
        End = _height.Find('E').Single();

        _height[End] = (int)'z'; // make math easier
        _height[Start] = (int)'a'; // make math easier

        // initialize the area around End
        _costMap[End] = 0;

        return _height;
    }

    private bool IsComputed(Point p) => Cost(p) < Unknown;
    private int Cost(Point p) => _costMap[p];

    private HashSet<Point> Discover(Point target)
    {
        var todo = new HashSet<Point>();
        var area = _costMap.Adjacent(target);

        foreach(var point in area)
        {
            var cost = Cost(target) + 1;
            if (IsComputed(point))
            {
                if (cost < Cost(point))
                {
                    break;
                } 
                continue;
            }

            if (CanMove(point, target))
            {
                // found a path!
                if (Cost(point) > cost)
                {
                    _costMap[point] = cost;
                }
                // this point might work, (re)discover more!
                todo.Add(point);
            }
            else
            {
                _costMap[point] = NoDirectPath; // for now
                //todo.Add(point); // check again later
                continue;
            }
        }

        return todo;
    }

    private bool CanMove(Point from, Point to)
    {
        // off axis
        if (from.X != to.X && from.Y != to.Y)
            return false;

        // outside box
        if (from.X < to.X - 1 || from.X > to.X + 1 ||
            from.Y < to.Y - 1 || from.Y > to.Y + 1)
            return false;

        if (_height[from] == (int)'z')
            return true;

        if (_height[from] +1 >= _height[to])
            return true;

        // too high
        return false;
    }

    public int Day12Part1(string input)
    {
        Parse(input);

        var todo = Discover(End);
        var morework = true;
        var newTodo = new HashSet<Point>();
        do
        {
            foreach (var point in todo.OrderBy(p => Cost(p)))
            {
                var discoveries = Discover(point);
                newTodo.AddRange(discoveries);
            }

            todo.Clear();
            todo.AddRange(newTodo);
            newTodo.Clear();

            morework = todo.Any();
        } while (morework);
        return _costMap[Start];
    }
    public int Day12Part2(string input)
    {
        Day12Part1(input);

        return _height.Find('a')
               .Select(point => _costMap[point])
               .OrderBy(p => p)
               .First();
    }

    //private IDictionary<Point, int> GetCheapestPathsFrom(Point point)
    //{
    //    return _cheapestPath.Around(point)
    //        .OrderBy(x => x.Value)
    //        .GroupBy(x => x.Value)
    //        .First()
    //        .ToDictionary(x => x.Key, x => x.Value);
    //}

    //private void CheckRoute(Point current, Point target)
    //{
    //    var area = map.Around(current);
    //    var todo = new List<Point>();
    //    for (var y = -1; y <= 1; y++)
    //    {
    //        for (var x = -1; x <= 1; x++)
    //        {
    //            current = new Point(x, y);
    //            if (CanMove(current, End))
    //            {
    //                // those around End cost 1 step to reach the end
    //                _cheapestPath[current] = 1;
    //            }
    //            else
    //            {
    //                todo.Add(current);
    //                _cheapestPath[current] = NoDirectPath;
    //            }
    //        }
    //    }
    //}
}