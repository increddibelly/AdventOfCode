#nullable disable
using System.Drawing;

namespace AdventOfCode
{
    public class Map<T>
    {
        private List<List<T>> map = new List<List<T>>();

        private readonly int XOffset = 0;
        private readonly int YOffset = 0;

        public int XSize { get; protected set; }
        public int YSize { get; protected set; }

        public bool AutoCorrection = true;
        public bool Margin = false;

        public Map(int xSize, int ySize, int xOffset = 0, int yOffset = 0, T initial = default)
        {
            XSize = xSize;
            YSize = ySize;

            XOffset = xOffset;
            YOffset = yOffset;

            for(var i=0; i<YSize; i++)
            {
                var list = new List<T>();
                for(var x = 0; x<XSize; x++)
                {
                    list.Add(initial);
                }
                map.Add(list);
            }
        }

        public static Map<T> Parse(string input, Func<char, T> parser, string? lineSeparator = null)
        {
            lineSeparator = lineSeparator ?? Environment.NewLine;
            var lines = input.Split(lineSeparator);
            
            var map = new Map<T>(lines[0].Length, lines.Length);
            var x = 0;
            var y = 0;
            foreach(var line in lines)
            {
                foreach(var item in line)
                {
                    map[x,y] = parser(item);
                    x++;
                }
                x = 0;
                y++;
            }
            return map;
        }

        public T this[int x, int y] 
        {
            get
            {
                if (AutoCorrection)
                {
                    x = x - XOffset;
                    y = y - YOffset;
                } else
                if (Margin)
                {
                    x = x + XOffset;
                    y = y + YOffset;
                }
                if (x < 0 || y < 0 || x >= XSize || y >= YSize)
                    return default(T);

                return map[y][x];
            }
            set
            {
                if (AutoCorrection)
                {
                    x = x - XOffset;
                    y = y - YOffset;
                }
                else
                if (Margin)
                {
                    x = x + XOffset;
                    y = y + YOffset;
                } 
                if (x < 0 || y < 0 || x >= XSize || y >= YSize)
                    return;

                map[y][x] = value;
            }
        }

        public T this[Point p]
        {
            get => this[p.X, p.Y];
            set => this[p.X, p.Y] = value;
        }

        public T[] Column(int x)
        {
            x = AutoCorrection ? x - XOffset : x;
            return map.Select(row => row[x]).ToArray();
        }

        public T[] Row(int y)
        {
            y = AutoCorrection ? y - YOffset : y;
            return map[y].ToArray();
        }

        public IEnumerable<Point> Find(T target)
        {
            var x = 0;
            var y = 0;
            foreach(var line in map)
            {
                foreach(var item in line)
                {
                    if (item.Equals(target))
                    {
                        yield return new Point(x, y);
                    }
                    x++;
                }
                x = 0;
                y++;
            }
        }

        public IDictionary<Point, T> Around(Point p, int radius = 1)
        {
            return PointsAround(p, radius).ToDictionary(xy => xy, xy => this[xy]);
        }

        public IEnumerable<Point> PointsAround(Point p, int radius = 1)
        {
            for (var y = -radius; y <= radius; y++)
            {
                var row = new List<Point>();

                for (var x = -radius; x <= radius; x++)
                {
                    if (x < 0 || y < 0)
                        continue;
                    if (x >= XSize || y >= YSize)
                        continue;

                    yield return new Point(p.X + x, p.Y + y);
                }
            }
        }

        public IEnumerable<Point> Adjacent(Point p)
        {
            var output = new HashSet<Point>();
            output.Add(new Point(p.X, p.Y - 1));
            output.Add(new Point(p.X, p.Y + 1));
            output.Add(new Point(p.X - 1, p.Y));
            output.Add(new Point(p.X + 1, p.Y));

            return output
                .Where(p => p.X >= 0 && p.Y >= 0)
                .Where(p => p.X < XSize && p.Y < YSize);
        }

        public IEnumerable<Point> RingAround(Point p, int radius = 1, bool withinBounds = true)
        {
            var output = new HashSet<Point>();
            for (var delta = 0; delta <= radius; delta++)
            {
                output.Add(new Point(p.X - radius + delta, p.Y - radius)); // top row
                output.Add(new Point(p.X - radius + delta, p.Y + radius)); // bottom row
                output.Add(new Point(p.X - radius, p.Y - radius + delta)); // left side
                output.Add(new Point(p.X + radius, p.Y - radius + delta)); // right side
            }
            output.Add(new Point(p.X + radius, p.Y + radius));

            return withinBounds
                ? output
                    .Where(p => p.X >= 0 && p.Y >= 0)
                    .Where(p => p.X < XSize && p.Y < YSize)
                : output;
        }
    }
}
