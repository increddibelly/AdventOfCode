#nullable disable
using System.Drawing;

namespace AdventOfCode
{
    public class Map<T>
    {
        private List<List<T>> map = new List<List<T>>();

        public int XSize { get; protected set; }
        public int YSize { get; protected set; }

        private Map(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            for(var i=0; i<YSize; i++)
            {
                var list = new List<T>();
                for(var x = 0; x<XSize; x++)
                {
                    list.Add(default);
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
                if (x < 0 || y < 0 || x > XSize || y > YSize)
                    return default(T);

                return map[y][x];
            }
            set
            {
                if (x < 0 || y < 0 || x > XSize || y > YSize)
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
            return map.Select(row => row[x]).ToArray();
        }

        public T[] Row(int y)
        {
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

        public IEnumerable<Point> RingAround(Point p, int radius = 1)
        {
            for (var x = -radius; x <= radius; x++)
            {
                if (x >= 0 && x < XSize && p.Y - radius >= 0 && p.Y - radius < YSize)
                    yield return new Point(p.X + x, p.Y - radius);
                if (x >= 0 && x < XSize && p.Y + radius >= 0 && p.Y - radius < YSize)
                    yield return new Point(p.X + x, p.Y - radius);

                continue;
                if (x >= XSize || p.Y - radius >= YSize || p.Y + radius >= YSize)
                    continue;

                yield return new Point(p.X + x, p.Y - radius);
                yield return new Point(p.X + x, p.Y + radius);
            }

            y = p.Y + radius;
            for (var x = -radius; x <= radius; x++)
            {
                if (x < 0 || y < 0)
                    continue;
                if (x >= XSize || y >= YSize)
                    continue;


                yield return new Point(p.X + x, p.Y + y);
            }

            for (var y = -radius; y <= radius; y++)
            {
                var row = new List<Point>();

                
            }
        }
    }
}
