#nullable disable
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

        public static Map<T> Parse(string input, Func<char, T> parser, string? separator = null)
        {
            separator = separator ?? Environment.NewLine;
            var lines = input.Split(separator);
            
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

        public T[] Column(int x)
        {
            return map.Select(row => row[x]).ToArray();
        }

        public T[] Row(int y)
        {
            return map[y].ToArray();
        }
    }
}
